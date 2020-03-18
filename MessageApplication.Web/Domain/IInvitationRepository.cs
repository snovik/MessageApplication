using System.Collections.Generic;

namespace MessageApplication.Web.Domain
{
    public interface IInvitationRepository
    {
        List<Invitation> GetAll();

        Invitation Add(Invitation invitation);

        Invitation Delete(int id);

        Invitation Get(int id);

        int GetCountInvitations(int apiId);

        void Invite(int userId, string[] numbers);
    }
}
