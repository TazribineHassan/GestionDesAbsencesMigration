using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Controllers
{
    [Authorize(Roles = "professeur")]
    public class ProfesseurController : Controller
    {
        private IProfesseurService professeurService;

        public ProfesseurController(IProfesseurService professeurService, ApplicationContext db)
        {
            this.professeurService = professeurService;
        }

        public string Index()
        {
            var listOfSeance = professeurService.GetSeancesForProf(1).Last().Module.NomModule;
            
            return listOfSeance;
        }


    }
}
