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
            var absences = context.Absences.Where(absence => absence.Etudiant.Id == Etudiant_id)
                                           .Include(ab => ab.Details_Emploi).ThenInclude(demp => demp.Module)
                                           .Include(ab => ab.Details_Emploi).ThenInclude(demp => demp.Seance)
                                           .Include(ab => ab.Details_Emploi).ThenInclude(demp => demp.Emploi).ThenInclude(emp => emp.Semaine)
                                           .Select(absence => new { 
                                                     Absence_ID = absence.Id,
                                                     Est_Absent = !absence.EstPresent,
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

        public void ResetPassword(int Id, string newPass)
        {
            var user = context.Etudiants.Find(Id);
            user.Password = newPass;
            context.SaveChanges();
        }
    }

}
        

       
    
