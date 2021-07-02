using GestionDesAbsencesMigration.Common;
using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.services;
using GestionDesAbsencesMigration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

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
        IGeneratePdf generatePdf;
        IRoleService roleService;
        IModuleService moduleService;
        IClassService classeService;
        private string admin_name;
        public AdminController(IAdminService AdminService, IProfesseurService professeurService, 
                               ISemaineService semaineService, ICycleService cycleService, 
                               IEtudiantService etudiantService, IExcelService excelService,
                               ISeanceService seanceService, IRoleService roleService, 
                               IModuleService moduleService, IClassService classeService, 
                               IGeneratePdf generatePdf)
        {
            this.professeurService = professeurService;
            this.AdminService = AdminService;
            this.semaineService = semaineService;
            this.cycleService = cycleService;
            this.etudiantService = etudiantService;
            this.excelService = excelService;
            this.seanceService = seanceService;
            this.roleService = roleService;
            this.moduleService = moduleService;
            this.classeService = classeService;
            this.generatePdf = generatePdf;
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
            ViewBag.absence_count = etudiantService.GetCurrentDayAbsencesCount();
            ViewBag.absence_count_by_cycle = etudiantService.GetCurrentSemaineAbsencesCountByCycle();
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
        //DONE
        public ActionResult AllEtudiants()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            ViewBag.list_Classe = new SelectList(classeService.getAll(), "Id", "Nom");
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
        //DONE
        public ActionResult AllModules()
        {
            ViewBag.adminName = admin_name;
            ViewBag.list_profs = new SelectList(professeurService.getAll(), "Id", "Nom");
            ViewBag.list_clesses = new SelectList(classeService.getAll(), "Id", "Nom");
            return View(moduleService.getAll());
        }

        //Save Module
        //DONE
        public ActionResult SaveModule(string nom, int id_Professeur, List<int> classes_ids)
        {
            Module module = new Module();
            module.NomModule = nom;
            module.id_Professeur = id_Professeur;
            moduleService.Save(module, classes_ids);
            return Redirect("/Admin/AllModules");
        }


        //delete Module
        //DONE
        public ActionResult DeleteModule(int id)
        {
            moduleService.deleteModule(id);
            return Redirect("/Admin/AllModules");
        }

        //editModule partialview
        public PartialViewResult GetEditedModule(int id)
        {
            ViewBag.e = id;
            ViewBag.list_profs = new SelectList(professeurService.getAll(), "Id", "Nom");
            ViewBag.list_clesses = new SelectList(classeService.getAll(), "Id", "Nom");
            Module module = moduleService.GetModuleById(id);
            return PartialView(module);
        }

        //editModule
        [HttpPost]
        public ActionResult EditModule(int id_module, string nomModule, int id_Professeur, List<int> classes_ids)
        {

            Module module = moduleService.GetModuleById(id_module);
            module.NomModule = nomModule;
            module.id_Professeur = id_Professeur;
            moduleService.updateModule(module, classes_ids);

            ViewBag.list = new SelectList(professeurService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllModules");
        }

        /*  CLASSE */

        public ActionResult AllClasses()
        {
            ViewBag.adminName = admin_name;
            return View(classeService.getAll());
        }

        //Save Classe
        //DONE
        public ActionResult SaveClasse(string nom, int id_cycle)
        {
            Classe classe = new Classe();
            classe.Nom = nom;
            classe.id_cycle = id_cycle;
            classeService.Save(classe);
            return Redirect("/Admin/AllClasses");
        }


        //delete Module
        //DONE
        public ActionResult DeleteClasse(int id)
        {
            classeService.deleteClasse(id);
            return Redirect("/Admin/AllClasses");
        }

        //editClasse partialview
        //DONE
        public PartialViewResult GetEditedClasse(int id)
        {
            ViewBag.e = id;
            Classe classe = classeService.GetClasseById(id);
            return PartialView(classe);
        }

        //editClasse
        //DONE
        public ActionResult EditClasse(int id_classe, string nom, int id_cycle)
        {
            Classe classe = classeService.GetClasseById(id_classe);
            classe.Nom = nom;
            classe.id_cycle = id_cycle;
            classeService.updateClasse(classe);

            ViewBag.list = new SelectList(cycleService.getAll(), "Id", "Nom");
            return Redirect("/Admin/AllClasses");
        }



                                /* IMPORT WITH EXCEL FILE */
        [HttpPost]
        public ActionResult importStudents(int id_classe, IFormFile excel)
        {
            DataTable dt = new DataTable();
            if (excel == null || excel.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = excel.OpenReadStream();
            string FileName = Path.GetExtension(excel.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return RedirectToAction("AllEtudiants", new { msg = "only excel files are allowed" });
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportEtudiants(workbook, id_classe);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportEtudiants(workbook, id_classe);
                    }
                    return RedirectToAction("AllEtudiants");
                }

                catch (Exception e)
                {

                    return RedirectToAction("AllEtudiants", new { msg = "importing failed, error occured"});
                }
            }
            // return View();
        }

        [HttpPost]
        public ActionResult AddProfesseurs(IFormFile excel)
        {
            if (excel == null || excel.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = excel.OpenReadStream();
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(excel.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return RedirectToAction("AllProfs", new { msg = "only excel files are allowed" });
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportProfesseurs(workbook);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportProfesseurs(workbook);
                    }
                    return RedirectToAction("AllProfs");
                }

                catch (Exception e)
                {

                    return RedirectToAction("AllProfs", new { msg = "importing failed, error occured" });
                }
            }
            // return View();

        }

        [HttpPost]
        public ActionResult AddClasses(IFormFile excel)
        {
            if (excel == null || excel.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = excel.OpenReadStream();
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(excel.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return RedirectToAction("AllProfs", new { msg = "only excel files are allowed" });
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportClasses(workbook);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportClasses(workbook);
                    }
                    return RedirectToAction("AllProfs");
                }

                catch (Exception e)
                {

                    return RedirectToAction("AllProfs", new { msg = "importing failed, error occured" });
                }
            }
            // return View();

        }

        [HttpPost]
        public ActionResult AddModules(IFormFile excel)
        {
            if (excel == null || excel.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = excel.OpenReadStream();
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(excel.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return RedirectToAction("AllProfs", new { msg = "only excel files are allowed" });
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportModules(workbook);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportModules(workbook);
                    }
                    return RedirectToAction("AllProfs");
                }

                catch (Exception e)
                {

                    return RedirectToAction("AllProfs", new { msg = "importing failed, error occured" });
                }
            }
            // return View();

        }

        [HttpPost]
        public ActionResult AddSemaines(IFormFile excel)
        {
            if (excel == null || excel.Length <= 0)
            {
                return Json("please select excel file");
            }
            Stream streamfile = excel.OpenReadStream();
            DataTable dt = new DataTable();
            string FileName = Path.GetExtension(excel.FileName);
            if (FileName != ".xls" && FileName != ".xlsx")
            {
                return RedirectToAction("AllProfs", new { msg = "only excel files are allowed" });
            }
            else
            {
                try
                {
                    if (FileName == ".xls")
                    {
                        HSSFWorkbook workbook = new HSSFWorkbook(streamfile);
                        dt = excelService.ImportSemaines(workbook);
                    }
                    else
                    {
                        XSSFWorkbook workbook = new XSSFWorkbook(streamfile);
                        dt = excelService.ImportSemaines(workbook);
                    }
                    return RedirectToAction("AllProfs");
                }

                catch (Exception e)
                {

                    return RedirectToAction("AllProfs", new { msg = "importing failed, error occured" });
                }
            }
            // return View();

        }


        /* PROFESSEUR CRUD */
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
            var result3 = AdminService.statistics(3, 1, 1);
            return View(result3);
        }

        public ViewResult ConsielPDF()
        {
            ViewBag.adminName = admin_name;
            List<EtudiantAbsent> filtredList = AdminService.consielPdf(3, 1, 1, 1);
            return View("StatistiquesPDF", filtredList);
        }

        [Route("Admin/GeneratePdf")]
        public async Task<IActionResult> generatePdfAsync(int id_semaine_dep, int id_semaine_fin, int id_classe, int nbAbsence)
        {

            List<EtudiantAbsent> filtredList = AdminService.consielPdf(id_semaine_dep, id_semaine_fin, id_classe, nbAbsence);
            return await generatePdf.GetPdf("Admin/StatistiquesPDF", filtredList);
        }

        public ActionResult ListeEtudiants(int id_seance, int id_modules, int id_semaine)
        {
            var listOfStudents = AdminService.GetStudentsList(id_seance, id_modules, id_semaine);
            return View(listOfStudents);
        }


        //DONE
        public ActionResult Rectification()
        {
            
            ViewBag.list_Module = new SelectList(moduleService.getAll(), "Id", "NomModule");
            
            return View(semaineService.getSemainForCurrentYear());
        }        
        
        [HttpGet]//DONE
        public ActionResult Rectifier(int id_seance, int id_module, int id_semaine)
        {

            var listOfStudents = AdminService.GetStudentsList(id_seance, id_module, id_semaine);
            return View(listOfStudents);
        }

        //DONE
        [HttpPost]
        public ActionResult Marquez(int id, bool presence, string url)
        {
            AdminService.UpdateAbsence(id, presence);
            return Redirect(url);
        }


        // Conseil

        public ActionResult Conseil()
        {
            ViewBag.list_Classe = new SelectList(classeService.getAll(), "Id", "Nom");
            return View(semaineService.getSemainForCurrentYear());
        }

        public ActionResult Parametres()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ResetPassword(string currentPassword, string newPassword, string url)
        {
            var user = GetIdUserFromCoockie();
            if (Encryption.Decrypt(user.Password).Equals(currentPassword))
            {
                AdminService.ResetPassword(user.Id, Encryption.Encrypt(newPassword));
                ViewBag.Msg = "Le mot de passe a été bien changé";
            }
            else
            {
                ViewBag.Msg = "Votre mot de passe actuel est inccorect";
            }
            return Redirect(url);
        }


        public JsonResult CycleChart()
        {
            Dictionary<string, int> cycles = etudiantService.GetCurrentSemaineAbsencesCountByCycle();
            return Json(cycles);
        }

        public JsonResult ClasseChart()
        {
            Dictionary<string, int> classes = etudiantService.GetCurrentSemaineAbsencesCountByClasse();
            
            return Json(classes);
        }


        private Administrateur GetIdUserFromCoockie()
        {
            var userEmail = this.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = AdminService.GetAdminByEmail(userEmail);
            return user;
        }
    }
}
