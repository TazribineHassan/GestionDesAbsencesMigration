using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionDesAbsencesMigration.Models
{
    public class Emploi
    {

        public Emploi()
        {
            Details_Emplois = new HashSet<Details_Emploi>();
        }
        
        public int Id { get; set; }

        [ForeignKey("Semaine")]
        public int Semaine_Id { get; set; }

        public virtual Semaine Semaine { get; set; }


        [ForeignKey("Classe")]
        public int Classe_Id { get; set; }

        public virtual Classe Classe { get; set; }

        public virtual ICollection<Details_Emploi> Details_Emplois { get; set; }

    }

}