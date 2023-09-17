using Microsoft.EntityFrameworkCore.Migrations;

namespace Innovative_Hospital_DAL.Migrations
{
    public partial class AddedSexToUserModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "MedicalCards");

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "MedicalCards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
