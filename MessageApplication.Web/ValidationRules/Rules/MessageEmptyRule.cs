using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class MessageEmptyRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            if (string.IsNullOrEmpty(data.Message))
            {
                throw new BadRequestException(
                    405,
                    "405 BAD_REQUEST MESSAGE_EMPTY: Invite message is missing.");
            }
        }
    }
}
