using System;
using MessageApplication.Web.Domain;
using MessageApplication.Web.Exceptions;
using MessageApplication.Web.Message;
using MessageApplication.Web.ValidationRules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MessageApplication.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageSenderController : ControllerBase
    {
        private readonly ILogger<MessageSenderController> logger;
        private readonly IInvitationRepository invitationRepository;
        private readonly IMessage message;

        public MessageSenderController(ILogger<MessageSenderController> logger, IInvitationRepository invitationRepository, IMessage message)
        {
            this.logger = logger;
            this.invitationRepository = invitationRepository;
            this.message = message;
        }

        [HttpPost]
        public void SendInvites(InviteData inviteData)
        {
            try
            {
                int countInvitationsForDay = invitationRepository.GetCountInvitations(4);

                var validationData = new ValidationData()
                    .AddNumbers(inviteData.Numbers)
                    .AddMessage(inviteData.Message)
                    .AddPermissibleNumberOfInvitations(countInvitationsForDay, 128)
                    .AddRequiredAmountInvitationsPerCallRule(16)
                    .AddMaxMessageLength(128);

                var validation = new Validation();
                validation.ValidateRules(validationData);

                invitationRepository.Invite(7, inviteData.Numbers);

                message.Send(validationData.Message);
            }
            catch (BadRequestException e)
            {
                logger.LogError($"{e.Code} {e.Message}");
                throw;
            }
            catch (Exception e)
            {
                string errorMessage = $"500 INTERNAL SMS_SERVICE: {e.Message}";
                logger.LogError(errorMessage);
                throw new InternalSmsServiceException(500, errorMessage);
            }
        }
    }
}