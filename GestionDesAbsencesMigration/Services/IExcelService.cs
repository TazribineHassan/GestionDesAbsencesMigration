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
        DataTable ImportEtudiants(DataTable dt, XSSFWorkbook workbook, int class_id);
        DataTable ImportEtudiants(DataTable dt, HSSFWorkbook workbook, int class_id);
        DataTable ImportProfesseurs(DataTable dt, XSSFWorkbook workbook);
        DataTable ImportProfesseurs(DataTable dt, HSSFWorkbook workbook);
    }
}
