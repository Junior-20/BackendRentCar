using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRentCar2._0.Models
{
    public partial class Documento
    {
        public Documento()
        {
            Renta = new HashSet<Rentum>();
        }
        
        public int IdDocumento { get; set; }
        public string? Descripcion { get; set; }
        public string? Estado { get; set; }

        public virtual ICollection<Rentum> Renta { get; set; }
    }
}
