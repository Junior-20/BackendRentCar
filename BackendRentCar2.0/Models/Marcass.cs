using System;
using System.Collections.Generic;

namespace BackendRentCar2._0.Models
{
    public partial class Marcass
    {
        public Marcass()
        {
            Modelos = new HashSet<Modelo>();
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdMarca { get; set; }
        public string Descripcion { get; set; } = null!;
        public string Estado { get; set; } = null!;

        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
