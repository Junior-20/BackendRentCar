using System.ComponentModel.DataAnnotations;

namespace BackendRentCar2._0.DTOs
{
    public class ClientesDTO
    {
        public int Idcliente { get; set; }
        [Required(ErrorMessage = "Debe completar el nombre")]
        [StringLength(60, MinimumLength = 4, ErrorMessage = "El nombre debe tener entre 4 y 60 caracteres")]
        public string Nombre { get; set; } = null!;

        [Required]
        [CustomValidation(typeof(ClientesDTO), "validaCedula")]
        public string Cedula { get; set; } = null!;

        [Required(ErrorMessage = "Debe completar el tipo de persona")]
        [RegularExpression("^(Fisica|Juridica)$", ErrorMessage = "El tipo de persona solo puede ser Fisica o Juridica")]
        public string TipoPersona { get; set; } = null!;

        [Required(ErrorMessage = "Debe completar el numero de la tarjeta de credito o debito")]
        public string NoTarjetaCr { get; set; } = null!;

        [Required(ErrorMessage = "Debe completar el limite de credito")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El límite de crédito debe ser mayor que 0")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal LimiteCredito { get; set; }

        [Required(ErrorMessage = "Debe completar el estado")]
        [RegularExpression("^(Disponible|Inactivo)$", ErrorMessage = "El tipo de persona solo puede ser Disponible o Inactivo")]
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
