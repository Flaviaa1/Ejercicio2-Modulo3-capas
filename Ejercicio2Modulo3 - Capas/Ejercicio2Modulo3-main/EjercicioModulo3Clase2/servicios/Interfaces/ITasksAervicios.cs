using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace EjercicioModulo3Clase2.servicios.Interfaces
{
    public interface ITasksAervicios
    {
        public List<Tasks> GetTasks();
       public void AddTask(Tasks nuevo);
       public void UpdateTask(int id, bool isC);
        public void UpdateTaskInt(int id, int isAc);
    }
}
