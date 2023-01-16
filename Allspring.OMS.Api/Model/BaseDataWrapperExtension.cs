namespace Allspring.OMS.Api.Model
{
    public static class BaseDataWrapperExtension
    {
        public static OrderMgmtSystemAAA toAAA(this BaseDataWrapperSlim data)
        {
            return new OrderMgmtSystemAAA
            {
                ISIN = data.Security.ISIN,
                PortfolioCode = data.Portfolio.PortfolioCode,
                Nominal = data.Transaction.Nominal,
                TransactionType = data.Transaction.TransactionType
            };
        }

        public static string toTextAAA (this OrderMgmtSystemAAA data , char delimeter)
        {
            var sb = new StringBuilder();
            sb.Append(data.ISIN);
            sb.Append(delimeter);
            sb.Append(data.PortfolioCode);
            sb.Append(delimeter);
            sb.Append(data.Nominal);
            sb.Append(delimeter);
            sb.Append(data.TransactionType);

            return sb.ToString();
        }

        public static string toText(string security, string portfolioCode, string nominal , string transactionType , char delimeter)
        {
            var sb = new StringBuilder();
            sb.Append(security);
            sb.Append(delimeter);
            sb.Append(portfolioCode);
            sb.Append(delimeter);
            sb.Append(nominal);
            sb.Append(delimeter);
            sb.Append(transactionType);

            return sb.ToString();
        }



        public static OrderMgmtSystemBBB toBBB(this BaseDataWrapperSlim data)
        {
            return new OrderMgmtSystemBBB
            {
                CUSIP = data.Security.Cusip,
                PortfolioCode = data.Portfolio.PortfolioCode,
                Nominal = data.Transaction.Nominal,
                TransactionType = data.Transaction.TransactionType
            };
        }

        public static OrderMgmtSystemCCC toCCC(this BaseDataWrapperSlim data)
        {
            return new OrderMgmtSystemCCC
            {
                Ticker = data.Security.Ticker,
                PortfolioCode = data.Portfolio.PortfolioCode,
                Nominal = data.Transaction.Nominal,
                TransactionType = data.Transaction.TransactionType
            };
        }



    }
}
