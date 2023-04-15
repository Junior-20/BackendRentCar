using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.Models
{
    public partial class Inspeccion
    {
        [Key]
        public int IdTransaccion { get; set; }
        public int Vehiculo { get; set; }
        public int IdCliente { get; set; }
        public string TieneRalladuras { get; set; } = null!;
        public string CantidadCombustible { get; set; } = null!;
        public string GomaRespuesta { get; set; } = null!;
        public string Gato { get; set; } = null!;
        public string Roturas { get; set; } = null!;
        public string EstadoGomas { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int EmpleadoInspeccion { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Empleado EmpleadoInspeccionNavigation { get; set; } = null!;
        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Vehiculo VehiculoNavigation { get; set; } = null!;
    }
}
