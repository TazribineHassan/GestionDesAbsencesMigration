using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
        IExcelService excelService;
        ISeanceService seanceService;
        ICompositeViewEngine compositeViewEngine;
        IRoleService roleService;
        IModuleService moduleService;
        IClassService classeService;
        private string admin_name;
        public AdminController(IAdminService AdminService, IProfesseurService professeurService, 
                               ISemaineService semaineService, ICycleService cycleService, 
                               IEtudiantService etudiantService, IExcelService excelService,
                               ISeanceService seanceService, ICompositeViewEngine compositeViewEngine,
                               IRoleService roleService, IModuleService moduleService,
                               IClassService classeService)
        {
            this.professeurService = professeurService;
            this.AdminService = AdminService;
            this.semaineService = semaineService;
            this.cycleService = cycleService;
            this.etudiantService = etudiantService;
            this.excelService = excelService;
            this.seanceService = seanceService;
            this.compositeViewEngine = compositeViewEngine;
            this.roleService = roleService;
            this.moduleService = moduleService;
            this.classeService = classeService;
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

        public JsonResult GetClass(int id)
        {
            var classes = cycleService.GetCycleById(id).Classes;
            return Json(classes);

        }

        public ActionResult AllEtudiants()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return View(etudiantService.getAll());
        }

        //SaveStudent
        [HttpPost] //DONE
        public ActionResult SaveEtudiant(string cne, string nom, string prenom, string email, string liste_cycle, int classe, int groupe)
        {
            Etudiant e = new Etudiant();
            e.Cne = cne;
            e.Nom = nom;
            e.Prenom = prenom;
            e.Email = email;
            e.Role_Id = roleService.getRoleId("etudiant");
            e.Id_groupe = groupe;
            e.Id_classe = classe;
            e.Password = Encryption.Encrypt(cne);
            AdminService.saveEtudiant(e);
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllEtudiants");
        }

        //delete Student
        //DONE
        public ActionResult DeleteEtudiant(int id)
        {
            Etudiant e = etudiantService.GetEudiantById(id);
            AdminService.deleteEtudiant(e);
            return Redirect("/Admin/AllEtudiants");
        }

        //DONE
        public PartialViewResult GetEditedEtudiant(int id)
        {
            ViewBag.e = id;
            ViewBag.valN = "";
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            Etudiant e = etudiantService.GetEudiantById(id);
            return PartialView(e);
        }

        //edit student
        [HttpPost] // DONE
        public ActionResult EditEtudiant(int editidinput, string editcne, string editnom, string editprenom, string editemail, string editliste_cycle, int editclasse, int editgroupe)
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
        [HttpPost]//DONE
        public ActionResult SaveProf(string code, string nom, string prenom, string email)
        {
            Professeur e = new Professeur();
            e.Code_prof = code;
            e.Nom = nom;
            e.Prenom = prenom;
            e.Email = email;
            e.Role_Id = roleService.getRoleId("professeur");
            e.Password = Encryption.Encrypt(email);
            professeurService.Save(e);
            return Redirect("/Admin/AllProfs");
        }


        //delete Prof
        //DONE
        public ActionResult DeleteProf(int id)
        {
            Professeur e = professeurService.GetProfesseurById(id);
            professeurService.deleteProfesseur(e);
            return Redirect("/Admin/AllProfs");
        }

        //editProf partialview
        //DONE
        public PartialViewResult GetEditedProfesseur(int id)
        {
            ViewBag.e = id;
            Professeur p = professeurService.GetProfesseurById(id);
            return PartialView(p);
        }

        //editProf
        //DONE
        public ActionResult EditProfesseur(int editidinput, string editcode, string editnom, string editprenom, string editemail, string editcycle)
        {

            Professeur newE =professeurService.GetProfesseurById(editidinput);
            newE.Code_prof = editcode;
            newE.Nom = editnom;
            newE.Prenom = editprenom;
            newE.Email = editemail;
            professeurService.updateProfesseur(newE);


            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllProfs");
        }


        /*  MODULE */

        public ActionResult AllModules()
        {
            ViewBag.adminName = admin_name;
            return View(moduleService.getAll());
        }

        //Save Module
        public ActionResult SaveModule(string nom, int id_Professeur)
        {
            Module module = new Module();
            module.NomModule = nom;
            module.id_Professeur = id_Professeur;
            moduleService.Save(module);
            return Redirect("/Admin/AllModules");
        }


        //delete Module
        public ActionResult DeleteModule(int id)
        {
            moduleService.deleteModule(id);
            return Redirect("/Admin/AllModules");
        }

        //editProf partialview
        public PartialViewResult GetEditedModule(int id)
        {
            ViewBag.e = id;
            Module module = moduleService.GetModuleById(id);
            return PartialView(module);
        }

        //editModule

        public ActionResult EditModule(int id_module, string nomModule, int id_professeur)
        {

            Module module = moduleService.GetModuleById(id_module);
            module.NomModule = nomModule;
            module.id_Professeur = id_professeur;
            moduleService.updateModule(module);

            ViewBag.list = new SelectList(professeurService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllModules");
        }

        /*  CLASSE */

        public ActionResult AllClasses()
        {
            ViewBag.adminName = admin_name;
            return View(classeService.getAll());
        }

        //Save Module
        public ActionResult SaveClasse(string nom, int id_cycle)
        {
            Classe classe = new Classe();
            classe.Nom = nom;
            classe.id_cycle = id_cycle;
            classeService.Save(classe);
            return Redirect("/Admin/AllClasses");
        }


        //delete Module
        public ActionResult DeleteClasse(int id)
        {
            classeService.deleteClasse(id);
            return Redirect("/Admin/AllClasses");
        }

        //editProf partialview
        public PartialViewResult GetEditedClasse(int id)
        {
            ViewBag.e = id;
            Classe classe = classeService.GetClasseById(id);
            return PartialView(classe);
        }

        //editModule

        public ActionResult EditClasse(int id_classe, string nom, int id_cycle)
        {
            Classe classe = classeService.GetClasseById(id_classe);
            classe.Nom = nom;
            classe.id_cycle = id_cycle;
            classeService.updateClasse(classe);

            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllClasses");
        }


        [ActionName("Index")]
        [HttpPost]
        public ActionResult import(int myclass, IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = file.OpenReadStream();
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(file.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return Json("Only excel file");
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportEtudiants(dt, workbook, myclass);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportEtudiants(dt, workbook, myclass);
                    }
                    return Json("OK");
                }

                catch (Exception e)
                {

                    return Json(e.ToString());
                }
            }
            // return View();
        }

        [HttpPost]
        public ActionResult AddProfs(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = file.OpenReadStream();
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(file.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return Json("Only excel file");
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportProfesseurs(dt, workbook);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportProfesseurs(dt, workbook);
                    }
                    return Json("OK");
                }

                catch (Exception e)
                {

                    return Json(e.ToString());
                }
            }
            // return View();

        }

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

        public JsonResult GetModule(int prof_id)
        {

            var modules = professeurService.GetProfesseurById(prof_id).Modules;

            // to prevent json recursivity
            foreach(Module module in modules)
            {
                module.Professeur = null;
            }

            return Json(modules);

        }

        public JsonResult GetSeances(int module_id, int semaine_id)
        {

            var seances = seanceService.GetSeances(module_id, semaine_id);

            return Json(seances);

        }

        public ActionResult Statistiques()
        {
            int idSemaine = 1;
            ViewBag.adminName = admin_name;
            var result3 = AdminService.statistics(idSemaine);
            return View(result3);
        }

        public ViewResult StatistiquesPDF()
        {
            int idSemaine = 1;
            ViewBag.adminName = admin_name;
            List<EtudiantAbsent> filtredList = AdminService.statisticsPdf();
            return View(filtredList);
        }

        [Route("Admin/generatePdf")]
        public async Task<ActionResult> generatePdfAsync()
        {

            using (var s = new StringWriter()) {

                // var viewResult = StatistiquesPDF();
                var viewResult = compositeViewEngine.FindView(ControllerContext, "StatistiquesPDF", false);
                List<EtudiantAbsent> filtredList = AdminService.statisticsPdf();
                ViewData.Model = filtredList;
                var viewContext = new ViewContext(ControllerContext,
                                                    viewResult.View,
                                                    ViewData,
                                                    TempData,
                                                    s,
                                                    new HtmlHelperOptions()
                                                  );
                
                await viewResult.View.RenderAsync(viewContext);

                SelectPdf.HtmlToPdf converter = new SelectPdf.HtmlToPdf();
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(s.ToString());
                var pdf = doc.Save();
                doc.Close();
                return File(pdf, "application/pdf");
            }

        }

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
