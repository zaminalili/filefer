using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace filefer.Data.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "UploadedFiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_UserId",
                table: "UploadedFiles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedFiles_AspNetUsers_UserId",
                table: "UploadedFiles");

            migrationBuilder.DropIndex(
                name: "IX_UploadedFiles_UserId",
                table: "UploadedFiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UploadedFiles");
        }
    }
}
