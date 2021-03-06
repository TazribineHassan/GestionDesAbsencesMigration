using GestionDesAbsencesMigration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Services
{
    public interface IModuleService
    {
        IEnumerable<Module> getAll();
        void Save(Module module, List<int> classes_ids);
        Module GetModuleById(int id);
        void deleteModule(int id);
        void updateModule(Module module, List<int> classes_ids);
    }
}
