using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Activo-Empleado")]
    public class Activo_Empleado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Id_Empleado { get; set; }
        [ForeignKey("Id_Empleado")]
        public Empleado empleado { get; set; }

        [Required]
        public int Id_Activo { get; set; }

        [ForeignKey("Id_Activo")]
        public Activo activo { get; set; }

        [Required]
        public DateTime Fecha_Asignacion { get; set; }

        [Required]
        public DateTime Fecha_Liberacion { get; set; }

        [Required]
        public DateTime Fecha_Entrega { get; set; }
    }
}
