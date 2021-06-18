using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
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
            int etudiant_id = GetUserFromCoockie().Id;
            var listAbsence = etudiantService.GetAbsence(etudiant_id);
            return View(listAbsence);
        }

        public IActionResult Setting()
        {
            return View();
        }

        public IActionResult Profil()
        {

            return View(GetUserFromCoockie());
        }

        [HttpPost]
        public ActionResult ResetPassword(string currentPassword, string newPassword, string url)
        {
            var user = GetUserFromCoockie();
            if (Encryption.Decrypt(user.Password).Equals(currentPassword))
            {
                etudiantService.ResetPassword(user.Id, Encryption.Encrypt(newPassword));
                ViewBag.Msg = "Le mot de passe a été bien changé";
            }
            else
            {
                ViewBag.Msg = "Votre mot de passe actuel est inccorect";
            }
            return Redirect(url);
        }

        private Etudiant GetUserFromCoockie()
        {
            var username = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var etudiant = etudiantService.GetEtudiantByEmail(username);
            return etudiant;
        }
    }
}
