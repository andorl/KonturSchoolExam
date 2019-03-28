using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkManager.Migrations
{
    public partial class FullTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_UserId1",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_UserId1",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Payment",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Works",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Works",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Works",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Works",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WorkStatus",
                table: "Works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_UserId",
                table: "Works",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_UserId",
                table: "Works",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Works_AspNetUsers_UserId",
                table: "Works");

            migrationBuilder.DropIndex(
                name: "IX_Works_UserId",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Works");

            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "Works");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Works",
                newName: "UserId1");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Works",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId1",
                table: "Works",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Payment",
                table: "Works",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Works_UserId1",
                table: "Works",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Works_AspNetUsers_UserId1",
                table: "Works",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
