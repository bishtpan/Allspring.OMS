namespace Allspring.OMS.Api.Service.Validators.DataValidator;

public class NotEmpty : IValidator
{
    public string IsValid(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return "No data provided";
        }
        return string.Empty;
    }
}
