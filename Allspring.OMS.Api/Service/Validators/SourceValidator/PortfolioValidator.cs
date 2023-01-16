using Allspring.OMS.Api.Service.Validators.SourceValidator;

public class PortfolioValidator
{
    private static string IsDataValid(Line line, char delimiter)
    {
        var splittedLine = line.Split(delimiter);
        var validators = new List<ValidatorMetaData>
        {
            new ValidatorMetaData("PortfolioId", splittedLine[0],new NumericValidator().IsValid) ,
            new ValidatorMetaData("PortfolioCode", splittedLine[1],new NotEmpty().IsValid)
        };

        var validate = new Validator(validators);
        var error = validate.ValidateAll();
        return error;
    }


    public static bool IsDataValid(Line line, IConfiguration configuration)
    {
        var delimiter = configuration["Input:Portfolio:Delimiter"];
        char delimiterForSplit = ',';
        Char.TryParse(delimiter, out delimiterForSplit);
        var error = IsDataValid(line, delimiterForSplit);
        return string.IsNullOrEmpty(error) && line.HasDataAndDelimited(delimiterForSplit);

    }
}
