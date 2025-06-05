using System.ComponentModel.DataAnnotations;

namespace ProyectoGastosAPI.Models
{
    public class Gasto
    {
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor a 0.")]
        public decimal Monto { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "La descripción debe tener entre 3 y 250 caracteres.")]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Gasto), nameof(ValidarFechaNoFutura))]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "El nombre del comercio debe tener como máximo 250 caracteres.")]
        public string NombreComercio { get; set; }

        public static ValidationResult? ValidarFechaNoFutura(DateTime fecha, ValidationContext context)
        {
            if (fecha > DateTime.Today)
                return new ValidationResult("La fecha no puede ser futura.");
            return ValidationResult.Success;
        }
    }
}
