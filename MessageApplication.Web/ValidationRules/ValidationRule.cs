namespace MessageApplication.Web.ValidationRules
{
    public interface IValidationRule
    {
        void Validate(ValidationData data);
    }
}
