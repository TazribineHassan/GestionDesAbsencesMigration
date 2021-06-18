using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class AdminService : IAdminService
    {
        private ApplicationContext context;

        public AdminService(ApplicationContext context)
        {
            this.context = context;
        }

        public Administrateur GetAdminByEmail(string email)
        {
            return context.Administrateurs.Include(admin => admin.Role).FirstOrDefault(etd => etd.Email == email);
        }


        public void Save(Administrateur admin)
        {
            context.Administrateurs.Add(admin);
            context.SaveChanges();
        }
        public bool UpdateAbsence(int id_absence, bool est_present)
        {
            var absence = context.Absences.Where(ab => ab.Id == id_absence).FirstOrDefault();
            absence.EstPresent = est_present;
            var result = context.SaveChanges();
            return result >= 1; //return true if more than one record updated successfully
        }
        

        public void saveEtudiant(Etudiant e)
        {
            e.Role_Id = 3;
            context.Etudiants.Add(e);
            context.SaveChanges();
        }

        public void deleteEtudiant(Etudiant e)
        {
            Etudiant etud = context.Etudiants.Find(e.Id);
            context.Etudiants.Remove(etud);
            context.SaveChanges();
        }

        public void updateEtudiant(Etudiant e)
        {
            Etudiant etud = context.Etudiants.Find(e.Id);
            etud = e;
            context.SaveChanges();
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


            // generer les absenses s'ils n'existent pas
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

        public List<EtudiantAbsent> absenceList()
        {
            /*
            var result2 = context.Etudiants.Select(etudiant => new EtudiantAbsent()
            {
                nomClass = etudiant.Classe.Nom,
                id = etudiant.Id,
                nom = etudiant.Nom,
                prenom = etudiant.Prenom,
                absence_count = etudiant.Absences.Where(absence => !absence.EstPresent).Count()
            }).ToList();

            List<EtudiantAbsent> elist = context.Etudiants.Join(context.Absences,
                etudiant => etudiant.Id,
                absence => absence.Etudiant.Id,

                (etudiant, absence) => new EtudiantAbsent()
                {
                    nomClass = etudiant.Classe.Nom,
                    id = etudiant.Id,
                    nom = etudiant.Nom,
                    prenom = etudiant.Prenom,
                    absence_count = etudiant.Absences.Where(myabsence => !absence.EstPresent && tabSem.Contains(myabsence.Details_Emploi.Emploi.Semaine.id)).Count()
                }).ToList();

            List<EtudiantAbsent> filtredList = new List<EtudiantAbsent>();

            for (int i = 0; i < elist.Count; i++)
            {
                if (elist[i].absence_count > 1)
                {
                    filtredList.Add(elist[i]);
                }
            }

            return filtredList;*/
            return null;
        }
    }

    }