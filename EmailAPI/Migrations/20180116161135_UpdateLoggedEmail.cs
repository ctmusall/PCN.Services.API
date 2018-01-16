using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Email.API.Migrations
{
    public partial class UpdateLoggedEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BlindCarbonCopies",
                table: "LoggedEmail",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarbonCopy",
                table: "LoggedEmail",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBodyHtml",
                table: "LoggedEmail",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "LoggedEmail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlindCarbonCopies",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "CarbonCopy",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "IsBodyHtml",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "LoggedEmail");
        }
    }
}
