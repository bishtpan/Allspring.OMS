namespace Allspring.OMS.Api.Entity;

public class Portfolio
{
    public int PortfolioId { get; set; }
    public string PortfolioCode { get; set; }

    public override string ToString()
    {
        return $"{PortfolioId},{PortfolioCode}";
    }
}