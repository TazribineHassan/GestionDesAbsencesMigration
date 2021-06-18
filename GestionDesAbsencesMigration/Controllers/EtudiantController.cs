using GestionDesAbsencesMigration.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Controllers
{
    [Authorize(Roles = "etudiant")]
    public class EtudiantController : Controller
    {
        private IEtudiantService etudiantService;
        
        public EtudiantController(IEtudiantService etudiantService)
        {
            this.etudiantService = etudiantService;
        }
        public IActionResult Index()
        {
            int etudiant_id = getCurrentEtudiantId();
            var listAbsence = etudiantService.GetAbsence(etudiant_id);
            return View(listAbsence);
        }

        private int getCurrentEtudiantId()
        {
            var username = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            return etudiantService.GetEtudiantByEmail(username).Id;
        }
    }
}
