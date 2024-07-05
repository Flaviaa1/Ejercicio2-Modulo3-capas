using System.ComponentModel.DataAnnotations;

namespace EjercicioModulo3Clase2.Domain.DTOs
{
    public class TasksDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string DueDate { get; set; }
        [Required]

        public bool IsCompleted { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
