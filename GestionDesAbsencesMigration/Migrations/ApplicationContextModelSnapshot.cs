﻿// <auto-generated />
using System;
using GestionDesAbsencesMigration.Models.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestionDesAbsencesMigration.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClasseModule", b =>
                {
                    b.Property<int>("ClassesId")
                        .HasColumnType("int");

                    b.Property<int>("ModulesId")
                        .HasColumnType("int");

                    b.HasKey("ClassesId", "ModulesId");

                    b.HasIndex("ModulesId");

                    b.ToTable("ClasseModule");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Absence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Commentaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Details_Emploi_id")
                        .HasColumnType("int");

                    b.Property<bool>("EstPresent")
                        .HasColumnType("bit");

                    b.Property<int?>("Etudiant_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Details_Emploi_id");

                    b.HasIndex("Etudiant_id");

                    b.ToTable("Absences");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Administrateur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("Administrateurs");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Classe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("id_cycle")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("id_cycle");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Cycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cycles");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Details_Emploi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Emploi_Id")
                        .HasColumnType("int");

                    b.Property<int>("Module_Id")
                        .HasColumnType("int");

                    b.Property<int>("Seance_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Emploi_Id");

                    b.HasIndex("Module_Id");

                    b.HasIndex("Seance_Id");

                    b.ToTable("details_Emplois");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Emploi", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Emplois");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Etudiant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cne")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Id_classe")
                        .HasColumnType("int");

                    b.Property<int?>("Id_groupe")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_classe");

                    b.HasIndex("Id_groupe");

                    b.HasIndex("Role_Id");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Groupe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomModule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id_Professeur")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("id_Professeur");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Professeur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code_prof")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("Professeurs");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Seance", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HeurDebut")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HeurFin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Jour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Semaine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_debut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_fin")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("Semaines");
                });

            modelBuilder.Entity("ClasseModule", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Classe", null)
                        .WithMany()
                        .HasForeignKey("ClassesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDesAbsencesMigration.Models.Module", null)
                        .WithMany()
                        .HasForeignKey("ModulesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Absence", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Details_Emploi", "Details_Emploi")
                        .WithMany("Absences")
                        .HasForeignKey("Details_Emploi_id");

                    b.HasOne("GestionDesAbsencesMigration.Models.Etudiant", "Etudiant")
                        .WithMany("Absences")
                        .HasForeignKey("Etudiant_id");

                    b.Navigation("Details_Emploi");

                    b.Navigation("Etudiant");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Administrateur", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Role", "Role")
                        .WithMany("Administrateurs")
                        .HasForeignKey("Role_Id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Classe", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Cycle", "Cycle")
                        .WithMany("Classes")
                        .HasForeignKey("id_cycle");

                    b.Navigation("Cycle");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Details_Emploi", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Emploi", "Emploi")
                        .WithMany("Details_Emplois")
                        .HasForeignKey("Emploi_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDesAbsencesMigration.Models.Module", "Module")
                        .WithMany("Details_Emplois")
                        .HasForeignKey("Module_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionDesAbsencesMigration.Models.Seance", "Seance")
                        .WithMany("Details_Emplois")
                        .HasForeignKey("Seance_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Emploi");

                    b.Navigation("Module");

                    b.Navigation("Seance");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Emploi", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Semaine", "Semaine")
                        .WithOne("Emploi")
                        .HasForeignKey("GestionDesAbsencesMigration.Models.Emploi", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Semaine");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Etudiant", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Classe", "Classe")
                        .WithMany("Etudiants")
                        .HasForeignKey("Id_classe");

                    b.HasOne("GestionDesAbsencesMigration.Models.Groupe", "Groupe")
                        .WithMany("Etudiants")
                        .HasForeignKey("Id_groupe");

                    b.HasOne("GestionDesAbsencesMigration.Models.Role", "Role")
                        .WithMany("Etudiants")
                        .HasForeignKey("Role_Id");

                    b.Navigation("Classe");

                    b.Navigation("Groupe");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Module", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Professeur", "Professeur")
                        .WithMany("Modules")
                        .HasForeignKey("id_Professeur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professeur");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Professeur", b =>
                {
                    b.HasOne("GestionDesAbsencesMigration.Models.Role", "Role")
                        .WithMany("Professeurs")
                        .HasForeignKey("Role_Id");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Classe", b =>
                {
                    b.Navigation("Etudiants");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Cycle", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Details_Emploi", b =>
                {
                    b.Navigation("Absences");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Emploi", b =>
                {
                    b.Navigation("Details_Emplois");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Etudiant", b =>
                {
                    b.Navigation("Absences");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Groupe", b =>
                {
                    b.Navigation("Etudiants");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Module", b =>
                {
                    b.Navigation("Details_Emplois");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Professeur", b =>
                {
                    b.Navigation("Modules");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Role", b =>
                {
                    b.Navigation("Administrateurs");

                    b.Navigation("Etudiants");

                    b.Navigation("Professeurs");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Seance", b =>
                {
                    b.Navigation("Details_Emplois");
                });

            modelBuilder.Entity("GestionDesAbsencesMigration.Models.Semaine", b =>
                {
                    b.Navigation("Emploi");
                });
#pragma warning restore 612, 618
        }
    }
}
