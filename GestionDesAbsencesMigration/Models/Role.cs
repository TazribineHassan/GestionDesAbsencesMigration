﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GestionDesAbsencesMigration.Models
{
    public class Role
    {

        public Role()
        {
            Professeurs = new HashSet<Professeur>();
        }

        public int Id { get; set; }
        public String Nome { get; set; }

        public virtual ICollection<Professeur> Professeurs { get; set; }
        public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Administrateur> Administrateurs { get; set; }

    }
}