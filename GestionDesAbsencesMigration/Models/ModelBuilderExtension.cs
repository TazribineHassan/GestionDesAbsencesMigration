using GestionDesAbsencesMigration.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Models
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // add roles
            modelBuilder.Entity<Role>().HasData(
                    new Role { Id = 1, Nom = "admin" },
                    new Role { Id = 2, Nom = "professeur" },
                    new Role { Id = 3, Nom = "etudiant" }
                );

            //add admin
            modelBuilder.Entity<Administrateur>().HasData(
                     new Administrateur()
                     {
                         Id = 1,
                         Email = "admin@gmail.com",
                         Nom = "Admin",
                         Prenom = "admin",
                         Password = Encryption.Encrypt("admin"),
                         Role_Id = 1
                     }
                );

            // add seances
            string[] jours = { "Lundi", "Mardi", "Mercredi", "Jeudi", "Vendredi", "Samedi", "Dimanche" };
            var seances = new List<Seance>();
            int seance_id = 0;
            for (int i = 0; i < 7; i++)
            {
                seances.Add(new Seance() { id = ++seance_id, Jour = jours[i], HeurDebut = "08:00", HeurFin = "10:00" });
                seances.Add(new Seance() { id = ++seance_id, Jour = jours[i], HeurDebut = "10:00", HeurFin = "12:00" });
                seances.Add(new Seance() { id = ++seance_id, Jour = jours[i], HeurDebut = "12:00", HeurFin = "14:00" });
                seances.Add(new Seance() { id = ++seance_id, Jour = jours[i], HeurDebut = "14:00", HeurFin = "16:00" });
                seances.Add(new Seance() { id = ++seance_id, Jour = jours[i], HeurDebut = "16:00", HeurFin = "18:00" });
            }

            modelBuilder.Entity<Seance>().HasData(seances.ToArray());

            // add cycles
            modelBuilder.Entity<Cycle>().HasData(new Cycle() { Id = 1, Nom = "CP" },
                                                 new Cycle() { Id = 2, Nom = "CI" });

            // add groupes
            modelBuilder.Entity<Groupe>().HasData( new Groupe() { Id = 1, Nom = "Groupe 1" },
                                                   new Groupe() { Id = 2, Nom = "Groupe 2" },
                                                   new Groupe() { Id = 3, Nom = "Groupe 3" },
                                                   new Groupe() { Id = 4, Nom = "Groupe 4" },
                                                   new Groupe() { Id = 5, Nom = "Groupe 5" }); 
        }
    }
}
