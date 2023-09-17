using Microsoft.EntityFrameworkCore.Migrations;

namespace Innovative_Hospital_DAL.Migrations
{
    public partial class RemovePatientIdInThePatient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalCards_AspNetUsers_PatientId",
                table: "MedicalCards");

            migrationBuilder.DropIndex(
                name: "IX_MedicalCards_PatientId",
                table: "MedicalCards");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MedicalCardId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "MedicalCards");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicalCardId",
                table: "AspNetUsers",
                column: "MedicalCardId",
                unique: true,
                filter: "[MedicalCardId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MedicalCardId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "MedicalCards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCards_PatientId",
                table: "MedicalCards",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MedicalCardId",
                table: "AspNetUsers",
                column: "MedicalCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalCards_AspNetUsers_PatientId",
                table: "MedicalCards",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
