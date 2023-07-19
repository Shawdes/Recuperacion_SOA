using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Personas")]
    public class Persona
    {
        [Key] 
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(30)]
        public string Apellidos { get; set; }
        [Required]
        [StringLength(30)]
        public string CURP { get; set; }
        [Required]
        public DateTime Fecha_Nacimiento { get; set; }
        [Required]
        [StringLength(30)]
        [EmailAddress]
        public string Email { get; set; }

    }
}
