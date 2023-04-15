using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class TiposdeVehiculosDTO 
    {
        public int IdTiposVehiculo { get; set; }
        [Required(ErrorMessage = "Debe completar el nombre de tipo de vehiculo")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El tipo de vehiculo debe tener entre 3 y 60 caracteres.")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string Estado { get; set; } = null!;
    }
}
