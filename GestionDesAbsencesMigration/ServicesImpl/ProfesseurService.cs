using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class ProfesseurService : IProfesseurService
    {
        private ApplicationContext context { get; }

        public ProfesseurService(ApplicationContext context)
        {
            this.context = context;
        }

        public void deleteProfesseur(Professeur p)
        {
            Professeur prof = context.Professeurs.Find(p.Id);
            context.Professeurs.Remove(prof);
            context.SaveChanges();
        }

        public IEnumerable<Professeur> FindAll()
        {
            return (IEnumerable<Professeur>)context.Professeurs.ToList();
        }

        public Professeur GetProfesseurByEmail(string email)
        {
            return context.Professeurs.Include(prof => prof.Role).FirstOrDefault(prof => prof.Email == email);
        }

        public Professeur GetProfesseurById(int id)
        {
            return context.Professeurs.Find(id);
        }

        public List<SeancesForProf> GetSeancesForProf(int professeur_id)
        {
            string[] jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };

            DateTime aujourdhui = DateTime.Parse("15/05/2021");
            Semaine semaine_courante;
            semaine_courante = context.Semaines.Where(s => s.Date_debut.CompareTo(aujourdhui) <= 0
                                                          && s.Date_fin.CompareTo(aujourdhui) >= 0).FirstOrDefault();
            
            long jour_indexer = (long)(aujourdhui - semaine_courante.Date_debut).TotalDays;
            string aujourdhui_string = jours[jour_indexer];
            List<SeancesForProf> listSeeances = new List<SeancesForProf>();

            var seances = context.details_Emplois.Include(emp => emp.Module)
                                                 .ThenInclude(emp => emp.Professeur)
                                                 .Include(emp => emp.Emploi)
                                                 .ThenInclude(emploi => emploi.Semaine)
                                                 .Include(emp => emp.Seance)
                                                 .Where(e => e.Module.Professeur.Id == professeur_id
                                                             && e.Emploi.Semaine.id == semaine_courante.id
                                                             && e.Seance.Jour.Equals(aujourdhui_string))
                                                  .Select(e => new
                                                  {
                                                      seance = new { e.Seance.id, e.Seance.HeurDebut, e.Seance.HeurFin },
                                                      classes = e.Module.Classes.Select(cl => new {
                                                          cl.Id,
                                                          cl.Nom
                                                      }).ToList(),
                                                      semaine = new { e.Emploi.Semaine.id, e.Emploi.Semaine.Code },
                                                      module = new { e.Module.Id, e.Module.NomModule },
                                                      date = aujourdhui
                                                  }).ToList();
            foreach (var seance in seances)
            {
                List<Classe> classes = new List<Classe>();
                foreach (var cl in seance.classes)
                {
                    classes.Add(new Classe() { Id = cl.Id, Nom = cl.Nom });
                }

                SeancesForProf seancesForProf = new SeancesForProf()
                {
                    Classes = classes,
                    Date = seance.date,
                    Module = new Module() { Id = seance.module.Id, NomModule = seance.module.NomModule },
                    Seance = new Seance() { id = seance.seance.id, HeurDebut = seance.seance.HeurDebut, HeurFin = seance.seance.HeurFin },
                    Semaine = new Semaine() { id = seance.semaine.id, Code = seance.semaine.Code }
                };
                listSeeances.Add(seancesForProf);
            }
            return listSeeances;
        }

        public List<StudentsList> GetStudentsList(int id_seance, int id_module, int id_semaine)
        {
            var seance_courante = context.details_Emplois
                                         .Include(e => e.Emploi).ThenInclude(e => e.Semaine)
                                         .Include(seance => seance.Absences)
                                         .Where(r => (r.Module_Id == id_module
                                           && r.Seance_Id == id_seance
                                           && r.Emploi.Semaine.id == id_semaine)).FirstOrDefault();

            var students_by_classe = context.Modules
                            .Include(m => m.Classes).ThenInclude(classe => classe.Etudiants)    
                            .Where(module => module.Id == id_module)
                            .Select(module => new
                            {
                                classes = module.Classes.Select(c => new
                                {
                                    id = c.Id,
                                    nom = c.Nom,
                                    etudiants = c.Etudiants.Select(e => new
                                    {
                                        etudiant_id = e.Id,
                                        e.Nom,
                                        e.Prenom,
                                        id_groupe = e.Groupe.Id,
                                        nom_groupe = e.Groupe.Nom

                                    })
                                })
                            }).FirstOrDefault();


            // generer les absenses 'ils n'existent pas
            List<StudentsList> final_result = new List<StudentsList>();
            foreach (var classe in students_by_classe.classes)
            {
                foreach (var etudiant in classe.etudiants)
                {
                    var student_from_db = context.Etudiants.Find(etudiant.etudiant_id);
                    if (student_from_db != null)
                    {
                        var absence = student_from_db.Absences.Where(a => a.Details_Emploi.Id == seance_courante.Id)
                                                                .Select(a => new
                                                                {
                                                                    id = a.Id,
                                                                    estPresent = a.EstPresent
                                                                })
                                                                .FirstOrDefault();
                        if (absence == null)
                        {
                            var new_absence = new Absence() { Etudiant_id = student_from_db.Id, EstPresent = true };
                            student_from_db.Absences.Add(new_absence);
                            seance_courante.Absences.Add(new_absence);
                            context.Absences.Add(new_absence);
                            context.SaveChanges();
                            absence = new { id = new_absence.Id, estPresent = new_absence.EstPresent };
                        }

                        final_result.Add(new StudentsList()
                        {
                            Classe = new Classe()
                            {
                                Id = classe.id,
                                Nom = classe.nom
                            },
                            Etudiant = new Etudiant() { Id = etudiant.etudiant_id, Nom = etudiant.Nom, Prenom = etudiant.Prenom, Id_groupe = etudiant.id_groupe, Groupe = new Groupe() { Id = etudiant.id_groupe, Nom = etudiant.nom_groupe } },
                            Absence = new Absence() { Id = absence.id, EstPresent = absence.estPresent }
                        });
                    }

                }
            }

            return final_result;
        }

        public void Save(Professeur professeur)
        {
            context.Professeurs.Add(professeur);
            context.SaveChanges();
        }

        public bool UpdateAbsence(int id_absence, bool est_present)
        {
            var absence = context.Absences.Find(id_absence);
            absence.EstPresent = est_present;
            var result = context.SaveChanges();
            return result >= 1;
        }

    }
}
