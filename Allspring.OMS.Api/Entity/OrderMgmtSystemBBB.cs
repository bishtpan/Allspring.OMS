namespace Allspring.OMS.Api.Entity
{
    public class OrderMgmtSystemBBB
    {
        public string CUSIP { get; set; }
        public string PortfolioCode { get; set; }
        public Decimal Nominal { get; set; }

        public TransactionType TransactionType { get; set; }
    }
}
