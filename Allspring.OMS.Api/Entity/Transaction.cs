using Allspring.OMS.Api.Entity.Enum;

namespace Allspring.OMS.Api.Entity
{
    public class Transaction
    {
        public int SecurityId { get; set; }
        public int PortfolioId { get; set; }
        public decimal Nominal { get; set; }
        public OMSType OMSType { get; set; }
        public TransactionType TransactionType { get;set; }

        public override string ToString()
        {
            return $"{SecurityId},{PortfolioId},{Nominal},{OMSType},{TransactionType}";
        }
    }
}
