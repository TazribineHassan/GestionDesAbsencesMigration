using GestionDesAbsencesMigration.Models;
using System;
using GestionDesAbsencesMigration.services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GestionDesAbsencesMigration.Models.Context;
using Microsoft.EntityFrameworkCore;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class EtudiantService : IEtudiantService {

        private ApplicationContext context;

        public EtudiantService(ApplicationContext context)
        {
            this.context = context;
        }

        public List<AbsenceList> GetAbsence(int Etudiant_id)
        {
            var absences = context.Absences.Include(ab => ab.Details_Emploi).ThenInclude(demp => demp.Module)
                                           .Include(ab => ab.Details_Emploi).ThenInclude(demp => demp.Seance)
                                           .Include(ab => ab.Details_Emploi).ThenInclude(demp => demp.Emploi).ThenInclude(emp => emp.Semaine)
                                           .Where(absence => absence.Etudiant.Id == Etudiant_id && !absence.EstPresent)
                                           .Select(absence => new { 
                                                     Absence_ID = absence.Id,
                                                     Est_Absent = !absence.EstPresent,
                                                     etudiant_id = absence.Etudiant_id,
                                                     module = new { Id = absence.Details_Emploi.Module.Id, 
                                                                             NomModule = absence.Details_Emploi.Module .NomModule
                                                                   },
                                                     seance = new 
                                                     {
                                                         id = absence.Details_Emploi.Seance.id,
                                                         Heure_debut = absence.Details_Emploi.Seance.HeurDebut,
                                                         Heure_fin = absence.Details_Emploi.Seance.HeurFin,
                                                         Jour = absence.Details_Emploi.Seance.Jour
                                                     },
                                                     semaine = new {id = absence.Details_Emploi.Emploi.Semaine.id, 
                                                                    Code = absence.Details_Emploi.Emploi.Semaine.Code }
                                                     
                                                   }).ToList();

            List<AbsenceList> result = new List<AbsenceList>();
            foreach(var absence in absences)
            {
                var item = new AbsenceList()
                {
                    Absence_ID = absence.Absence_ID,
                    Est_Absent = absence.Est_Absent,
                    module = new Module()
                    {
                        Id = absence.module.Id,
                        NomModule = absence.module.NomModule
                    },
                    seance = new Seance()
                    {
                        id = absence.seance.id,
                        HeurDebut = absence.seance.Heure_debut,
                        HeurFin = absence.seance.Heure_fin,
                        Jour = absence.seance.Jour
                    },
                    semaine = new Semaine()
                    {
                        id = absence.seance.id,
                        Code = absence.semaine.Code
                    }
                };
                result.Add(item);
            }
            return result;
        }

        public IEnumerable<Etudiant> getAll()
        {
            return context.Etudiants.Include( e => e.Groupe)
                                    .Include(e => e.Classe);
        }

        public Etudiant GetEtudiantByEmail(string email)
        {
            return context.Etudiants.Include(etud => etud.Role)
                                    .Include(etud => etud.Classe)
                                    .FirstOrDefault(etd => etd.Email == email);
        }

        public Etudiant GetEudiantById(int id)
        {
            return context.Etudiants.Find(id);
        }

        public void UpdateEtudiant(Etudiant etudiant)
        {
            var old_etudiant = context.Etudiants.Find(etudiant.Id);
            old_etudiant.Cne = etudiant.Cne;
            old_etudiant.Nom = etudiant.Nom;
            old_etudiant.Prenom = etudiant.Prenom;
            old_etudiant.Email = etudiant.Email;
            old_etudiant.Id_groupe = etudiant.Id_groupe;
            old_etudiant.Id_classe = etudiant.Id_classe;
            context.SaveChanges();
        }


        public void ResetPassword(int Id, string newPass)
        {
            var user = context.Etudiants.Find(Id);
            user.Password = newPass;
            context.SaveChanges();
        }

        public int GetCurrentDayAbsencesCount()
        {
            string[] jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };

            //get the curren semaine 
            DateTime aujourdhui = DateTime.Parse("1/5/2021");
            Semaine semaine_courante;
            semaine_courante = context.Semaines.Where(s => s.Date_debut.CompareTo(aujourdhui) <= 0
                                                          && s.Date_fin.CompareTo(aujourdhui) >= 0).FirstOrDefault();
            var current_day_index = aujourdhui.Day;

            var absCount = context.Absences.Include(abs => abs.Details_Emploi).ThenInclude(demp => demp.Emploi).ThenInclude(emp => emp.Semaine)
                                           .Include(abs => abs.Details_Emploi).ThenInclude(demp => demp.Seance)
                                           .Where(abs => abs.Details_Emploi.Emploi.Semaine.id == semaine_courante.id
                                                         && abs.Details_Emploi.Seance.Jour.Equals(jours[current_day_index]))
                                           .ToList().Count();
            return absCount;
        }

        public int GetCurrentSemaineAbsencesCount()
        {

            var current_day = DateTime.Now;

            return 0;
        }

        public int GetCurrentSemaineAbsencesCountByClasse()
        {

            var current_day = DateTime.Now;

            return 0;
        }

        public int GetCurrentSemaineAbsencesCountByCycle()
        {
            var current_day = DateTime.Now;

            return 0;
        }

        public int GetCurrentSemaineAbsencesCountByDay()
        {
            var current_day = DateTime.Now;

            return 0;
        }
    }

}
        

       
    
