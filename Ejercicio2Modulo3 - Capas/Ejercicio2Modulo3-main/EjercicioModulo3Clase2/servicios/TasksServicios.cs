using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Domain.Entity;
using EjercicioModulo3Clase2.Repository;
using EjercicioModulo3Clase2.servicios.Interfaces;

namespace EjercicioModulo3Clase2.servicios
{
    public class TasksServicios:ITasksAervicios
    {
        private readonly ToDoListDBContext _context;
       
        public TasksServicios(ToDoListDBContext contexto) { 
            _context = contexto;
        }
        public List<Tasks> GetTasks()
        {
            return _context.Tasks.ToList();
        }
        public void AddTask(Tasks nuevo)
        {
            _context.Tasks.Add(nuevo);
            _context.SaveChanges(); 
        }
        public void UpdateTask(int id, bool isC)
        {
            var existe = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (existe != null)
            {
                existe.IsCompleted = isC;
                _context.SaveChanges(); 
            }
        }
        public void UpdateTaskInt(int id, int isAc)
        {
            var existe1 = _context.Tasks.FirstOrDefault(t => t.Id == id);

            if (existe1 != null)
            {
                bool mt;
                if (isAc == 1) {

                    mt = true;
                }else
                {
                    mt = false;
                }

                existe1.IsActive = mt;
                _context.SaveChanges();
            }
        }

    }
}
