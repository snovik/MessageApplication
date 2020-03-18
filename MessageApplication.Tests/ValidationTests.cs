using System.Collections.Generic;
using System.Text;
using MessageApplication.Web.Exceptions;
using MessageApplication.Web.ValidationRules;
using Xunit;

namespace MessageApplication.Tests
{
    public class ValidationTests
    {
        private ValidationData ValidationDataBuild(string[] numbers, string message, int permissibleNumberOfInvitations, int tresholdPermissibleNumberOfInvitations, int requiredAmountPerCall, int maxMessageLength)
        {
            var validationData = new ValidationData
            {
                Numbers = numbers,
                Message = message,
                PermissibleNumberOfInvitations = permissibleNumberOfInvitations,
                TreshhsoldPermissibleNumberOfInvitations = tresholdPermissibleNumberOfInvitations,
                RequiredAmountInvitationsPerCallRule = requiredAmountPerCall,
                MaxMessageLength = maxMessageLength
            };

            return validationData;
        }

        [Fact]
        public void ValidateRulesTest()
        {
            string[] numbers = { "79999999999", "79999999998", "79999999997" };
            string message = "Hello World";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers, 
                message, 
                permissibleNumberOfInvitations, 
                tresholdPermissibleNumberOfInvitations, 
                requiredAmountPerCall, 
                maxMessageLength);

            var validation = new Validation();
            validation.ValidateRules(validationData);
        }

        [Fact]
        public void ValidationMessageEmpty()
        {
            string[] numbers = { "79999999999", "79999999998", "79999999997" };
            string message = string.Empty;
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 405 && 
                        exception.Message == "405 BAD_REQUEST MESSAGE_EMPTY: Invite message is missing.");
        }

        [Fact]
        public void ValidationNumbersEmpty()
        {
            string[] numbers = { };
            string message = "Hello World";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 401 && 
                        exception.Message == "401 AD_REQUEST PHONE_NUMBERS_EMPTY: Phone_numbers is missing.");
        }

        [Fact]
        public void ValidationDuplicate()
        {
            string[] numbers = { "79999999999", "79999999999", "79999999997" };
            string message = "Hello World";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 404 && 
                        exception.Message == "404 BAD_REQUEST PHONE_NUMBERS_INVALID: Duplicate numbers detected.");
        }

        [Fact]
        public void ValidationNumberOfInvitations()
        {
            List<string> numbers = new List<string>();

            long number = 79999990000;
            for (int i = 0; i < 130; i++)
            {
                numbers.Add((number++).ToString());
            }

            string message = "Hello World";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers.ToArray(),
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 403 && 
                        exception.Message == "403 BAD_REQUEST PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 128 per day.");
        }

        [Fact]
        public void ValidationRequiredAmountInvitationsPerCall()
        {
            List<string> numbers = new List<string>();

            long number = 79999990000;
            for (int i = 0; i < 18; i++)
            {
                numbers.Add((number++).ToString());
            }

            string message = "Hello World";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers.ToArray(),
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 402 && 
                        exception.Message == "402 BAD_REQUEST PHONE_NUMBERS_INVALID: Too much phone numbers, should be less or equal to 16 per request.");
        }

        [Fact]
        public void ValidationInternationalFormat()
        {
            string[] numbers = { "79999999999", "+79999999998", "79999999997" };
            string message = "Hello World";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 400 && 
                        exception.Message == "400 BAD_REQUEST PHONE_NUMBERS_INVALID: One or several phone numbers do not match with international format.");
        }

        [Fact]
        public void ValidationMaxMessageLength()
        {
            string[] numbers = { "79999999999", "79999999998", "79999999997" };
            string message =
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 407 && 
                exception.Message == "407 BAD_REQUEST MESSAGE_INVALID: Invite message too long, should be less or equal to 128 characters of 7-bit GSM charset.");
        }
        
        [Fact]
        public void ValidationGsmFormatWithoutError()
        {
            string[] numbers = { "79999999999", "79999999998", "79999999997" };
            string message =
                "Привет мир. 2020. 123АнглLaЫRR";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            validation.ValidateRules(validationData);

            Assert.Equal(
                validationData.Message, 
                "Privet mir. 2020. 123AnglLaYRR");
        }

        [Fact]
        public void ValidationGsmFormat()
        {
            string[] numbers = { "79999999999", "79999999998", "79999999997" };
            string message =
                "爱Привет мир. 2020. 123АнглLaЫRR";
            int permissibleNumberOfInvitations = 3;
            int tresholdPermissibleNumberOfInvitations = 128;
            int requiredAmountPerCall = 16;
            int maxMessageLength = 160;

            ValidationData validationData = ValidationDataBuild(numbers,
                message,
                permissibleNumberOfInvitations,
                tresholdPermissibleNumberOfInvitations,
                requiredAmountPerCall,
                maxMessageLength);

            var validation = new Validation();

            var exception = Assert.Throws<BadRequestException>(() => validation.ValidateRules(validationData));

            Assert.True(
                exception.Code == 406 && 
                exception.Message == "406 BAD_REQUEST MESSAGE_INVALID: Invite message should contain only characters in 7-bit GSM encoding or Cyrillic letters as well.");
        }
    }
}
