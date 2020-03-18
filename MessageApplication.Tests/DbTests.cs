using System.Collections.Generic;
using System.Linq;
using MessageApplication.Web.Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MessageApplication.Tests
{
    public class DbTests
    {
        [Fact]
        public void DbGetAllTest()
        {
            var options = new DbContextOptionsBuilder<InvitationsDbContext>()
                .UseInMemoryDatabase(databaseName: "DbGetAllTestsDatabase")
                .Options;

            using (var context = new InvitationsDbContext(options))
            {
                context.Invitations.Add(new Invitation { Phone = "79998887766", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887765", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887764", Author = 4 });
                context.SaveChanges();
            }

            using (var context = new InvitationsDbContext(options))
            {
                var invitationRepository = new InvitationRepository(context);
                List<Invitation> list = invitationRepository.GetAll();

                Assert.Equal(3, list.Count);
            }
        }

        [Fact]
        public void DbGetTest()
        {
            var options = new DbContextOptionsBuilder<InvitationsDbContext>()
                .UseInMemoryDatabase(databaseName: "DbGetTestDatabase")
                .Options;

            using (var context = new InvitationsDbContext(options))
            {
                context.Invitations.Add(new Invitation { Phone = "79998887766", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887765", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887764", Author = 4 });
                context.SaveChanges();
            }

            using (var context = new InvitationsDbContext(options))
            {
                var invitationRepository = new InvitationRepository(context);
                Invitation invitation = invitationRepository.Get(1);

                Assert.NotNull(invitation);
            }
        }

        [Fact]
        public void DbAddTest()
        {
            var options = new DbContextOptionsBuilder<InvitationsDbContext>()
                .UseInMemoryDatabase(databaseName: "DbAddTestDatabase")
                .Options;

            using (var context = new InvitationsDbContext(options))
            {
                context.Invitations.Add(new Invitation { Phone = "79998887766", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887765", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887764", Author = 4 });
                context.SaveChanges();
            }

            using (var context = new InvitationsDbContext(options))
            {
                var invitationRepository = new InvitationRepository(context);

                var invitation = new Invitation {Phone = "78888888888", Author = 4};

                Invitation addedInvitation = invitationRepository.Add(invitation);

                Assert.Equal(4, context.Invitations.Count());
            }
        }

        [Fact]
        public void DbDeleteTest()
        {
            var options = new DbContextOptionsBuilder<InvitationsDbContext>()
                .UseInMemoryDatabase(databaseName: "DbDeleteTestDatabase")
                .Options;

            using (var context = new InvitationsDbContext(options))
            {
                context.Invitations.Add(new Invitation { Phone = "79998887766", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887765", Author = 4 });
                context.Invitations.Add(new Invitation { Phone = "79998887764", Author = 4 });
                context.SaveChanges();
            }

            using (var context = new InvitationsDbContext(options))
            {
                var invitationRepository = new InvitationRepository(context);

                var invitation = new Invitation { Phone = "78888888888", Author = 4 };

                Invitation addedInvitation = invitationRepository.Delete(2);

                Assert.True(context.Invitations.Count() == 2 && invitation != null);
            }
        }
    }
}
