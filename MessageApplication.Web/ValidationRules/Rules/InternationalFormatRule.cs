using System.Linq;
using System.Text.RegularExpressions;
using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class InternationalFormatRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            string pattern = "^7[0-9]{10}$";

            if (!data.Numbers.All(number => Regex.IsMatch(number, pattern)))
            {
                throw new BadRequestException(
                    400, 
                    "400 BAD_REQUEST PHONE_NUMBERS_INVALID: One or several phone numbers do not match with international format.");
            }
        }
    }
}
