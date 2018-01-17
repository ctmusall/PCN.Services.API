using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Email.API.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlindCarbonCopies",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "CarbonCopy",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "FromAddress",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "ToAddress",
                table: "LoggedEmail");

            migrationBuilder.AddColumn<Guid>(
                name: "FromId",
                table: "LoggedEmail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "EmailContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    EmailLogId = table.Column<Guid>(nullable: true),
                    EmailLogId1 = table.Column<Guid>(nullable: true),
                    EmailLogId2 = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailContact_LoggedEmail_EmailLogId",
                        column: x => x.EmailLogId,
                        principalTable: "LoggedEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailContact_LoggedEmail_EmailLogId1",
                        column: x => x.EmailLogId1,
                        principalTable: "LoggedEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmailContact_LoggedEmail_EmailLogId2",
                        column: x => x.EmailLogId2,
                        principalTable: "LoggedEmail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoggedEmail_FromId",
                table: "LoggedEmail",
                column: "FromId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_EmailLogId",
                table: "EmailContact",
                column: "EmailLogId");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_EmailLogId1",
                table: "EmailContact",
                column: "EmailLogId1");

            migrationBuilder.CreateIndex(
                name: "IX_EmailContact_EmailLogId2",
                table: "EmailContact",
                column: "EmailLogId2");

            migrationBuilder.AddForeignKey(
                name: "FK_LoggedEmail_EmailContact_FromId",
                table: "LoggedEmail",
                column: "FromId",
                principalTable: "EmailContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoggedEmail_EmailContact_FromId",
                table: "LoggedEmail");

            migrationBuilder.DropTable(
                name: "EmailContact");

            migrationBuilder.DropIndex(
                name: "IX_LoggedEmail_FromId",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "LoggedEmail");

            migrationBuilder.AddColumn<string>(
                name: "BlindCarbonCopies",
                table: "LoggedEmail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarbonCopy",
                table: "LoggedEmail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FromAddress",
                table: "LoggedEmail",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ToAddress",
                table: "LoggedEmail",
                nullable: false,
                defaultValue: "");
        }
    }
}
