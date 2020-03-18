namespace MessageApplication.Web.ValidationRules
{
    public static class ValidationDataBuilderEx
    {
        public static ValidationData AddNumbers(this ValidationData validationData, string[] numbers)
        {
            validationData.Numbers = numbers;
            return validationData;
        }

        public static ValidationData AddMessage(this ValidationData validationData, string message)
        {
            validationData.Message = message;
            return validationData;
        }

        public static ValidationData AddPermissibleNumberOfInvitations(this ValidationData validationData, int permissibleNumberOfInvitations, int treshsoldPermissibleNumberOfInvitations)
        {
            validationData.PermissibleNumberOfInvitations = permissibleNumberOfInvitations;
            validationData.TreshhsoldPermissibleNumberOfInvitations = treshsoldPermissibleNumberOfInvitations;
            return validationData;
        }

        public static ValidationData AddRequiredAmountInvitationsPerCallRule(this ValidationData validationData, int requiredAmountInvitationsPerCallRule)
        {
            validationData.RequiredAmountInvitationsPerCallRule = requiredAmountInvitationsPerCallRule;
            return validationData;
        }

        public static ValidationData AddMaxMessageLength(this ValidationData validationData, int maMessageLength)
        {
            validationData.MaxMessageLength = maMessageLength;
            return validationData;
        }
    }
}
