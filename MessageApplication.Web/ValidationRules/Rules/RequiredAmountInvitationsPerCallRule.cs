using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class RequiredAmountInvitationsPerCallRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            if (data.Numbers.Length > data.RequiredAmountInvitationsPerCallRule)
            {
                throw new BadRequestException(
                    402, 
                    "402 BAD_REQUEST PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 16 per request.");
            }
        }
    }
}
