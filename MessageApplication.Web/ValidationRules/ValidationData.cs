namespace MessageApplication.Web.ValidationRules
{
    public class ValidationData
    {
        public string[] Numbers { get; set; }

        public string Message { get; set; }

        public int RequiredAmountInvitationsPerCallRule { get; set; }

        public int PermissibleNumberOfInvitations { get; set; }

        public int TreshhsoldPermissibleNumberOfInvitations { get; set; }

        public int MaxMessageLength { get; set; }
    }
}
