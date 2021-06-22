using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.ServicesImpl
{
    public class ModuleService : IModuleService
    {
        private ApplicationContext context;

        public ModuleService(ApplicationContext context)
        {
            this.context = context;
        }

        public void deleteModule(int id)
        {
            var module = context.Modules.Where(m => m.Id == id).FirstOrDefault();
            context.Modules.Remove(module);
            context.SaveChanges();
        }

        public IEnumerable<Module> getAll()
        {
            return context.Modules;
        }

        public Module GetModuleById(int id)
        {
            return context.Modules.Where(m => m.Id == id).FirstOrDefault();
        }

        public void Save(Module module)
        {
            context.Modules.Add(module);
            context.SaveChanges();
        }

        public void updateModule(Module module)
        {
            var newModule = context.Modules.Where(m => m.Id == module.Id).FirstOrDefault();
            newModule.NomModule = module.NomModule;
            newModule.id_Professeur = module.id_Professeur;
            context.SaveChanges();
        }
    }
}
