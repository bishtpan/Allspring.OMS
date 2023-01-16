namespace Allspring.OMS.Api.Model;

public static class LineExtention
{
    const char DELIMITER = ',';
    public static bool HasDataAndDelimited(this Line line, char delimiter = DELIMITER)
    {
        return !string.IsNullOrWhiteSpace(line.Content) && line.Content.Contains(DELIMITER);
    }

    public static bool HasNoDataOrNotDelimited(this Line line, char delimiter = DELIMITER)
    {
        return !HasDataAndDelimited(line, delimiter);
    }


    public static string[] Split(this Line line, char delimiter = DELIMITER)
    {
        return line.Content.Split(delimiter);
    }

    public static Portfolio ToPortfolio(this Line line)
    {
        var splitted = line.Split(DELIMITER);
        return new Portfolio { PortfolioId = Int32.Parse(splitted[0]) , PortfolioCode= splitted[1] };
    }

    public static Security ToSecurity(this Line line)
    {
        //SecurityId,ISIN,Ticker,CUSIP
        var splitted = line.Split(DELIMITER);
        return new Security {SecurityId= Int32.Parse(splitted[0]), ISIN= splitted[1], Ticker = splitted[2], Cusip = splitted[3]  };
    }

    public static Transaction ToTransaction(this Line line)
    {
        //SecurityId,PortfolioId,Nominal,OMS,TransactionType
        var splitted = line.Split(DELIMITER);
        return new Transaction
        {
            SecurityId = Int32.Parse(splitted[0]),
            PortfolioId = Int32.Parse(splitted[1]),
            Nominal = Decimal.Parse(splitted[2]),
            OMSType = Enum.Parse<OMSType>(splitted[3]),
            TransactionType = Enum.Parse<TransactionType>(splitted[4])
        };
    }


}
