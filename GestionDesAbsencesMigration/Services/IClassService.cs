using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    interface IClassService
    {
        IEnumerable<Classe> getAll();
        void Save(Classe classe);
        Classe GetClasseById(int id);
        void deleteClasse(int id);
        void updateClasse(Classe classe);
    }
}

