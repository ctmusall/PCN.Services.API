using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Phone.API.Migrations
{
    public partial class AddPhoneDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneContact",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneLogId = table.Column<Guid>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneContact_PhoneLog_PhoneLogId",
                        column: x => x.PhoneLogId,
                        principalTable: "PhoneLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneContact_PhoneLogId",
                table: "PhoneContact",
                column: "PhoneLogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneContact");

            migrationBuilder.DropTable(
                name: "PhoneLog");
        }
    }
}
