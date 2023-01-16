using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Allspring.OMS.Api.Service.Validators.DataValidator
{
    public class EnumValidator
    {
        public  string IsValid<T>(string data) where T: Enum
        {
            if(Enum.IsDefined(typeof(T), data))
            {
                return string.Empty;
            }
            return $"The provided data {data} for {typeof(T).Name} is invalid";
        }
    }
}
