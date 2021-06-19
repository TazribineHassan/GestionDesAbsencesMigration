using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public interface ISeanceService
    {
        IEnumerable<Seance> GetSeances(int module_id, int semaine_id);
    }
}
