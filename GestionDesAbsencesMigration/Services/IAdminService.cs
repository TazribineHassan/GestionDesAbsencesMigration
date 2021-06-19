﻿using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.services
{
    public interface IAdminService
    {

        public Administrateur GetAdminByEmail(string email);
        void Save(Administrateur admin);
        void saveEtudiant(Etudiant e);
        void deleteEtudiant(Etudiant e);
        void updateEtudiant(Etudiant e);
        List<StudentsList> GetStudentsList(int id_seance, int id_module, int id_semaine);
        bool UpdateAbsence(int id_absence, bool est_present);

        List<EtudiantAbsent> absenceList();


    }
}