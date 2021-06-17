using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionDesAbsencesMigration.Models
{
    public class User
    {
        public int Id { get; set; }
        
        [StringLength(50)]
        public string Nom { get; set; }
        
        [Required]
        public string Prenom { get; set; }        
        
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        public string Email { get; set; }

        
    }
}
