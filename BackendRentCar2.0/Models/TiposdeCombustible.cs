using System;
using System.Collections.Generic;

namespace BackendRentCar2._0.Models
{
    public partial class TiposdeCombustible
    {
        public TiposdeCombustible()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdTiposCombustible { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
