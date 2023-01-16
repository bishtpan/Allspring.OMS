using Allspring.OMS.Api.Infrastructure;
using Allspring.OMS.Api.Model;
using Microsoft.Extensions.Logging;

namespace Allspring.OMS.Api.Test
{
    public class OMSCCCRepositoryShould
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


            var configuration = Utility.SetupIConfiguration("CCC", "OMS_CCC", "ccc", ",", "","");


            var sut = new OMSRepository(mockSource.Object, configuration, mockFileWriter.Object, logger.Object);
            var portfolio = await sut.GetCCCData();

            Assert.True(portfolio.Count() == 1, "Should have got only one row");
            mockFileWriter.Verify(m => m.Persist(
               It.Is<FileMetadata>(metadata => Utility.VerifyFileMetadata(metadata, ',', "ccc", "OMS_CCC", "", false)),
               It.Is<IEnumerable<string>>(lines => Utility.VerifyFileData(lines, "s1", "p2",","))), Times.Once());
        }
        
    }
}