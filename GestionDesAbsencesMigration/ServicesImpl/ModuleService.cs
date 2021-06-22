using GestionDesAbsencesMigration.Models;
using GestionDesAbsencesMigration.Models.Context;
using GestionDesAbsencesMigration.Services;
using Microsoft.EntityFrameworkCore;
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
            return context.Modules.Include(m => m.Professeur).Include(m => m.Classes);
        }

        public Module GetModuleById(int id)
        {
            return context.Modules.Include(m => m.Professeur)
                                  .Include(m => m.Classes)
                                  .Where(m => m.Id == id).FirstOrDefault();
        }

        public void Save(Module module, List<int> classes_ids)
        {
            var classes = context.Classes.Where(c => classes_ids.Contains(c.Id));
            foreach(var classe in classes)
                 module.Classes.Add(classe);

            context.Modules.Add(module);
            context.SaveChanges();
        }

        public void updateModule(Module module, List<int> classes_ids)
        {
            var newModule = context.Modules.Include(m => m.Professeur).Where(m => m.Id == module.Id).FirstOrDefault();
            if(classes_ids.Count() > 0)
            {

                var classes = context.Classes.Where(c => classes_ids.Contains(c.Id));
                newModule.Classes = new HashSet<Classe>();
                foreach (var classe in classes)
                    module.Classes.Add(classe);

            }
            newModule.NomModule = module.NomModule;
            newModule.id_Professeur = module.id_Professeur;
            context.SaveChanges();
        }
    }
}
