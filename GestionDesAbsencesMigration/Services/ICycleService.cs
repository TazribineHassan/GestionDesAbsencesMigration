using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public interface ICycleService
    {
        IEnumerable<Cycle> getAll();
        Cycle GetCycleById(int id);
    }
}
