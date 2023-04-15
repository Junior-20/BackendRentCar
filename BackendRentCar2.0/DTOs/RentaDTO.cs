
using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class RentaDTO
    {
        public int IdRenta { get; set; }
        public int? DocGarantia { get; set; }
        public string? DocCliente { get; set; }
        public int Empleado { get; set; }
        public string? NombredeEmpleado { get; set; }
        public int Vehiculo { get; set; }
        public string? NombredeVehiculo { get; set; }
        public int Cliente { get; set; }
        public string? NombredeCliente { get; set; }
        [Required(ErrorMessage = "Debe completar la fecha de la renta")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaRenta { get; set; }
        [Required(ErrorMessage = "Debe completar la fecha de devolucion")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CustomValidation(typeof(RentaDTO), "ValidarFechaDevolucion")]
        public DateTime FechaDevolucion { get; set; }
        [Required(ErrorMessage = "Debe completar el campo monto por dia")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo monto por dia debe ser mayor que 0")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal MontoxDia { get; set; }
        [Required(ErrorMessage = "Debe completar la cantidad de dias")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad de dias debe ser mayor que 0")]
        public int CantidadDias { get; set; }
        [Required(ErrorMessage = "Debe completar el campo de abono")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El abono debe ser mayor que 0")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Abono { get; set; }
        [Required(ErrorMessage = "Debe completar el campo de comentario")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "El campo Comentario debe tener entre 3 y 60 caracteres")]
        public string Comentario { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo|Rentado)$", ErrorMessage = "El tipo de documento solo puede ser Disponible,Inactivo o Rentado")]
        public string Estado { get; set; } = null!;
        public static ValidationResult ValidarFechaDevolucion(DateTime fechaDevolucion, ValidationContext context)
        {
            var instancia = context.ObjectInstance as RentaDTO;
            if (fechaDevolucion < instancia.FechaRenta)
            {
                return new ValidationResult("La fecha de devolución debe ser posterior o igual a la fecha de renta");
            }
            return ValidationResult.Success;
        }
    }
}
