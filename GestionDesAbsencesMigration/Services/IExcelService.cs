using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public interface IExcelService
    {
        // Import Etudiants
        DataTable ImportEtudiants(XSSFWorkbook workbook, int class_id);
        DataTable ImportEtudiants(HSSFWorkbook workbook, int class_id);

        // Import Professeurs
        DataTable ImportProfesseurs(XSSFWorkbook workbook);
        DataTable ImportProfesseurs(HSSFWorkbook workbook);

        //Importer Classes
        DataTable ImportClasses(XSSFWorkbook workbook);
        DataTable ImportClasses(HSSFWorkbook workbook);

        // Import Modules
        DataTable ImportModules(XSSFWorkbook workbook);
        DataTable ImportModules(HSSFWorkbook workbook);

        // Import Semaines
        DataTable ImportSemaines(XSSFWorkbook workbook);
        DataTable ImportSemaines(HSSFWorkbook workbook);

        // Import Seances
        DataTable ImportSeances(XSSFWorkbook workbook);
        DataTable ImportSeances(HSSFWorkbook workbook);
    }
}
