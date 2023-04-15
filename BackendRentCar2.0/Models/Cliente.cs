using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Inspeccions = new HashSet<Inspeccion>();
            Renta = new HashSet<Rentum>();
        }
      
        public int IdCliente { get; set; }
        public string Nombre { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string TipoPersona { get; set; } = null!;
        public string NoTarjetaCr { get; set; } = null!;
        public decimal LimiteCredito { get; set; }
        public string Estado { get; set; } = null!;

        public virtual ICollection<Inspeccion> Inspeccions { get; set; }
        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
