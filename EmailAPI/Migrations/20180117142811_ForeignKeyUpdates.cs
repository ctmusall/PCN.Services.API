using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Email.API.Migrations
{
    public partial class ForeignKeyUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_LoggedEmail_EmailLogId",
                table: "EmailContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_LoggedEmail_EmailLogId1",
                table: "EmailContact");

            migrationBuilder.DropForeignKey(
                name: "FK_EmailContact_LoggedEmail_EmailLogId2",
                table: "EmailContact");

            migrationBuilder.DropForeignKey(
                name: "FK_LoggedEmail_EmailContact_FromId",
                table: "LoggedEmail");

            migrationBuilder.DropIndex(
                name: "IX_LoggedEmail_FromId",
                table: "LoggedEmail");

            migrationBuilder.DropIndex(
                name: "IX_EmailContact_EmailLogId",
                table: "EmailContact");

            migrationBuilder.DropIndex(
                name: "IX_EmailContact_EmailLogId1",
                table: "EmailContact");

            migrationBuilder.DropIndex(
                name: "IX_EmailContact_EmailLogId2",
                table: "EmailContact");

            migrationBuilder.DropColumn(
                name: "FromId",
                table: "LoggedEmail");

            migrationBuilder.DropColumn(
                name: "EmailLogId1",
                table: "EmailContact");

            migrationBuilder.DropColumn(
                name: "EmailLogId2",
                table: "EmailContact");

            migrationBuilder.AlterColumn<Guid>(
                name: "EmailLogId",
                table: "EmailContact",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FromId",
                table: "LoggedEmail",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "EmailLogId",
                table: "EmailContact",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "EmailLogId1",
                table: "EmailContact",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmailLogId2",
                table: "EmailContact",
                nullable: true);

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
                name: "FK_EmailContact_LoggedEmail_EmailLogId",
                table: "EmailContact",
                column: "EmailLogId",
                principalTable: "LoggedEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_LoggedEmail_EmailLogId1",
                table: "EmailContact",
                column: "EmailLogId1",
                principalTable: "LoggedEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmailContact_LoggedEmail_EmailLogId2",
                table: "EmailContact",
                column: "EmailLogId2",
                principalTable: "LoggedEmail",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoggedEmail_EmailContact_FromId",
                table: "LoggedEmail",
                column: "FromId",
                principalTable: "EmailContact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
