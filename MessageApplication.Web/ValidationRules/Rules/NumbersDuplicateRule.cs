using System.Linq;
using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class NumbersDuplicateRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            if(data.Numbers.Distinct().Count() != data.Numbers.Length)
            {
                throw new BadRequestException(
                    404, 
                    "404 BAD_REQUEST PHONE_NUMBERS_INVALID: Duplicate numbers detected.");
            }
        }
    }
}
