﻿using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using NPOI.HSSF.UserModel;
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

        public DataTable ImportEtudiants(DataTable dt, XSSFWorkbook workbook, int class_id)
        {
            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
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
                DataRow dr = dt.NewRow();
                for (int i = 0; i < (current_row.LastCellNum - current_row.FirstCellNum); i++)
                {
                    NPOI.SS.UserModel.ICell cell = current_row.Cells[i];
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        if(cell.CellType == NPOI.SS.UserModel.CellType.String)
                            dr[i] = cell.StringCellValue;
                        if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
                            dr[i] = cell.NumericCellValue;
                    }
                }
                dt.Rows.Add(dr);
            }
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

        public DataTable ImportEtudiants(DataTable dt, HSSFWorkbook workbook, int class_id)
        {
            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
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
                DataRow dr = dt.NewRow();
                for (int i = 0; i < (current_row.LastCellNum - current_row.FirstCellNum); i++)
                {
                    NPOI.SS.UserModel.ICell cell = current_row.Cells[i];
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        if (cell.CellType == NPOI.SS.UserModel.CellType.String)
                            dr[i] = cell.StringCellValue;
                        if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
                            dr[i] = cell.NumericCellValue;
                    }
                }
                dt.Rows.Add(dr);
            }
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

        public DataTable ImportProfesseurs(DataTable dt, XSSFWorkbook workbook)
        {
            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
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
                DataRow dr = dt.NewRow();
                for (int i = 0; i < (current_row.LastCellNum - current_row.FirstCellNum); i++)
                {
                    NPOI.SS.UserModel.ICell cell = current_row.Cells[i];
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        if (cell.CellType == NPOI.SS.UserModel.CellType.String)
                            dr[i] = cell.StringCellValue;
                        if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
                            dr[i] = cell.NumericCellValue;
                    }
                }
                dt.Rows.Add(dr);
            }
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Professeur p = new Professeur();
                    p.Nom = dt.Rows[i]["Nom"].ToString();
                    p.Prenom = dt.Rows[i]["Prenom"].ToString();
                    p.Code_prof = dt.Rows[i]["Code"].ToString();
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

        public DataTable ImportProfesseurs(DataTable dt, HSSFWorkbook workbook)
        {
            NPOI.SS.UserModel.ISheet sheet = workbook.GetSheetAt(0);
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
                DataRow dr = dt.NewRow();
                for (int i = 0; i < (current_row.LastCellNum - current_row.FirstCellNum); i++)
                {
                    NPOI.SS.UserModel.ICell cell = current_row.Cells[i];
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        if (cell.CellType == NPOI.SS.UserModel.CellType.String)
                            dr[i] = cell.StringCellValue;
                        if (cell.CellType == NPOI.SS.UserModel.CellType.Numeric)
                            dr[i] = cell.NumericCellValue;
                    }
                }
                dt.Rows.Add(dr);
            }
            if (dt != null && dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Professeur p = new Professeur();
                    p.Nom = dt.Rows[i]["Nom"].ToString();
                    p.Prenom = dt.Rows[i]["Prenom"].ToString();
                    p.Code_prof = dt.Rows[i]["Code"].ToString();
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
    }
}
