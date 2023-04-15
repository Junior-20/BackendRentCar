using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class EmpleadosDTO
    {
        public int IdEmpleado { get; set; }
        [Required(ErrorMessage = "Debe completar el nombre")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "El nombre debe tener entre 4 y 60 caracteres")]
        public string Nombre { get; set; } = null!;
        [Required]
        [CustomValidation(typeof(ClientesDTO), "validaCedula")]
        public string Cedula { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar tanda labor")]
        public string TandaLabor { get; set; } = null!;
        [Required(ErrorMessage = "Debe completar el porciento de comision")]
        [Range(0.01, double.MaxValue, ErrorMessage = "La comision debe ser mayor que 0")]
        [DisplayFormat(DataFormatString = "{0:P2}")]
        public decimal PorcientoComision { get; set; }
        [Required(ErrorMessage = "Debe completar la fecha de ingreso")]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de documento solo puede ser Disponible o Inactivo")]
        public string Estado { get; set; } = null!;
        public static ValidationResult validaCedula(string pCedula, ValidationContext context)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return new ValidationResult("La cédula debe tener 11 caracteres");

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return ValidationResult.Success;
            else
                return new ValidationResult("La cédula es inválida");
        }
    }
}
