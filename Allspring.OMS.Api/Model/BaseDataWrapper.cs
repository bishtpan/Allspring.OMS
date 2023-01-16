namespace Allspring.OMS.Api.Model;

public record BaseDataWrapper
{
    public IEnumerable<Portfolio> Portfolios { get; set; } = new List<Portfolio>();
    public IEnumerable<Security> Securities { get; set; } = new List<Security>();
    public IEnumerable<Transaction> Transactions { get; set; } = new List<Transaction>();
}
