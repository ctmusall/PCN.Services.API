using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Email.API.Migrations
{
    public partial class ForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "LoggedEmail",
                newName: "LoggedEmailId");

            migrationBuilder.RenameColumn(
                name: "EmailLogId",
                table: "EmailContact",
                newName: "LoggedEmailId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoggedEmailId",
                table: "LoggedEmail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LoggedEmailId",
                table: "EmailContact",
                newName: "EmailLogId");
        }
    }
}
