using System.Collections.Generic;
using MessageApplication.Web.ValidationRules.Rules;

namespace MessageApplication.Web.ValidationRules
{
    public class Validation
    {
        public void ValidateRules(ValidationData data)
        {
            var rules = new List<IValidationRule>
            {
                new MessageEmptyRule(),
                new NumbersEmptyRule(),
                new NumbersDuplicateRule(),
                new InternationalFormatRule(),
                new NumberOfInvitationsRule(),
                new RequiredAmountInvitationsPerCallRule(),
                new GsmFormatRule(),
                new MessageLengthRule(),
            };

            foreach (IValidationRule rule in rules)
            {
                rule.Validate(data);
            }
        }
    }
}
