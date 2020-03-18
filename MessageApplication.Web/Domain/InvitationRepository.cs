using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MessageApplication.Web.Domain
{
    public class InvitationRepository : IInvitationRepository
    {
        private readonly InvitationsDbContext context;

        public InvitationRepository(InvitationsDbContext context)
        {
            this.context = context;
        }

        public List<Invitation> GetAll()
        {
            return context.Invitations.ToList();
        }

        public Invitation Add(Invitation invitation)
        {
            context.Invitations.Add(invitation);
            context.SaveChanges();
            return invitation;
        }

        public Invitation Delete(int id)
        {
            var entity = context.Invitations.Find(id);
            if (entity == null)
            {
                return null;
            }

            context.Invitations.Remove(entity);
            context.SaveChanges();

            return entity;
        }

        public Invitation Get(int id)
        {
            return context.Invitations.Find(id);
        }

        public int GetCountInvitations(int apiId)
        {
            SqlParameter[] @params =
            {
                new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
                new SqlParameter("@apiid", SqlDbType.Int) { Direction = ParameterDirection.Input, Value = apiId }
            };

            var query = context.Database.ExecuteSqlRaw("exec @returnVal = getcountinvitations @apiid", @params[0], @params[1]);

            return (int)@params[0].Value;
        }

        public void Invite(int userId, string[] numbers)
        {
            DataTable dataTable = ConvertToDataTable(userId, numbers);
            var parameter = new SqlParameter("@table", SqlDbType.Structured)
            {
                TypeName = dataTable.TableName, Value = dataTable
            };

            var query = context.Database.ExecuteSqlRaw("invite @table", parameter);
        }

        private static DataTable ConvertToDataTable(int authorId, string[] numbers)
        {
            var dataTable = new DataTable {TableName = "InvitationTableType"};

            dataTable.Columns.Add("Phone", typeof(string));
            dataTable.Columns.Add("Author", typeof(int));

            foreach (var number in numbers)
            {
                var row = dataTable.NewRow();
                row["Phone"] = number;
                row["Author"] = authorId;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
