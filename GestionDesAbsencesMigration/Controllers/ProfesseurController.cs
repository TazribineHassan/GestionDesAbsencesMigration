using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
