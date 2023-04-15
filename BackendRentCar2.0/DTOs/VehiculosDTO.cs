using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class VehiculosDTO
    {
        public int IdVehiculos { get; set; }
        [Required(ErrorMessage = "Debe competar la descripcion del vehiculo")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "La descripcion debe tener entre 3 y 60 caracteres")]
        public string Descripcion { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el numero de chasis")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "Nuemero de chasis debe tener entre 4 y 60 caracteres")]
        public string NoChasis { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el numero de motor")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El campo numero de motor  debe tener entre 2 y 60 caracteres.")]
        public string NoMotor { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar numero de placa")]
        [StringLength(60, MinimumLength = 5, ErrorMessage = "El numero de placa debe tener entre 5 y 60 caracteres.")]
        public string NoPlaca { get; set; } = null!;
        public int? TipoVehiculo { get; set; } 
        public string? NombreTipodeVehiculo { get; set; } 
        public int? Marca { get; set; }
        public string? NombreMarcadeVehiculo { get; set; } 
        public int? Modelo { get; set; }
        public string? NombreModelodeVehiculo { get; set; }
        public int? TipoCombustible { get; set; }
        public string? NombreTipoCombustible { get; set; }
        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo|Rentado)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string Estado { get; set; } = null!;
    }
}
