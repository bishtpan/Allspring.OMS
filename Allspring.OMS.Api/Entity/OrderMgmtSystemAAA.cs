namespace Allspring.OMS.Api.Entity
{
    public class OrderMgmtSystemAAA
    {
        public string ISIN { get; set; }
        public string PortfolioCode { get; set; }
        public Decimal Nominal { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
