using Allspring.OMS.Api.Entity.Enum;
using Allspring.OMS.Api.Model;

namespace Allspring.OMS.Api.Service.Validators.SourceValidator;

public class TransactionValidator
{
    private static string IsDataValid(Line line, char delimiter)
    {
        /*SecurityId,PortfolioId,Nominal,OMS,TransactionType
         * Integer Integer Decimal String(3) String

         */
        var splittedLine = line.Split(delimiter);
        var validators = new List<ValidatorMetaData>
        {
            new ValidatorMetaData("SecurityId", splittedLine[0],new NumericValidator().IsValid) ,
            new ValidatorMetaData("PortfolioId", splittedLine[1],new NotEmpty().IsValid),
            new ValidatorMetaData("Nominal", splittedLine[2],new DecimalValidator().IsValid),
             new ValidatorMetaData("OMS", splittedLine[3], new EnumValidator().IsValid<OMSType>),
            new ValidatorMetaData("TransactionType", splittedLine[4], new EnumValidator().IsValid<TransactionType>)
        };

        var validate = new Validator(validators);
        var error = validate.ValidateAll();
        return error;
    }


    public static bool IsDataValid(Line line, IConfiguration configuration)
    {
        var delimiter = configuration["Input:Transaction:Delimiter"];
        char delimiterForSplit = ',';
        char.TryParse(delimiter, out delimiterForSplit);
        var error = IsDataValid(line, delimiterForSplit);
        return string.IsNullOrEmpty(error) && line.HasDataAndDelimited(delimiterForSplit);

    }
}
