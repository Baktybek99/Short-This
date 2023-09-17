using Microsoft.EntityFrameworkCore.Migrations;

namespace Innovative_Hospital_DAL.Migrations
{
    public partial class addvirtual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientDischarge_AccountingId",
                table: "PatientDischarge");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDischarge_AccountingId",
                table: "PatientDischarge",
                column: "AccountingId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PatientDischarge_AccountingId",
                table: "PatientDischarge");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDischarge_AccountingId",
                table: "PatientDischarge",
                column: "AccountingId");
        }
    }
}
