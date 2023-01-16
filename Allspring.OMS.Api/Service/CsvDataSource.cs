
namespace Allspring.OMS.Api.Service;

public class CsvDataSource : IDataSource
{
    private readonly IConfiguration _configuration;
    public CsvDataSource(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Line> GetData(SourceType sourceType)
    {
        var lines = sourceType.ReadAll(_configuration);
        return lines;
       
    }

}
