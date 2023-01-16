using Allspring.OMS.Api.Infrastructure;
using Allspring.OMS.Api.Model;
using Microsoft.Extensions.Logging;

namespace Allspring.OMS.Api.Test
{
    public class OMSAAARepositoryShould
    {
       
        [Fact]
        public async Task ShouldReturn1RowWithValidMapping()
        {
            var logger = new Mock<ILogger<OMSRepository>>();


            var mockFileWriter = new Mock<IPersister>();

            var mockSource = new Mock<IDataSource>();
            mockSource.Setup(x => x.GetData(SourceType.Portfolio)).Returns(StaticDataStore.GetPortfolio());
            mockSource.Setup(x => x.GetData(SourceType.Security)).Returns(StaticDataStore.GetSecurity());
            mockSource.Setup(x => x.GetData(SourceType.Transaction)).Returns(new List<Line> {
                new Line("SecurityId,PortfolioId,Nominal,OMS,TransactionType"),
                new Line("1,1,10,AAA,BUY"),
                new Line("2,2,20,BBB,SELL"),
                new Line("1,2,30,CCC,BUY")
            });


            var configuration = Utility.SetupIConfiguration("AAA", "OMS_AAA", "aaa", ",", "true", "ISIN,PortfolioCode,Nominal,TransactionType");
            


            var sut = new OMSRepository(mockSource.Object, configuration, mockFileWriter.Object,logger.Object);
            var portfolio = await sut.GetAAAData();

            Assert.True(portfolio.Count() == 1, "Should have got only one row");
            mockFileWriter.Verify(m => m.Persist(
                It.Is<FileMetadata>(metadata => Utility.VerifyFileMetadata(metadata,',',"aaa", "OMS_AAA", "ISIN,PortfolioCode,Nominal,TransactionType",true)),
                It.Is<IEnumerable<string>>(lines=> Utility.VerifyFileData(lines, "ISIN11111111", "p1",","))), Times.Once());
        }

        
    }
}