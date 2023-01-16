namespace Allspring.OMS.Api.Entity
{
    public class Security
    {
        public int SecurityId { get; set; }
        public string ISIN { get; set; }
        public string Ticker { get; set; }

        public string Cusip { get; set; }

        public override string ToString()
        {
            return $"{SecurityId},{ISIN},{Ticker},{Cusip}";
        }
    }
}
