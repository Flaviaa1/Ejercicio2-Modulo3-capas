using System.ComponentModel.DataAnnotations;

namespace EjercicioModulo3Clase2.Domain.DTOs
{
    public class bagLog
    {
        [Required(ErrorMessage ="debes poner 1 o 0")]
        public int IsActive { get; set; }
    }
}
