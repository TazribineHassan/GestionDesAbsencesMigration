using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class SeanceService : ISeanceService
    {
        private ApplicationContext context;

        public SeanceService(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Seance> GetSeances(int module_id, int semaine_id)
        {
            return context.details_Emplois.Include(d_emp => d_emp.Emploi).ThenInclude(emp => emp.Semaine)
                                          .Include(d_emp => d_emp.Module)
                                          .Include(d_emp => d_emp.Module)
                                          .Where(d_emp => d_emp.Emploi.Semaine.id == semaine_id && d_emp.Module.Id == module_id)
                                          .Select(d_emp => d_emp.Seance);
        }
    }
}
