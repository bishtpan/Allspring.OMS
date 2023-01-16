
public class SecurityValidator
{
    /*
     * SecurityId,ISIN,Ticker,CUSIP
     * Integer String String String
     */
    private static string IsDataValid(Line line, char delimiter)
    {
        var splittedLine = line.Split(delimiter);
        var validators = new List<ValidatorMetaData>
        {
            new ValidatorMetaData("SecurityId", splittedLine[0],new NumericValidator().IsValid) ,
            new ValidatorMetaData("ISIN", splittedLine[1],new NotEmpty().IsValid),
            new ValidatorMetaData("Ticker", splittedLine[2],new NotEmpty().IsValid),
            new ValidatorMetaData("CUSIP", splittedLine[3],new NotEmpty().IsValid)
        };

        var validate = new Validator(validators);
        var error = validate.ValidateAll();
        return error;
    }


    public static bool IsDataValid(Line line, IConfiguration configuration)
    {
        var delimiter = configuration["Input:Security:Delimiter"];
        char delimiterForSplit = ',';
        Char.TryParse(delimiter, out delimiterForSplit);
        var error = IsDataValid(line, delimiterForSplit);
        return string.IsNullOrEmpty(error) && line.HasDataAndDelimited(delimiterForSplit);

    }
}
