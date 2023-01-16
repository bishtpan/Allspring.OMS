using Allspring.OMS.Api.Service.Validators.SourceValidator;

namespace Allspring.OMS.Api.Service.Validators
{
    public class Validator
    {
        private readonly IEnumerable<ValidatorMetaData> _metadata;
        public Validator(IEnumerable<ValidatorMetaData> metaData) {
            _metadata = metaData;
        }

        public string ValidateAll()
        {
            var sb = new StringBuilder();
            foreach (var item in _metadata)
            {
                var error = item.Execute(item.PropertyValue);
                if(String.IsNullOrWhiteSpace(error)) continue;
                sb.AppendLine(error);
            }
            return sb.ToString();
        }
    }
}
