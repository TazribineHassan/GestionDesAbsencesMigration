using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestionDesAbsencesMigration.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeurDebut = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeurFin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Semaines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date_debut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_fin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semaines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_cycle = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classes_Cycles_id_cycle",
                        column: x => x.id_cycle,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Administrateurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrateurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrateurs_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professeurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code_prof = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professeurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professeurs_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emplois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Semaine_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emplois_Semaines_Semaine_Id",
                        column: x => x.Semaine_Id,
                        principalTable: "Semaines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role_Id = table.Column<int>(type: "int", nullable: true),
                    Id_groupe = table.Column<int>(type: "int", nullable: true),
                    Id_classe = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_Id_classe",
                        column: x => x.Id_classe,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etudiants_Groupes_Id_groupe",
                        column: x => x.Id_groupe,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Etudiants_Roles_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomModule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    id_Professeur = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modules_Professeurs_id_Professeur",
                        column: x => x.id_Professeur,
                        principalTable: "Professeurs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClasseModule",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "int", nullable: false),
                    ModulesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasseModule", x => new { x.ClassesId, x.ModulesId });
                    table.ForeignKey(
                        name: "FK_ClasseModule_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClasseModule_Modules_ModulesId",
                        column: x => x.ModulesId,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "details_Emplois",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emploi_Id = table.Column<int>(type: "int", nullable: false),
                    Seance_Id = table.Column<int>(type: "int", nullable: false),
                    Module_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_details_Emplois", x => x.Id);
                    table.ForeignKey(
                        name: "FK_details_Emplois_Emplois_Emploi_Id",
                        column: x => x.Emploi_Id,
                        principalTable: "Emplois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_details_Emplois_Modules_Module_Id",
                        column: x => x.Module_Id,
                        principalTable: "Modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_details_Emplois_Seances_Seance_Id",
                        column: x => x.Seance_Id,
                        principalTable: "Seances",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Absences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstPresent = table.Column<bool>(type: "bit", nullable: false),
                    Commentaire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etudiant_id = table.Column<int>(type: "int", nullable: true),
                    Details_Emploi_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Absences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Absences_details_Emplois_Details_Emploi_id",
                        column: x => x.Details_Emploi_id,
                        principalTable: "details_Emplois",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Absences_Etudiants_Etudiant_id",
                        column: x => x.Etudiant_id,
                        principalTable: "Etudiants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "CP" },
                    { 2, "CI" }
                });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 1, "Groupe 1" },
                    { 2, "Groupe 2" },
                    { 3, "Groupe 3" },
                    { 4, "Groupe 4" },
                    { 5, "Groupe 5" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 3, "etudiant" },
                    { 2, "professeur" },
                    { 1, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "id", "HeurDebut", "HeurFin", "Jour" },
                values: new object[,]
                {
                    { 20, "16:00", "18:00", "Jeudi" },
                    { 21, "08:00", "10:00", "Vendredi" },
                    { 22, "10:00", "12:00", "Vendredi" },
                    { 23, "12:00", "14:00", "Vendredi" },
                    { 24, "14:00", "16:00", "Vendredi" },
                    { 25, "16:00", "18:00", "Vendredi" },
                    { 26, "08:00", "10:00", "Samedi" },
                    { 31, "08:00", "10:00", "Dimanche" },
                    { 28, "12:00", "14:00", "Samedi" },
                    { 29, "14:00", "16:00", "Samedi" },
                    { 30, "16:00", "18:00", "Samedi" },
                    { 19, "14:00", "16:00", "Jeudi" },
                    { 32, "10:00", "12:00", "Dimanche" },
                    { 33, "12:00", "14:00", "Dimanche" },
                    { 27, "10:00", "12:00", "Samedi" },
                    { 18, "12:00", "14:00", "Jeudi" },
                    { 13, "12:00", "14:00", "Mercredi" },
                    { 16, "08:00", "10:00", "Jeudi" },
                    { 1, "08:00", "10:00", "Lundi" },
                    { 2, "10:00", "12:00", "Lundi" },
                    { 3, "12:00", "14:00", "Lundi" },
                    { 4, "14:00", "16:00", "Lundi" },
                    { 5, "16:00", "18:00", "Lundi" },
                    { 6, "08:00", "10:00", "Mardi" },
                    { 7, "10:00", "12:00", "Mardi" },
                    { 8, "12:00", "14:00", "Mardi" },
                    { 9, "14:00", "16:00", "Mardi" },
                    { 10, "16:00", "18:00", "Mardi" },
                    { 11, "08:00", "10:00", "Mercredi" },
                    { 12, "10:00", "12:00", "Mercredi" },
                    { 34, "14:00", "16:00", "Dimanche" },
                    { 14, "14:00", "16:00", "Mercredi" }
                });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "id", "HeurDebut", "HeurFin", "Jour" },
                values: new object[] { 15, "16:00", "18:00", "Mercredi" });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "id", "HeurDebut", "HeurFin", "Jour" },
                values: new object[] { 17, "10:00", "12:00", "Jeudi" });

            migrationBuilder.InsertData(
                table: "Seances",
                columns: new[] { "id", "HeurDebut", "HeurFin", "Jour" },
                values: new object[] { 35, "16:00", "18:00", "Dimanche" });

            migrationBuilder.InsertData(
                table: "Administrateurs",
                columns: new[] { "Id", "Email", "Nom", "Password", "Prenom", "Role_Id" },
                values: new object[] { 1, "admin@gmail.com", "Admin", "YWRtaW5Dc3JzeDgmYW1wO0dvRDN5dEBZSmhTQ2JHUTF1", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Absences_Details_Emploi_id",
                table: "Absences",
                column: "Details_Emploi_id");

            migrationBuilder.CreateIndex(
                name: "IX_Absences_Etudiant_id",
                table: "Absences",
                column: "Etudiant_id");

            migrationBuilder.CreateIndex(
                name: "IX_Administrateurs_Role_Id",
                table: "Administrateurs",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClasseModule_ModulesId",
                table: "ClasseModule",
                column: "ModulesId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_id_cycle",
                table: "Classes",
                column: "id_cycle");

            migrationBuilder.CreateIndex(
                name: "IX_details_Emplois_Emploi_Id",
                table: "details_Emplois",
                column: "Emploi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_details_Emplois_Module_Id",
                table: "details_Emplois",
                column: "Module_Id");

            migrationBuilder.CreateIndex(
                name: "IX_details_Emplois_Seance_Id",
                table: "details_Emplois",
                column: "Seance_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Emplois_Semaine_Id",
                table: "Emplois",
                column: "Semaine_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_Id_classe",
                table: "Etudiants",
                column: "Id_classe");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_Id_groupe",
                table: "Etudiants",
                column: "Id_groupe");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_Role_Id",
                table: "Etudiants",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Modules_id_Professeur",
                table: "Modules",
                column: "id_Professeur");

            migrationBuilder.CreateIndex(
                name: "IX_Professeurs_Role_Id",
                table: "Professeurs",
                column: "Role_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Absences");

            migrationBuilder.DropTable(
                name: "Administrateurs");

            migrationBuilder.DropTable(
                name: "ClasseModule");

            migrationBuilder.DropTable(
                name: "details_Emplois");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Emplois");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Semaines");

            migrationBuilder.DropTable(
                name: "Professeurs");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
