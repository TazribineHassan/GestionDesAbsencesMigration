﻿using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
        private string admin_name;
        public AdminController(IAdminService AdminService, IProfesseurService professeurService, 
                               ISemaineService semaineService, ICycleService cycleService, 
                               IEtudiantService etudiantService, IExcelService excelService,
                               ISeanceService seanceService, ICompositeViewEngine compositeViewEngine)
        {
            this.professeurService = professeurService;
            this.AdminService = AdminService;
            this.semaineService = semaineService;
            this.cycleService = cycleService;
            this.etudiantService = etudiantService;
            this.excelService = excelService;
            this.seanceService = seanceService;
            this.compositeViewEngine = compositeViewEngine;
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

        public JsonResult GetClass(int cycle_id)
        {
            var classes = cycleService.GetCycleById(cycle_id).Classes;
            foreach(var classe in classes)
            {
                classe.Cycle = null;
            }
            return Json(classes);

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
        public PartialViewResult etudiantDetails(int id)
        {
            //String s = this.ControllerContext.HttpContext.Request.Cookies["AdminName"];
            //ViewBag.adminName = s;
            Etudiant e = etudiantService.GetEudiantById(id);
            return PartialView(e);
        }

        [HttpPost]
        public PartialViewResult AjaxEditEtudiant()
        {
            ViewBag.e = id;
            ViewBag.valN = "";
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            Etudiant e = etudiantService.GetEudiantById(id);
            return PartialView(e);
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

                var viewResult = StatistiquesPDF();

                var viewContext = new ViewContext(ControllerContext,
                                                    (viewResult.ViewEngine as ViewEngineResult).View,
                                                    viewResult.ViewData,
                                                    viewResult.TempData,
                                                    s,
                                                    new HtmlHelperOptions()
                                                  );
                
                await (viewResult.ViewEngine as ViewEngineResult).View.RenderAsync(viewContext);

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
