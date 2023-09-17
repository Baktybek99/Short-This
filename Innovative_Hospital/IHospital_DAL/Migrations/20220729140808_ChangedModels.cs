using Microsoft.EntityFrameworkCore.Migrations;

namespace Innovative_Hospital_DAL.Migrations
{
    public partial class ChangedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskOfJuniorNurses_AspNetUsers_PatientId",
                table: "TaskOfJuniorNurses");

            migrationBuilder.DropIndex(
                name: "IX_TaskOfJuniorNurses_PatientId",
                table: "TaskOfJuniorNurses");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "TaskOfJuniorNurses");

            migrationBuilder.RenameColumn(
                name: "Referral_Tests",
                table: "DoctorInstructions",
                newName: "Analyzes");

            migrationBuilder.AddColumn<int>(
                name: "RoomNumber",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "PatientAccountings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "PatientAccountings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccountings_DepartamentId",
                table: "PatientAccountings",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientAccountings_RoomId",
                table: "PatientAccountings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAccountings_Departaments_DepartamentId",
                table: "PatientAccountings",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientAccountings_Rooms_RoomId",
                table: "PatientAccountings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientAccountings_Departaments_DepartamentId",
                table: "PatientAccountings");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientAccountings_Rooms_RoomId",
                table: "PatientAccountings");

            migrationBuilder.DropIndex(
                name: "IX_PatientAccountings_DepartamentId",
                table: "PatientAccountings");

            migrationBuilder.DropIndex(
                name: "IX_PatientAccountings_RoomId",
                table: "PatientAccountings");

            migrationBuilder.DropColumn(
                name: "RoomNumber",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "PatientAccountings");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "PatientAccountings");

            migrationBuilder.RenameColumn(
                name: "Analyzes",
                table: "DoctorInstructions",
                newName: "Referral_Tests");

            migrationBuilder.AddColumn<string>(
                name: "PatientId",
                table: "TaskOfJuniorNurses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaskOfJuniorNurses_PatientId",
                table: "TaskOfJuniorNurses",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskOfJuniorNurses_AspNetUsers_PatientId",
                table: "TaskOfJuniorNurses",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
