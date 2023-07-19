using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("Activos")]
    public class Activo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        public bool Estatus { get; set; }
        public virtual ICollection<Activo_Empleado> Activo_Empleados { get; set; }

    }
}
