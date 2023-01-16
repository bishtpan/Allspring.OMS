using Allspring.OMS.Api.Infrastructure;

namespace Allspring.OMS.Api.Service;
public class OMSRepository : IOMSRespository
{
    private readonly IDataSource _dataSource;
    private readonly IConfiguration _configuration;
    private readonly IPersister _persister;
    private readonly ILogger<OMSRepository> _logger;
    public OMSRepository(IDataSource dataSource
        , IConfiguration configuration 
        , IPersister persister,
         ILogger<OMSRepository> logger
        )
    {
        _dataSource= dataSource;
        _configuration = configuration;
        _persister = persister ?? throw new ArgumentNullException();
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
    

    public async Task<IEnumerable<OrderMgmtSystemAAA>> GetAAAData()
    {
        
        var baseData=  await GetBaseData(OMSType.AAA);

        if (baseData == null)
            return null;


        var omsData = from data in baseData
                      select data.toAAA();

       

        var fileMetadata = _configuration.extractFileMetadata(OMSType.AAA);
        var dataToWrite = from line in omsData
                          select BaseDataWrapperExtension.toText(line.ISIN,
                          line.PortfolioCode,
                          line.Nominal.ToString(),
                          line.TransactionType.ToString(),
        fileMetadata.Delimiter);

        _persister.Persist(fileMetadata, dataToWrite);
        return omsData;
    }


    public async Task<IEnumerable<OrderMgmtSystemBBB>> GetBBBData()
    {
        var baseData = await GetBaseData(OMSType.BBB);
        var omsData = from data in baseData
                      select data.toBBB();

        var fileMetadata = _configuration.extractFileMetadata(OMSType.BBB);

        var dataToWrite = from line in omsData
                          select BaseDataWrapperExtension.toText(line.CUSIP,
                          line.PortfolioCode,
                          line.Nominal.ToString(),
                          line.TransactionType.ToString(),
        fileMetadata.Delimiter);

        _persister.Persist(fileMetadata, dataToWrite);
        return omsData;
    }

    public async Task<IEnumerable<OrderMgmtSystemCCC>> GetCCCData()
    {
        var baseData = await GetBaseData(OMSType.CCC);
        var omsData = from data in baseData
                      select data.toCCC();

        var fileMetadata = _configuration.extractFileMetadata(OMSType.CCC);
        var dataToWrite = from line in omsData
                          select BaseDataWrapperExtension.toText(line.Ticker,
                          line.PortfolioCode,
                          line.Nominal.ToString(),
                          line.TransactionType.ToString(),
                          fileMetadata.Delimiter);

        _persister.Persist(fileMetadata, dataToWrite);

        return omsData;
    }

    
    private async Task<IEnumerable<BaseDataWrapperSlim>> GetBaseData(OMSType omsType)
    {
        var wrapper = new BaseDataWrapper();

        try
        {
            await Task.Run(() =>
            {
                Parallel.Invoke(
                () => { wrapper.Portfolios = GetPortfolio(); },
                () => { wrapper.Securities = GetSecurity(); },
                () => { wrapper.Transactions = GetTransaction(omsType); }
            );
            });

            var data = from xtn in wrapper.Transactions
                       join portfolio in wrapper.Portfolios on xtn.PortfolioId equals portfolio.PortfolioId
                       join security in wrapper.Securities on xtn.SecurityId equals security.SecurityId
                       select new BaseDataWrapperSlim
                       {
                           Portfolio = portfolio,
                           Security = security,
                           Transaction = xtn
                       };

            return data;
        }
        catch (AggregateException e)
        {
            var cause = e.InnerExceptions[0];
            if(cause != null)
            {
                _logger.LogError($"Error getting data {cause.ToString}");
            }
        }
        return null;
    }


    private IEnumerable<Portfolio> GetPortfolio()
    {
        var lines = _dataSource.GetData(SourceType.Portfolio);

        var portfolios = from line in lines.Skip(1)
                         where PortfolioValidator.IsDataValid(line, _configuration)
                         select line.ToPortfolio();

        return portfolios;
    }

    private IEnumerable<Transaction> GetTransaction(OMSType omsType)
    {
        var lines = _dataSource.GetData(SourceType.Transaction);

        var transaction = from line in lines.Skip(1)
                          where TransactionValidator.IsDataValid(line, _configuration)
                          select line.ToTransaction();

        return transaction.Where(xtn => xtn.OMSType == omsType);
    }

    private IEnumerable<Security> GetSecurity()
    {
        var lines = _dataSource.GetData(SourceType.Security);
        var securities = from line in lines.Skip(1)
                          where SecurityValidator.IsDataValid(line, _configuration)
                          select line.ToSecurity();

        return securities;
    }



}


