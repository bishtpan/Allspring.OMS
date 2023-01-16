namespace Allspring.OMS.Api.Service.Validators.SourceValidator;

public record ValidatorMetaData
{
    public string PropertyName { get; private set; }
    public string PropertyValue { get; private set; }
    public Func<string, string> Execute { get; private set; }
    public string Error { get; set; } = string.Empty;

    public ValidatorMetaData(string propertName, string propertyValue, Func<string, string> execute)
    {
        PropertyName = propertName;
        PropertyValue = propertyValue;
        Execute = execute;
    }
};
