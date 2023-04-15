using System;
using System.Collections.Generic;

namespace BackendRentCar2._0.Models
{
    public partial class Rentum
    {
        public int IdRenta { get; set; }
        public int? DocGarantia { get; set; }
        public int Empleado { get; set; }
        public int Vehiculo { get; set; }
        public int Cliente { get; set; }
        public DateTime FechaRenta { get; set; }
        public DateTime FechaDevolucion { get; set; }
        public decimal MontoxDia { get; set; }
        public decimal CantidadDias { get; set; }
        public decimal? Abono { get; set; }
        public string Comentario { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual Cliente ClienteNavigation { get; set; } = null!;
        public virtual Documento? DocGarantiaNavigation { get; set; }
        public virtual Empleado EmpleadoNavigation { get; set; } = null!;
        public virtual Vehiculo VehiculoNavigation { get; set; } = null!;
    }
}
