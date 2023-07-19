using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Empleado: Persona
    {
        [Required]
        public int Numero_Empleado { get; set; }
        [Required]
        public DateTime Fecha_Ingreso { get; set; }
        [Required]
        public bool Estatus { get; set; }
        public virtual ICollection<Activo_Empleado> Activo_Empleados { get; set; }

    }
}
