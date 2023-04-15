using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class ModelosDTO
    {
        public int IdModelo { get; set; }
        public int? IdMarca { get; set; }
        public string? Nombredemarca { get; set; }
        [Required(ErrorMessage = "Debe completar el nombre del modelo")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El campo Descripcion debe tener entre 2 y 60 caracteres")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string Estado { get; set; } = null!;
    }
}
