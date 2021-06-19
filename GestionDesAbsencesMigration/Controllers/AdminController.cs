using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;
using GestionDesAbsencesMigration.ServicesImpl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        IAdminService AdminService;
        IProfesseurService professeurService;
        ISemaineService semaineService;
        ICycleService cycleService;
        IEtudiantService etudiantService;
        private string admin_name;
        public AdminController(IAdminService AdminService, IProfesseurService professeurService, ISemaineService semaineService, ICycleService cycleService, IEtudiantService etudiantService)
        {
            this.professeurService = professeurService;
            this.AdminService = AdminService;
            this.semaineService = semaineService;
            this.cycleService = cycleService;
            this.etudiantService = etudiantService;

        }
        // GET: Admin
        public string Index()
        {

            var user = GetIdUserFromCoockie();
            this.admin_name = user.Nom = " " + user.Prenom;
            ViewBag.adminName = admin_name;

            return admin_name;
        }


        public ActionResult Home()
        {
            ViewBag.adminName = admin_name;
            return View();
        }

        public ActionResult AllFilieres()
        {
            ViewBag.adminName = admin_name;
            return View();
        }

        public ActionResult AjouterClasse()
        {
            ViewBag.adminName = admin_name;
            return View();
        }

        public ActionResult ExcelPage()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");

            return View();
        }


        public ActionResult AllEtudiants()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return View(etudiantService.getAll());
        }

        //SaveStudent
        [HttpPost]
        public ActionResult SaveEtudiant(string cne, string nom, String prenom, string email, string cycle, int classe, int groupe)
        {
            Etudiant e = new Etudiant();
            e.Cne = cne;
            e.Nom = nom;
            e.Prenom = prenom;
            e.Email = email;
            e.Id_groupe = groupe;
            e.Id_classe = classe;
            e.Password = Encryption.Encrypt(cne);
            AdminService.saveEtudiant(e);
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllEtudiants");
        }

        //delete Student
        public ActionResult DeleteEtudiant(int id)
        {
            Etudiant e = etudiantService.GetEudiantById(id);
            AdminService.deleteEtudiant(e);
            return Redirect("/Admin/AllEtudiants");
        }


        //details student
        //public PartialViewResult etudiantDetails(int id)
        //{
        //    //String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"];
        //    //ViewBag.adminName = s;
        //    Etudiant e = etudiantService.GetEudiantById(id);
        //    return PartialView(e);
        //}

        [HttpPost]
        public PartialViewResult AjaxEditEtudiant()
        {
            //ViewBag.e = id;
            //ViewBag.Type = type;
            //ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            //Etudiant e = etudiantService.GetEudiantById(id);
            return PartialView();
        }

        //edit student
        [HttpPost]
        public ActionResult EditEtudiant(int editidinput, string editcne, string editnom, String editprenom, string editemail, string editcycle, int editclasse, int editgroupe)
        {
            Etudiant newE = etudiantService.GetEudiantById(editidinput);
            newE.Cne = editcne;
            newE.Nom = editnom;
            newE.Prenom = editprenom;
            newE.Email = editemail;
            newE.Id_groupe = editgroupe;
            newE.Id_classe = editclasse;
            etudiantService.UpdateEtudiant(newE);
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllEtudiants");
        }

        //Prof
        public ActionResult AllProfs()
        {
            ViewBag.adminName = admin_name;
            return View(professeurService.getAll());
        }

        //saveProf
        //SaveStudent
        [HttpPost]
        public ActionResult SaveProf(string code, string nom, String prenom, string email)
        {

            Professeur e = new Professeur();
            e.Code_prof = code;
            e.Nom = nom;
            e.Prenom = prenom;
            e.Email = email;
            e.Password = Encryption.Encrypt(email);
            professeurService.Save(e);
            return Redirect("/Admin/AllProfs");
        }

        //Prof details PartialVies
        public PartialViewResult ProfDetails(int id)
        {
            //String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"];
            //ViewBag.adminName = s;
            Professeur e = professeurService.GetProfesseurById(id);
            return PartialView(e);
        }

        //delete Prof
        public ActionResult DeleteProf(int id)
        {
            Professeur e = professeurService.GetProfesseurById(id);
            professeurService.deleteProfesseur(e);
            return Redirect("/Admin/AllProfs");
        }

        //editProf partialview

        public PartialViewResult ProfEdit(int id)
        {
            ViewBag.e = id;
            Professeur p = professeurService.GetProfesseurById(id);
            return PartialView(p);
        }

        //editProf (Modify)

        public ActionResult ModifyProf(int editidinput, string editcode, string editnom, String editprenom, string editemail, string editcycle)
        {


            Professeur newE =professeurService.GetProfesseurById(editidinput);
            newE.Code_prof = editcode;
            newE.Nom = editnom;
            newE.Prenom = editprenom;
            newE.Email = editemail;

            professeurService.updateProfesseur(newE);
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllPrfos");
        }



        /*[ActionName("Index")]
        [HttpPost]
        public ActionResult import(int myclass)
        {
            HttpPostedFileBase file = Request.Files["file"];
            if (file == null || file.ContentLength <= 0)
            {
                return Json("please select excel file", JsonRequestBehavior.AllowGet);
            }
            Stream streamfile = file.InputStream;
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(file.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return Json("Only excel file", JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excel.Import(dt, workbook, db, myclass);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excel.Import(dt, workbook, db, myclass);
                    }
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {

                    return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
            // return View();
        }
*/

        /*[HttpPost]
        public ActionResult AddProfs()
        {

            HttpPostedFileBase file = Request.Files["file"];
            if (file == null || file.ContentLength <= 0)
            {
                return Json("please select excel file", JsonRequestBehavior.AllowGet);
            }
            Stream streamfile = file.InputStream;
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(file.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return Json("Only excel file", JsonRequestBehavior.AllowGet);
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = ExcelP.Importing(dt, workbook, db);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = ExcelP.Importing(dt, workbook, db);
                    }
                    return Json("OK", JsonRequestBehavior.AllowGet);
                }

                catch (Exception e)
                {

                    return Json(e.ToString(), JsonRequestBehavior.AllowGet);
                }
            }
            // return View();

        }*/

        public ActionResult AjouterProfesseur()
        {
            ViewBag.adminName = admin_name;
            return View();
        }
        public ActionResult AjouterEtudiants()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return View();
        }

        public ActionResult CorrectAbs()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list = new SelectList(professeurService.getAll(), "Id", "Nom");
            ViewBag.listSemaines = new SelectList(semaineService.getAll(), "Id", "Code");

            return View();
        }

        /*public JsonResult GetModule(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();
            gestion.Configuration.ProxyCreationEnabled = false;
            var classe = gestion.Modules.Where(p => p.id_Professeur == id);

            return Json(classe, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetSeances(int id)
        {
            GestionDesAbsenceContext gestion = new GestionDesAbsenceContext();

            var myclasse = gestion.details_Emplois.Where(p => p.Module_Id == id);

            List<int> ids = new List<int>();

            foreach (var p in myclasse)
            {

                if (gestion.Seances.Find(p.Seance_Id) != null)
                    ids.Add(gestion.Seances.Find(p.Seance_Id).id);

            }

            //ids.Add(1);
            //ids.Add(2);
            GestionDesAbsenceContext db = new GestionDesAbsenceContext();
            db.Configuration.ProxyCreationEnabled = false;
            var seances = db.Seances.Where(s => ids.Contains(s.id));

            return Json(seances, JsonRequestBehavior.AllowGet);

        }*/

        public ActionResult Statistiques()
        {
            int idSemaine = 1;
            ViewBag.adminName = admin_name;
            var result3 = AdminService.statistics(idSemaine);
            return View(result3);
        }

        public ActionResult StatistiquesPDF()
        {
            int idSemaine = 1;
            ViewBag.adminName = admin_name;
            List<EtudiantAbsent> filtredList = AdminService.statisticsPdf();
            return View(filtredList);
        }

        /*public ActionResult generatePdf()
        {
            return new rotativa.actionaspdf("statistiquespdf");
        }
*/
        public ActionResult ListeEtudiants(int seances, int modules, int liste_Semaines)
        {
            var listOfStudents = AdminService.GetStudentsList(seances, modules, liste_Semaines);
            return View(listOfStudents);
        }

        [HttpPost]
        public ActionResult Marquez(int id, bool presence, string url)
        {
            AdminService.UpdateAbsence(id, presence);
            return Redirect(url);
        }

        private Administrateur GetIdUserFromCoockie()
        {
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = AdminService.GetAdminByEmail(userEmail);
            return user;
        }

    }
}
