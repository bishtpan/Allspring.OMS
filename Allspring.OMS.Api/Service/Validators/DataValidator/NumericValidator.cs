using System.Numerics;

namespace Allspring.OMS.Api.Service.Validators.DataValidator
{
    public class NumericValidator : IValidator
    {
        public string IsValid(string value)
        {
            if (long.TryParse(value, out _))
            {
                return string.Empty;
            }
            return $"Can't convert ${value} to Number";
        }
    }
}
