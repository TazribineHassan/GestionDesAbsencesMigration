using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class SemaineService : ISemaineService
    {
        private ApplicationContext context;

        public SemaineService(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Semaine> getAll()
        {
            return context.Semaines;
        }
    }
}
