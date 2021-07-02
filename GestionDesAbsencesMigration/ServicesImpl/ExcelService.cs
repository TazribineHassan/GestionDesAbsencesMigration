using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using Microsoft.EntityFrameworkCore;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Data;
using System.Linq;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class ExcelService : IExcelService
    {

        private ApplicationContext context;

        public ExcelService(ApplicationContext context)
        {
            this.context = context;
        }

        public DataTable ImportClasses(XSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Classe classe = new Classe();
                    classe.Nom = dt.Rows[i]["Nom"].ToString();

                    // attach to cycle
                    string cycle_nom = dt.Rows[i]["Cycle"].ToString();
                    var cycle = context.Cycles.Where(prof => prof.Nom.Equals(cycle_nom)).FirstOrDefault();
                    if (cycle == null) throw new Exception("Le professeur avec l'email " + cycle_nom + "n'existe pas!");

                    classe.Cycle = cycle;

                    context.Classes.Add(classe);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportClasses(HSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Classe classe = new Classe();
                    classe.Nom = dt.Rows[i]["Nom"].ToString();

                    // attach to cycle
                    string cycle_nom = dt.Rows[i]["Cycle"].ToString();
                    var cycle = context.Cycles.Where(prof => prof.Nom.Equals(cycle_nom)).FirstOrDefault();
                    if (cycle == null) throw new Exception("Le professeur avec l'email " + cycle_nom + "n'existe pas!");

                    classe.Cycle = cycle;

                    context.Classes.Add(classe);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportEtudiants(XSSFWorkbook workbook, int class_id)
        {

            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Etudiant b = new Etudiant();
                    b.Cne = dt.Rows[i]["Cne"].ToString();
                    b.Nom = dt.Rows[i]["Nom"].ToString();
                    b.Prenom = dt.Rows[i]["Prenom"].ToString();
                    b.Email = dt.Rows[i]["Email"].ToString();
                    b.Password = Common.Encryption.Encrypt(dt.Rows[i]["Cne"].ToString());
                    b.Role_Id = 3;
                    b.Id_classe = class_id;
                    b.Id_groupe = Convert.ToInt32(dt.Rows[i]["groupe"]);

                    var flag = context.Etudiants.Where(x => x.Cne == b.Cne).FirstOrDefault();
                    if (flag != null && flag.Cne != b.Cne)
                    {
                        flag.Cne = b.Cne;
                        context.Etudiants.Add(flag);
                    }
                    if (flag != null)
                    {
                        context.Etudiants.Add(flag);
                    }
                    else
                    {
                        context.Etudiants.Add(b);
                    }
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportEtudiants( HSSFWorkbook workbook, int class_id)
        {

            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Etudiant b = new Etudiant();
                    b.Cne = dt.Rows[i]["Cne"].ToString();
                    b.Nom = dt.Rows[i]["Nom"].ToString();
                    b.Prenom = dt.Rows[i]["Prenom"].ToString();
                    b.Email = dt.Rows[i]["Email"].ToString();
                    b.Password = Common.Encryption.Encrypt(dt.Rows[i]["Cne"].ToString());
                    b.Role_Id = 3;
                    b.Id_classe = class_id;
                    b.Id_groupe = Convert.ToInt32(dt.Rows[i]["groupe"]);


                    var flag = context.Etudiants.Where(x => x.Cne == b.Cne).FirstOrDefault();
                    if (flag != null && flag.Cne != b.Cne)
                    {
                        flag.Cne = b.Cne;
                        context.Etudiants.Add(flag);
                    }
                    if (flag != null)
                    {
                        context.Etudiants.Add(flag);
                    }
                    else
                    {
                        context.Etudiants.Add(b);
                    }
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportModules(XSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Module module = new Module();
                    module.NomModule = dt.Rows[i]["NomModule"].ToString();

                    // attach professeur
                    string email = dt.Rows[i]["Ensiegnant_Email"].ToString();
                    var prof = context.Professeurs.Where(prof => prof.Email.Equals(email)).FirstOrDefault();
                    if (prof == null) throw new Exception("Le professeur avec l'email " + email + "n'existe pas!");
                    module.Professeur = prof;

                    // attach classes
                    string[] classes_names = dt.Rows[i]["Classes"].ToString().Split("/");
                    foreach(string classe_name in classes_names)
                    {
                        var classe = context.Classes.Where(cl => cl.Nom.Equals(classe_name)).FirstOrDefault();
                        if(classe == null) throw new Exception("La classe " + classe_name + "n'existe pas!");

                        module.Classes.Add(classe);
                    }

                    context.Modules.Add(module);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportModules(HSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Module module = new Module();
                    module.NomModule = dt.Rows[i]["NomModule"].ToString();

                    // attach professeur
                    string email = dt.Rows[i]["Ensiegnant_Email"].ToString();
                    var prof = context.Professeurs.Where(prof => prof.Email.Equals(email)).FirstOrDefault();
                    if (prof == null) throw new Exception("Le professeur avec l'email " + email + "n'existe pas!");
                    module.Professeur = prof;

                    // attach classes
                    string[] classes_names = dt.Rows[i]["Classes"].ToString().Split("/");
                    foreach (string classe_name in classes_names)
                    {
                        var classe = context.Classes.Where(cl => cl.Nom.Equals(classe_name)).FirstOrDefault();
                        if (classe == null) throw new Exception("La classe " + classe_name + "n'existe pas!");

                        module.Classes.Add(classe);
                    }

                    context.Modules.Add(module);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportProfesseurs(XSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Professeur p = new Professeur();
                    p.Nom = dt.Rows[i]["Nom"].ToString();
                    p.Prenom = dt.Rows[i]["Prenom"].ToString();
                    p.Code_prof = dt.Rows[i]["CIN"].ToString();
                    p.Email = dt.Rows[i]["Email"].ToString();
                    p.Password = Common.Encryption.Encrypt(dt.Rows[i]["CIN"].ToString());
                    p.Role_Id = 2;

                    var flag = context.Professeurs.Where(x => x.Nom == p.Nom).FirstOrDefault();
                    if (flag != null && flag.Nom != p.Nom)
                    {
                        flag.Nom = p.Nom;
                        context.Professeurs.Add(flag);
                    }
                    if (flag != null)
                    {
                        context.Professeurs.Add(flag);
                    }
                    else
                    {
                        context.Professeurs.Add(p);
                    }
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportProfesseurs(HSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Professeur p = new Professeur();
                    p.Nom = dt.Rows[i]["Nom"].ToString();
                    p.Prenom = dt.Rows[i]["Prenom"].ToString();
                    p.Code_prof = dt.Rows[i]["CNE"].ToString();
                    p.Email = dt.Rows[i]["Email"].ToString();
                    p.Password = Common.Encryption.Encrypt(dt.Rows[i]["Nom"].ToString());
                    p.Role_Id = 2;


                    var flag = context.Professeurs.Where(x => x.Nom == p.Nom).FirstOrDefault();
                    if (flag != null && flag.Nom != p.Nom)
                    {
                        flag.Nom = p.Nom;
                        context.Professeurs.Add(flag);
                    }
                    if (flag != null)
                    {
                        context.Professeurs.Add(flag);
                    }
                    else
                    {
                        context.Professeurs.Add(p);
                    }
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportSeances(XSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string nom_classe = dt.Rows[i]["Classe"].ToString();
                    Classe classe = context.Classes.Where(cl => cl.Nom.Equals(nom_classe)).FirstOrDefault();
                    if (classe == null) throw new Exception("La classe " + nom_classe + " n'existe pas!");

                    string semaine_code = dt.Rows[i]["Semaine"].ToString();
                    Semaine semaine = context.Semaines.Where(semaine => semaine.Code.Equals(semaine_code)).FirstOrDefault();
                    if (semaine == null) throw new Exception("La Semaine " + semaine_code + " n'existe pas!");

                    Emploi emploi = context.Emplois.Where(emp => emp.Classe.Nom.Equals(nom_classe)).FirstOrDefault();
                    if (emploi == null) {
                        emploi = new Emploi() { Classe = classe, Semaine = semaine };
                        context.Emplois.Add(emploi);
                        context.SaveChanges();
                    }

                    string nom_module = dt.Rows[i]["Module"].ToString();
                    Module module = context.Modules.Where(m => m.NomModule.Equals(nom_module)).FirstOrDefault();
                    if (module == null) throw new Exception("Le module " + nom_module + " n'existe pas!");

                    string jour = dt.Rows[i]["Jour"].ToString();
                    double double_heure_debut = double.Parse(dt.Rows[i]["DebutSeance"].ToString());
                    var heure_debut = DateTime.FromOADate(double_heure_debut).TimeOfDay.ToString(@"hh\:mm");
                    double double_heure_fin = double.Parse(dt.Rows[i]["FinSeance"].ToString());
                    var heure_fin = DateTime.FromOADate(double_heure_fin).TimeOfDay.ToString(@"hh\:mm");


                    Seance seance = context.Seances.Where(seance => seance.Jour.ToLower().Equals(jour.ToLower())
                                                                    && seance.HeurDebut.Equals(heure_debut)
                                                                    && seance.HeurFin.Equals(heure_fin))
                                                   .FirstOrDefault();
                    if (seance == null) throw new Exception("La seance de " + jour + " de " + heure_debut + " a " + " n'est pas valide!");

                    Details_Emploi demp = new Details_Emploi() { Emploi = emploi, Module = module, Seance = seance};

                    context.details_Emplois.Add(demp);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportSeances(HSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string nom_classe = dt.Rows[i]["Classe"].ToString();
                    Classe classe = context.Classes.Where(cl => cl.Nom.Equals(nom_classe)).FirstOrDefault();
                    if (classe == null) throw new Exception("La classe " + nom_classe + " n'existe pas!");

                    string semaine_code = dt.Rows[i]["Semaine"].ToString();
                    Semaine semaine = context.Semaines.Where(semaine => semaine.Code.Equals(semaine_code)).FirstOrDefault();
                    if (semaine == null) throw new Exception("La Semaine " + semaine_code + " n'existe pas!");

                    Emploi emploi = context.Emplois.Where(emp => emp.Classe.Nom.Equals(nom_classe)).FirstOrDefault();
                    if (emploi == null)
                    {
                        emploi = new Emploi() { Classe = classe, Semaine = semaine };
                        context.Emplois.Add(emploi);
                        context.SaveChanges();
                    }

                    string nom_module = dt.Rows[i]["Module"].ToString();
                    Module module = context.Modules.Where(m => m.NomModule.Equals(nom_module)).FirstOrDefault();
                    if (module == null) throw new Exception("Le module " + nom_module + " n'existe pas!");

                    string jour = dt.Rows[i]["Jour"].ToString();
                    double double_heure_debut = double.Parse(dt.Rows[i]["DebutSeance"].ToString());
                    var heure_debut = DateTime.FromOADate(double_heure_debut).TimeOfDay.ToString(@"hh\:mm");
                    double double_heure_fin = double.Parse(dt.Rows[i]["FinSeance"].ToString());
                    var heure_fin = DateTime.FromOADate(double_heure_fin).TimeOfDay.ToString(@"hh\:mm");


                    Seance seance = context.Seances.Where(seance => seance.Jour.ToLower().Equals(jour.ToLower())
                                                                    && seance.HeurDebut.Equals(heure_debut)
                                                                    && seance.HeurFin.Equals(heure_fin))
                                                   .FirstOrDefault();
                    if (seance == null) throw new Exception("La seance de " + jour + " de " + heure_debut + " a " + " n'est pas valide!");

                    Details_Emploi demp = new Details_Emploi() { Emploi = emploi, Module = module, Seance = seance };

                    context.details_Emplois.Add(demp);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportSemaines(XSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);
           
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Semaine semaine = new Semaine();
                    semaine.Code = dt.Rows[i]["Code"].ToString();

                    var str_date_debut = double.Parse(dt.Rows[i]["Date debut"].ToString());
                    semaine.Date_debut = DateTime.FromOADate(str_date_debut);

                    var str_date_fin = double.Parse(dt.Rows[i]["date Fin"].ToString());
                    semaine.Date_fin = DateTime.FromOADate(str_date_fin);

                    context.Semaines.Add(semaine);
                }
            }
            context.SaveChanges();
            return dt;
        }

        public DataTable ImportSemaines(HSSFWorkbook workbook)
        {
            DataTable dt = workbookToDataTable(workbook);

            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Semaine semaine = new Semaine();
                    semaine.Code = dt.Rows[i]["Code"].ToString();

                    var str_date_debut = double.Parse(dt.Rows[i]["Date debut"].ToString());
                    semaine.Date_debut = DateTime.FromOADate(str_date_debut);

                    var str_date_fin = double.Parse(dt.Rows[i]["date Fin"].ToString());
                    semaine.Date_fin = DateTime.FromOADate(str_date_fin);

                    context.Semaines.Add(semaine);
                }
            }
            context.SaveChanges();
            return dt;
        }

        private DataTable workbookToDataTable(XSSFWorkbook workbook)
        {
            workbook.MissingCellPolicy = MissingCellPolicy.RETURN_BLANK_AS_NULL;

            var dt = new DataTable();
            ISheet sheet = workbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            rows.MoveNext();
            var current = (XSSFRow)rows.Current;
            for (int j = 0; j < (current.LastCellNum - current.FirstCellNum); j++)
            {
                dt.Columns.Add(current.Cells[j].StringCellValue);
            }

            while (rows.MoveNext())
            {
                XSSFRow current_row = (XSSFRow)rows.Current;
                if (string.IsNullOrEmpty(current_row.Cells[0].ToString())) continue;

                DataRow dr = dt.NewRow();
                for (int i = 0; i < (current_row.LastCellNum - current_row.FirstCellNum); i++)
                {
                    ICell cell = current_row.Cells[i];
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        if (cell.CellType == CellType.String)
                            dr[i] = cell.StringCellValue;
                        if (cell.CellType == CellType.Numeric)
                            dr[i] = cell.NumericCellValue;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private DataTable workbookToDataTable(HSSFWorkbook workbook)
        {
            workbook.MissingCellPolicy = MissingCellPolicy.RETURN_BLANK_AS_NULL;

            var dt = new DataTable();
            ISheet sheet = workbook.GetSheetAt(0);
            IEnumerator rows = sheet.GetRowEnumerator();
            rows.MoveNext();
            var current = (HSSFRow)rows.Current;
            for (int j = 0; j < (current.LastCellNum - current.FirstCellNum); j++)
            {
                dt.Columns.Add(current.Cells[j].StringCellValue);
            }

            while (rows.MoveNext())
            {
                HSSFRow current_row = (HSSFRow)rows.Current;
                if (string.IsNullOrEmpty(current_row.Cells[0].ToString())) continue;

                DataRow dr = dt.NewRow();
                for (int i = 0; i < (current_row.LastCellNum - current_row.FirstCellNum); i++)
                {
                    ICell cell = current_row.Cells[i];
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        if (cell.CellType == CellType.String)
                            dr[i] = cell.StringCellValue;
                        if (cell.CellType == CellType.Numeric)
                            dr[i] = cell.NumericCellValue;
                    }
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
