using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class NumbersEmptyRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            if (data.Numbers.Length == 0)
            {
                throw new BadRequestException(
                    401, 
                    "401 AD_REQUEST PHONE_NUMBERS_EMPTY: Phone_numbers is missing.");
            }
        }
    }
}
