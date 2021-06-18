using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Controllers
{
    public class LoginController : Controller
    {

        private IProfesseurService professeurService;

        public LoginController(IProfesseurService professeurService)
        {
            this.professeurService = professeurService;
        }


        public IActionResult Index()
        {
            /* CHECK IF USER ALREADY SIGNED IN */
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = professeurService.GetProfesseurByEmail(userEmail);
            if(user != null)
            {
                return RedirectToAction("Index", "Professeur");
            }


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> validate_user(string email, string password)
        {
            // check if the user is professeur 
            var user = professeurService.GetProfesseurByEmail(email);
            //check if the user is etudiant

            if(user == null)
            {
                return RedirectToAction("Login");
            }

            if (!Encryption.Decrypt(user.Password).Equals(password))
            {
                return RedirectToAction("Login");
            }

            ClaimsPrincipal claimsPrincipal = createClaimsPrincipal(email, user.Role.Nom);

            await HttpContext.SignInAsync(claimsPrincipal);

            return RedirectToAction("Index", "Professeur");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public String test()
        {
            return "test";
        }

        private ClaimsPrincipal createClaimsPrincipal(string username, string Role)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, username));
            claims.Add(new Claim(ClaimTypes.Role, Role));
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            return claimsPrincipal;
        }
         

    }
}
