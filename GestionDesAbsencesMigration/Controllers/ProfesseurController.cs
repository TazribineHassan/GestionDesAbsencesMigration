using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
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
            var listOfSeance = professeurService.GetSeancesForProf(1);

            return View(listOfSeance);
        }

        public IActionResult Setting()
        {
            return View();
        }        
        
        public IActionResult Profil()
        {

            return View(GetIdUserFromCoockie());
        }

        private Professeur GetIdUserFromCoockie()
        {
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = professeurService.GetProfesseurByEmail(userEmail);
            return user;
        }
    }
}
