using GestionDesAbsencesMigration.Common;
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
            var listOfSeance = professeurService.GetSeancesForProf(GetIdUserFromCoockie().Id);

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

        public ActionResult Notez(int id_seance, int id_module, int id_semaine)
        {
            var listOfStudents = professeurService.GetStudentsList(id_seance, id_module, id_semaine);

            return View(listOfStudents);
        }

        [HttpPost]
        public ActionResult Marquez(int id, bool presence, string url)
        {
            professeurService.UpdateAbsence(id, presence);

            return Redirect(url);
        }

        [HttpPost]
        public ActionResult ResetPassword(string currentPassword, string newPassword, string url)
        {
            var user = GetIdUserFromCoockie();
            if(Encryption.Decrypt(user.Password).Equals(currentPassword))
            {
                professeurService.ResetPassword(user.Id, Encryption.Encrypt(newPassword));
                ViewBag.Msg = "Le mot de passe a été bien changé";
            }
            else
            {
                ViewBag.Msg = "Votre mot de passe actuel est inccorect";
            }
            return Redirect(url);
        }

        private Professeur GetIdUserFromCoockie()
        {
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = professeurService.GetProfesseurByEmail(userEmail);
            return user;
        }
    }
}
