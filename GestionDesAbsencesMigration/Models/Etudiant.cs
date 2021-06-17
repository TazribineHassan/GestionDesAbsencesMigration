﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsencesMigration.Models
{
    public class Etudiant
    {
        public Etudiant()
        {
            this.Absences = new HashSet<Absence>();
        }

        public int Id { get; set; }
        public string Cne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        [ForeignKey("Role")]
        public Nullable<int> Role_Id { get; set; }

        public virtual Role Role { get; set; }

        [ForeignKey("Groupe")]
        public int? Id_groupe { get; set; }

        [ForeignKey("Classe")]
        public int? Id_classe { get; set; }


        public virtual Groupe Groupe { get; set; }
        public virtual Classe Classe { get; set; }
        public virtual ICollection<Absence> Absences { get; set; }


    }
}