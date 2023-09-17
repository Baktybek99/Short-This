using Microsoft.EntityFrameworkCore.Migrations;

namespace Innovative_Hospital_DAL.Migrations
{
    public partial class AddNewTablePatientDishcarge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientDischarge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountingId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Disease = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNamePatient = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullNameDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecommendationsForDoctor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDischarge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDischarge_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatientDischarge_PatientAccountings_AccountingId",
                        column: x => x.AccountingId,
                        principalTable: "PatientAccountings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientDischarge_AccountingId",
                table: "PatientDischarge",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDischarge_DoctorId",
                table: "PatientDischarge",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientDischarge");
        }
    }
}
