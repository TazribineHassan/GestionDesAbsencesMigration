using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsencesMigration.Models
{
    public class Administrateur
    {
        [Key]
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [ForeignKey("Role")]
        public Nullable<int> Role_Id { get; set; }

        public virtual Role Role { get; set; }
    }
}