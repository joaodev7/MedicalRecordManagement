using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordManagement.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MedicalRecordId",
                table: "Users",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MedicalRecordId",
                table: "Users",
                column: "MedicalRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_MedicalRecords_MedicalRecordId",
                table: "Users",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_MedicalRecords_MedicalRecordId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MedicalRecordId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "Users");
        }
    }
}
