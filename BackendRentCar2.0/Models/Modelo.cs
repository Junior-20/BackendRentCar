using System;
using System.Collections.Generic;

namespace BackendRentCar2._0.Models
{
    public partial class Modelo
    {
        public Modelo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdModelo { get; set; }
        public int IdMarca { get; set; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; } = null!;

        public virtual Marcass IdMarcaNavigation { get; set; } = null!;
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
