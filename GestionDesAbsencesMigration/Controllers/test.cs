using GestionDesAbsencesMigration.Models.Context;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GestionDesAbsencesMigration.Controllers
{
    public class testController : Controller
    {
        private ApplicationContext db;
        private IProfesseurService professeurService;
        private ISemaineService semaineService;
        private ApplicationContext context;
        public testController(ApplicationContext context, ApplicationContext applicationContext, IProfesseurService professeurService, ISemaineService semaineService)
        {
            this.db = applicationContext;
            this.professeurService = professeurService;
            this.semaineService = semaineService;
            this.context = context;
        }


        public string test1()
        {

            var result3 = professeurService.GetStudentsList(1, 1, 1);
            var str = JsonConvert.SerializeObject(result3, Formatting.Indented,
                                                    new JsonSerializerSettings
                                                    {
                                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                    });
            return str;
        }        
        
        public string testSeance()
        {

            var result3 = professeurService.GetSeancesForProf(2);
            var str = JsonConvert.SerializeObject(result3, Formatting.Indented,
                                                    new JsonSerializerSettings
                                                    {
                                                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                                                    });
            return str;
        }


        public JsonResult test2()
        {
            var x = context.Cycles.Include(c => c.Classes).Select(c => new { nom_cycle = c.Nom, classes = c.Classes });
            return Json(x);
        }
        public JsonResult test3()
        {

            string[] jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };

            //get the curren semaine 
            DateTime aujourdhui = DateTime.Parse("15/5/2021");
            Semaine semaine_courante;
            semaine_courante = context.Semaines.Where(s => s.Date_debut.CompareTo(aujourdhui) <= 0
                                                          && s.Date_fin.CompareTo(aujourdhui) >= 0).FirstOrDefault();

            // get all module absences and cycle names for today
            var absCounts = context.Modules.Include(mod => mod.Details_Emplois).ThenInclude(demp => demp.Absences)
                                          .Include(mod => mod.Details_Emplois).ThenInclude(demp => demp.Emploi)
                                                                              .ThenInclude(emp => emp.Semaine)
                                          .Include(mod => mod.Classes)
                                          .Select(mod => new {
                                              classes = mod.Classes.Select(classe => classe.Nom).ToList(),
                                              module = mod.NomModule,
                                              abs_count = mod.Details_Emplois.Where(emp => emp.Emploi.Semaine.Id == semaine_courante.Id)
                                                                             .Select(emp => emp.Absences.Where(abs => !abs.EstPresent)
                                                                             .Count()).ToList()
                                          }).ToList();

            //generate a dictionary {nom_cycle => absence_count}
            var result = new Dictionary<string, int>();
            foreach (var absence in absCounts)
            {
                foreach (var classe in absence.classes)
                {
                    if (result.Keys.Contains(classe))
                    {
                        result[classe] += absence.abs_count.Sum();
                    }
                    else
                    {
                        result.Add(classe, absence.abs_count.Sum());
                    }

                }
            }
            return Json(result);
        }

        public string testData()
        {
            {

                // La table de classe
                var classes = new List<Classe>();
                classes.Add(new Classe() { Id = 0, Nom = "4 GINFO", id_cycle = 2 });
                classes.Add(new Classe() { Id = 0, Nom = "3 GTR", id_cycle = 2 });
                classes.Add(new Classe() { Id = 0, Nom = "CP 1", id_cycle = 1 });
                db.Classes.AddRange(classes);
                db.SaveChanges();


                // La table de l'etudiant
                var etudiants = new List<Etudiant>();
                for (int i = 0; i < 100; i++)
                    if (i < 50)
                    {
                        etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i, Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i + "@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 1, Id_classe = 1, Role_Id = 3 });
                    }
                    else
                    {
                        etudiants.Add(new Etudiant() { Id = 0, Cne = "D132468" + i, Nom = "TAZRIBINE" + i + "", Prenom = "Hassan" + i + "", Email = "hassan" + i + "@gmail.com", Password = Encryption.Encrypt("etudiant"), Id_groupe = 2, Id_classe = 2, Role_Id = 3 });
                    }

                db.Etudiants.AddRange(etudiants);
                db.SaveChanges();

                // La table des profs
                var professeurs = new List<Professeur>();
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "OUARRACHI", Prenom = "Maryem", Email = "maryem@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 1", Prenom = "prof", Email = "prof1@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                professeurs.Add(new Professeur() { Id = 0, Code_prof = "UYGGHJ09UU9007", Nom = "PROF 2", Prenom = "prof", Email = "prof2@gmail.com", Password = Encryption.Encrypt("professeur"), Role_Id = 2 });
                db.Professeurs.AddRange(professeurs);
                db.SaveChanges();

                // La table des modules
                var modules = new List<Module>();
                modules.Add(new Module() { Id = 0, NomModule = "C#", id_Professeur = 1 });

                modules.Add(new Module() { Id = 0, NomModule = "Module x", id_Professeur = 2 });

                modules.Add(new Module() { Id = 0, NomModule = "Java", id_Professeur = 1 });

                db.Modules.AddRange(modules);
                db.SaveChanges();

                //attach modules to classes
                //attach model to class 1
                db.Modules.Find(1).Classes.Add(db.Classes.Find(1));
                // attach model to class 1
                db.Modules.Find(2).Classes.Add(db.Classes.Find(1));
                //attach model to class 2
                db.Modules.Find(3).Classes.Add(db.Classes.Find(2));
                db.SaveChanges();

                // La tables des semaines
                var semaines = new List<Semaine>();
                semaines.Add(new Semaine() { Id = 0, Code = "S1", Date_debut = DateTime.Parse("01/05/2021"), Date_fin = DateTime.Parse("07/05/2021") });
                semaines.Add(new Semaine() { Id = 0, Code = "S1", Date_debut = DateTime.Parse("08/05/2021"), Date_fin = DateTime.Parse("14/05/2021") });
                semaines.Add(new Semaine() { Id = 0, Code = "S1", Date_debut = DateTime.Parse("15/05/2021"), Date_fin = DateTime.Parse("21/05/2021") });
                db.Semaines.AddRange(semaines);
                db.SaveChanges();

                // La table des emplois
                db.Emplois.Add(new Emploi() { Semaine_Id = 1 });
                db.SaveChanges();

                // La table des details d'un emploi
                var details = new List<Details_Emploi>();
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 1, Seance_Id = 1 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 3, Seance_Id = 2 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 2, Seance_Id = 4 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 1, Seance_Id = 5 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 2, Seance_Id = 6 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 2, Seance_Id = 7 });
                details.Add(new Details_Emploi() { Id = 0, Emploi_Id = 1, Module_Id = 1, Seance_Id = 8 });
                db.details_Emplois.AddRange(details);
                db.SaveChanges();


            }
            return "well done";
        }
    }

}
