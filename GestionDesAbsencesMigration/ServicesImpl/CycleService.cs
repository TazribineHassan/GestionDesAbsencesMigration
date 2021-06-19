using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class CycleService : ICycleService
    {
        private ApplicationContext context;

        public CycleService(ApplicationContext context)
        {
            this.context = context;
        }

        public IEnumerable<Cycle> getAll()
        {
            return context.Cycles.Include(c => c.Classes);
        }
    }
}
