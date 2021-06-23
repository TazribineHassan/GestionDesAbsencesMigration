using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.services
{
    public interface IEtudiantService
    {
        Etudiant GetEtudiantByEmail(string email);
        Etudiant GetEudiantById(int id);
        List<AbsenceList> GetAbsence(int Etudiant_id);

        IEnumerable<Etudiant> getAll();

        void UpdateEtudiant(Etudiant etudiant);

        void ResetPassword(int Id, string newPass);

        int GetCurrentDayAbsencesCount();
        int GetCurrentSemaineAbsencesCount();
        int GetCurrentSemaineAbsencesCountByClasse();
        Dictionary<string, int> GetCurrentSemaineAbsencesCountByCycle();
        int GetCurrentSemaineAbsencesCountByDay();
    }
}
