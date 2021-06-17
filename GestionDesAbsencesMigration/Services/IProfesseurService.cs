using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.services
{
    public interface IProfesseurService
    {
        void Save(Professeur professeur);
        IEnumerable<Professeur> FindAll();
        Professeur GetProfesseurById(int id);
        Professeur GetProfesseurByEmail(string email);
        List<SeancesForProf> GetSeancesForProf(int professeur_id);
        List<StudentsList> GetStudentsList(int id_seance, int id_module, int id_semaine);
        bool UpdateAbsence(int id_absence, bool est_present);
        void deleteProfesseur(Professeur p);
    }
}
