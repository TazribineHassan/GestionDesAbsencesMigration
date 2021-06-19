using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;
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

        private ILoginService loginService;

        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }


        public IActionResult Index()
        {

            /* CHECK IF USER ALREADY SIGNED IN */
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = loginService.getUser(userEmail);

            if (user is Professeur) return RedirectToAction("Index", "Professeur");

            if (user is Etudiant) return RedirectToAction("Index", "Etudiant");

<<<<<<< HEAD
            if (user is Administrateur) return RedirectToAction("Home", "Admin");
=======
            if (user is Administrateur) return RedirectToAction("Index", "Admin");
>>>>>>> d830f0e839b9ad362901bd89e8eb43a7d273a900

            ViewBag.action = "/Login/validate_user";
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> validate_user(string email, string password)
        {

            var user = loginService.Login(email, password);

            if (user == null)
            {
                return RedirectToAction("Index", new { msg = "Email or password are incorrect" });
            }

            string role = null;
            if (user is Professeur) role = (user as Professeur).Role.Nom;
            else if (user is Etudiant) role = (user as Etudiant).Role.Nom;

            ClaimsPrincipal claimsPrincipal = createClaimsPrincipal(email, role);

            await HttpContext.SignInAsync(claimsPrincipal);

            if (user is Professeur)  return RedirectToAction("Index", "Professeur");
            if (user is Etudiant) return RedirectToAction("Index", "Etudiant");

            return RedirectToAction("Index", new { msg = "Email or password are incorrect" });
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        public String test()
        {
            return "test";
        }


        public ActionResult IndexMsg(string msg)
        {
            ViewBag.Msg = msg;
            return View("Index");
        }

        public ActionResult Admin()
        {

            /* CHECK IF USER ALREADY SIGNED IN */
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = loginService.getUser(userEmail);

            if (user is Professeur) return RedirectToAction("Index", "Professeur");

            if (user is Etudiant) return RedirectToAction("Index", "Etudiant");

<<<<<<< HEAD
            if (user is Administrateur) return RedirectToAction("Home", "Admin");
=======
            if (user is Administrateur) return RedirectToAction("Index", "Admin");
>>>>>>> d830f0e839b9ad362901bd89e8eb43a7d273a900

            ViewBag.action = "/Login/CheckAdmin";
            return View("Index");
        }

        public ActionResult AdminMsg(string msg)
        {
            ViewBag.Msg = msg;
            return View("Admin");
        }

        [HttpPost]
        public async Task<ActionResult> CheckAdmin(string email, string password)
        {
            Administrateur admin = loginService.Login(email, password, "admin") as Administrateur;
            if (admin != null)
            {

                this.ControllerContext.HttpContext.Response.Cookies.Append("AdminName", admin.Nom + " " + admin.Prenom);

                ClaimsPrincipal claimsPrincipal = createClaimsPrincipal(email, admin.Role.Nom);
                await HttpContext.SignInAsync(claimsPrincipal);

                //ViewBag.Nom = professeur.Nom;
                return RedirectToAction("Index", "Admin");

            }
            else
            {
                return RedirectToAction("AdminMsg", new { msg = "Email or password are incorrect" });
            }
        }

        [HttpGet]
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
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
