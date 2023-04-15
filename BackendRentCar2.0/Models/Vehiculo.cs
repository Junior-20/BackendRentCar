using System;
using System.Collections.Generic;

namespace BackendRentCar2._0.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Inspeccions = new HashSet<Inspeccion>();
            Renta = new HashSet<Rentum>();
        }

        public int IdVehiculos { get; set; }
        public string Descripcion { get; set; } = null!;
        public string NoChasis { get; set; } = null!;
        public string NoMotor { get; set; } = null!;
        public string NoPlaca { get; set; } = null!;
        public int TipoVehiculo { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int TipoCombustible { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Marcass MarcaNavigation { get; set; } = null!;
        public virtual Modelo ModeloNavigation { get; set; } = null!;
        public virtual TiposdeCombustible TipoCombustibleNavigation { get; set; } = null!;
        public virtual TiposdeVehiculo TipoVehiculoNavigation { get; set; } = null!;
        public virtual ICollection<Inspeccion> Inspeccions { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
