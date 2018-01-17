using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Email.API.Migrations
{
    public partial class UpdateTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_LoggedEmail_LoggedEmailId",
                table: "EmailContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoggedEmail",
                table: "LoggedEmail");

            migrationBuilder.RenameTable(
                name: "LoggedEmail",
                newName: "EmailLog");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailLog",
                table: "EmailLog",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_EmailLog_LoggedEmailId",
                table: "EmailContact",
                column: "LoggedEmailId",
                principalTable: "EmailLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_EmailLog_LoggedEmailId",
                table: "EmailContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailLog",
                table: "EmailLog");

            migrationBuilder.RenameTable(
                name: "EmailLog",
                newName: "LoggedEmail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoggedEmail",
                table: "LoggedEmail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_LoggedEmail_LoggedEmailId",
                table: "EmailContact",
                column: "LoggedEmailId",
                principalTable: "LoggedEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
