using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.Models
{
    public partial class Empleado
    {
        public Empleado()
        {
            Inspeccions = new HashSet<Inspeccion>();
            Renta = new HashSet<Rentum>();
        }

        [Key]
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string TandaLabor { get; set; } = null!;
        public decimal PorcientoComision { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Inspeccion> Inspeccions { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
