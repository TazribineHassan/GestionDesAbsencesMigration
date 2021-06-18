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

        public IActionResult Index()
        {
            // listOfSeance = professeurService.GetSeancesForProf(3).Last().Module.NomModule;
            ViewBag.Role = professeurService.GetProfesseurById(3).Role.Nom;
            return View();
        }

        public IActionResult Setting()
        {
            return View();
        }        
        
        public IActionResult Profil()
        {
            return View();
        }


    }
}
