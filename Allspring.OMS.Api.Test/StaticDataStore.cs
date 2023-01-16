using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Allspring.OMS.Api.Model;

namespace Allspring.OMS.Api.Test
{
    internal static class StaticDataStore
    {
        private static Dictionary<Options, IEnumerable<Line>> store ;
        static StaticDataStore()
        {
        }

        public static IEnumerable<Line> GetPortfolio()
        {
            return new List<Line> {
                new Line("PortfolioId,PortfolioCode"),
                new Line("1,p1"),
                new Line("2,p2")
            };
        }

        public static IEnumerable<Line> GetSecurity()
        {
            return new List<Line> {
                new Line("SecurityId,ISIN,Ticker,CUSIP"),
                new Line("1,ISIN11111111,s1,CUSIP0001"),
                new Line("2,ISIN22222222,s2,CUSIP0002")
            };
        }

       
    }

    public enum Options
    {
        ONEVALID,
        AllValid,
        NoValid
    }


}
