using Microsoft.EntityFrameworkCore.Migrations;

namespace Innovative_Hospital_DAL.Migrations
{
    public partial class EditMedicalCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Disability",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HomePhoneNumber",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlaceOfWork",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PositionAtWork",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Profession",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidentialAddress",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkPhoneNumber",
                table: "MedicalCards",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disability",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "District",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "HomePhoneNumber",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "PlaceOfWork",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "PositionAtWork",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "Profession",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "ResidentialAddress",
                table: "MedicalCards");

            migrationBuilder.DropColumn(
                name: "WorkPhoneNumber",
                table: "MedicalCards");
        }
    }
}
