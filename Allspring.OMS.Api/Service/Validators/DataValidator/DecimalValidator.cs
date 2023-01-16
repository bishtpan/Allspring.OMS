namespace Allspring.OMS.Api.Service.Validators.DataValidator;

public class DecimalValidator : IValidator
{
    public string IsValid(string value)
    {
        if (decimal.TryParse(value, out _))
        {
            return string.Empty;
        }
        return $"Can't convert ${value} to Decimal";
    }
}
