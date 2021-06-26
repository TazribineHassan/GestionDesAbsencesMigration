using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDesAbsencesMigration.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Professeurs_id_Professeur",
                table: "Modules");

            migrationBuilder.AlterColumn<int>(
                name: "id_Professeur",
                table: "Modules",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Professeurs_id_Professeur",
                table: "Modules",
                column: "id_Professeur",
                principalTable: "Professeurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Modules_Professeurs_id_Professeur",
                table: "Modules");

            migrationBuilder.AlterColumn<int>(
                name: "id_Professeur",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Modules_Professeurs_id_Professeur",
                table: "Modules",
                column: "id_Professeur",
                principalTable: "Professeurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
