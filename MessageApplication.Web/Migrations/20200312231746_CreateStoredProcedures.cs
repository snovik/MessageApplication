using Microsoft.EntityFrameworkCore.Migrations;

namespace MessageApplication.Web.Migrations
{
    public partial class CreateStoredProcedures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(CreateInviteStoredProcedureSql());
            migrationBuilder.Sql(CreateGetCountInvitationsStoredProcedureSql());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(DropInviteStoredProcedureSql());
            migrationBuilder.Sql(DropGetCountInvitationsStoredProcedureSql());
        }

        private string CreateInviteStoredProcedureSql()
        {
            return @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TYPE InvitationTableType as TABLE (Phone text, Author int);
GO

CREATE PROCEDURE invite (@table InvitationTableType READONLY) 
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO [dbo].Invitations (Phone, Author)
		SELECT tmp.Phone, tmp.Author
		FROM @table tmp
END
GO
";
        }

        private string CreateGetCountInvitationsStoredProcedureSql()
        {
            return @"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE getcountinvitations (@apiid int)
AS
BEGIN
	SET NOCOUNT ON;

	RETURN
		(SELECT COUNT(*) AS CTN
		FROM dbo.Invitations 
		WHERE CONVERT(DATE, dbo.Invitations.CreatedOn) = CONVERT(DATE, CURRENT_TIMESTAMP))

END
";
        }

        private string DropInviteStoredProcedureSql()
        {
            return @"
DROP PROCEDURE [dbo].[invite]
GO";
        }

        private string DropGetCountInvitationsStoredProcedureSql()
        {
            return @"
DROP PROCEDURE [dbo].[getcountinvitations]
GO";
        }
    }
}
