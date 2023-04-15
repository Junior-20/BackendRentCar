using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class DocumentoDTO
    {
        public int IdDocumento { get; set; }
        [Required(ErrorMessage = "Debe completar la descripcion")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "la descripcion debe tener entre 4 y 60 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string? Estado { get; set; }
    }
}
