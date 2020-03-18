using System.Text.RegularExpressions;
using MessageApplication.Web.Exceptions;

namespace MessageApplication.Web.ValidationRules.Rules
{
    public class GsmFormatRule : IValidationRule
    {
        public void Validate(ValidationData data)
        {
            string pattern = "^[A-Za-z0-9 \\r\\n@£$¥èéùìòÇØøÅå\u0394_\u03A6\u0393\u039B\u03A9\u03A0\u03A8\u03A3\u0398\u039EÆæßÉ!\"#$%&amp;'()*+,\\-./:;&lt;=&gt;?¡ÄÖÑÜ§¿äöñüà^{}\\\\\\[~\\]|\u20AC]*$";

            if (Regex.IsMatch(data.Message, pattern))
            {
                data.AddMaxMessageLength(160);
                return;
            }

            string tmpString = Transliteration.CyrillicToLatin(data.Message);
            if (Regex.IsMatch(tmpString, pattern))
            {
                data.Message = tmpString;
                data.AddMaxMessageLength(128);
                return;
            }

            throw new BadRequestException(
                406,
                "406 BAD_REQUEST MESSAGE_INVALID: Invite message should contain only characters in 7-bit GSM encoding or Cyrillic letters as well.");
        }
    }
}
