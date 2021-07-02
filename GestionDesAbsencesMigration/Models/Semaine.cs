using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionDesAbsencesMigration.Models
{
    public class Semaine
    {

        public Semaine()
        {
            this.Emplois = new HashSet<Emploi>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date_debut { get; set; }
        public DateTime Date_fin { get; set; }

        public virtual ICollection<Emploi> Emplois { get; set; }
    }
}