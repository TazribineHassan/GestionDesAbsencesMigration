using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionDesAbsencesMigration.Models
{
    public class EtudiantAbsent
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public int absence_count { get; set; }


    }
}