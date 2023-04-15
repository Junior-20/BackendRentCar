using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class InspeccionDTO
    {
        public int IdTransaccion { get; set; }
        public int Vehiculo { get; set; }
        public string? NombredeVehiculo { get; set; }
        public int IdCliente { get; set; }
        public string? NombredeCliente { get; set; }
        [Required(ErrorMessage = "Debe completar tiene ralladuras")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Tiene Ralladuras debe tener entre 2 y 60 caracteres")]
        public string TieneRalladuras { get; set; } = null!;

        [Required(ErrorMessage = "Debe completar la cantidad de combustible")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Cantidad de combustible debe tener entre 2 y 60 caracteres")]
        public string CantidadCombustible { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar las gomas de repuesto")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Gomas de Repuesta debe tener entre 2 y 60 caracteres.")]
        public string GomaRespuesta { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el campo gato")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El campo Gato debe tener entre 2 y 60 caracteres.")]
        public string Gato { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar roturas")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El campo roturas debe tener entre 2 y 60 caracteres.")]
        public string Roturas { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el campo estado de gomas")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El campo Estado de Gomas debe tener entre 2 y 60 caracteres.")]
        public string EstadoGomas { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar la fecha de inspeccion")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        public int EmpleadoInspeccion { get; set; }
        public string? NombredeEmpleado { get; set; }

        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string Estado { get; set; } = null!;
    }
}
