using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Email.API.Migrations
{
    public partial class UpdateForeignKeyName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_EmailLog_LoggedEmailId",
                table: "EmailContact");

            migrationBuilder.RenameColumn(
                name: "LoggedEmailId",
                table: "EmailContact",
                newName: "EmailLogId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailContact_LoggedEmailId",
                table: "EmailContact",
                newName: "IX_EmailContact_EmailLogId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_EmailLog_EmailLogId",
                table: "EmailContact",
                column: "EmailLogId",
                principalTable: "EmailLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_EmailLog_EmailLogId",
                table: "EmailContact");

            migrationBuilder.RenameColumn(
                name: "EmailLogId",
                table: "EmailContact",
                newName: "LoggedEmailId");

            migrationBuilder.RenameIndex(
                name: "IX_EmailContact_EmailLogId",
                table: "EmailContact",
                newName: "IX_EmailContact_LoggedEmailId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_EmailLog_LoggedEmailId",
                table: "EmailContact",
                column: "LoggedEmailId",
                principalTable: "EmailLog",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
