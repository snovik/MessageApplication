using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class NumberOfInvitationsRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            if (data.Numbers.Length + data.PermissibleNumberOfInvitations > data.TreshhsoldPermissibleNumberOfInvitations)
            {
                throw new BadRequestException(
                    403, 
                    "403 BAD_REQUEST PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 128 per day.");
            }
        }
    }
}
