using System;
using System.Collections.Generic;

namespace BackendRentCar2._0.Models
{
    public partial class TiposdeVehiculo
    {
        public TiposdeVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdTiposVehiculo { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
