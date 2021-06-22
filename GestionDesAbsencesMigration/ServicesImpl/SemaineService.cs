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

        public IEnumerable<Semaine> getSemainForCurrentYear()
        {
            int current_month = DateTime.Now.Month;

            // year1 and year2 means scholar year for example 2020/2021
            int year1, year2;
            if(current_month <= 8)
            {
                year1 = DateTime.Now.Year - 1;
                year2 = DateTime.Now.Year;
            }
            else
            {
                year1 = DateTime.Now.Year;
                year2 = DateTime.Now.Year + 1;
            }

            var year_start = new DateTime(year1, 9, 1);
            var year_end = new DateTime(year2, 8, 31);

            var semaines = context.Semaines.Where(s => s.Date_debut.CompareTo(year_start) >= 0
                                                && s.Date_fin.CompareTo(year_end) <= 0);

            return semaines;
        }
    }
}
