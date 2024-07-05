using System.ComponentModel.DataAnnotations;

namespace EjercicioModulo3Clase2.Domain.DTOs
{
    public class modiT
    {
        [Required (ErrorMessage ="se debe colocar true como copletado  o false como no completado ")]
        public bool IsCompleted { get; set; }
    }
}
