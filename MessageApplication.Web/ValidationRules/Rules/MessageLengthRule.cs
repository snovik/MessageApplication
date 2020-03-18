using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class MessageLengthRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            if (data.Message.Length > data.MaxMessageLength)
            {
                throw new BadRequestException(
                    407,
                    "407 BAD_REQUEST MESSAGE_INVALID: Invite message too long, should be less or equal to 128 characters of 7-bit GSM charset.");
            }
        }
    }
}
