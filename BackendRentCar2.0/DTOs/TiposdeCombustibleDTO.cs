using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class TiposdeCombustibleDTO
    {
        public int IdTiposCombustible { get; set; }
        [Required(ErrorMessage = "Debe completar el nombre del tipo de combustible")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El tipo de combustible debe tener entre 3 y 60 caracteres.")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string Estado { get; set; } = null!;
    }
}
