namespace Allspring.OMS.Api.Entity
{
    public class OrderMgmtSystemCCC
    {
        public string Ticker { get; set; }
        public string PortfolioCode { get; set; }
        public Decimal Nominal { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
