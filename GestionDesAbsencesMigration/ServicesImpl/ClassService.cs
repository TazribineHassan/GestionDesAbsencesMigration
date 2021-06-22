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
    public class ClassService : IClassService
    {
        private ApplicationContext context;

        public ClassService(ApplicationContext context)
        {
            this.context = context;
        }

        public void deleteClasse(int id)
        {
            var classe = context.Classes.Where(c => c.Id == id).FirstOrDefault();
            context.Classes.Remove(classe);
            context.SaveChanges();
        }

        public IEnumerable<Classe> getAll()
        {
            return context.Classes.Include( c => c.Cycle);
        }

        public Classe GetClasseById(int id)
        {
            return context.Classes.Where(c => c.Id == id).FirstOrDefault();
        }

        public void Save(Classe classe)
        {
            context.Classes.Add(classe);
            context.SaveChanges();
        }

        public void updateClasse(Classe classe)
        {
            var newModule = context.Classes.Where(m => m.Id == classe.Id).FirstOrDefault();
            newModule.Nom = classe.Nom;
            newModule.id_cycle = classe.id_cycle;
            context.SaveChanges();
        }
    }
}
