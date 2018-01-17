using Microsoft.EntityFrameworkCore.Migrations;

namespace Email.API.Migrations
{
    public partial class TestForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoggedEmailId",
                table: "LoggedEmail",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ContactType",
                table: "EmailContact",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_LoggedEmailId",
                table: "EmailContact",
                column: "LoggedEmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_LoggedEmail_LoggedEmailId",
                table: "EmailContact",
                column: "LoggedEmailId",
                principalTable: "LoggedEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_LoggedEmail_LoggedEmailId",
                table: "EmailContact");

            migrationBuilder.DropIndex(
                name: "IX_EmailContact_LoggedEmailId",
                table: "EmailContact");

            migrationBuilder.DropColumn(
                name: "ContactType",
                table: "EmailContact");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoggedEmail",
                newName: "LoggedEmailId");
        }
    }
}
