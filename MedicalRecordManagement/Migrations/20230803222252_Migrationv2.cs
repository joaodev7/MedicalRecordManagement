using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordManagement.Migrations
{
    /// <inheritdoc />
    public partial class Migrationv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "TaxNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaxNumber",
                table: "Users",
                newName: "Username");
        }
    }
}
