using EjercicioModulo3Clase2.Domain.DTOs;
using EjercicioModulo3Clase2.Domain.Entity;
using EjercicioModulo3Clase2.Repository;
using EjercicioModulo3Clase2.servicios;
using EjercicioModulo3Clase2.servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Threading.Tasks;

namespace EjercicioModulo3Clase2.Controllers
{
    [Route( "v1" )]
    [ApiController]
    public class TaskController : ControllerBase
        
    {
        public ITasksAervicios _tasksServicios;
       // public ToDoListDBContext _context;

         public TaskController(ITasksAervicios taskservicios) { 

       
        _tasksServicios = taskservicios;
            
    }

    #region Pasos previos
    /*
     * 1 - Instalar EF Core y EF Core SQL Server
     * 2 - Crear contexto de base de datos y los modelos. Se puede usar Ingenieria Inversa de EF Core Power Tools
     * 3 - Configurar la inyección de dependencia del contexto tanto en Program.cs como en el controlador. No olvidar el string de conexión.
     * 4 - Las rutas de los endpoints queda a criterio de cada uno.
     * 5 - En este controlador, realizar los siguientes ejercicios:
     */
    #endregion

    #region Ejercicio 1
    // Crear un endpoint para obtener un listado de todas las tareas usando HTTP GET
    [HttpGet]
        [Route("lista")]
        public IActionResult listaTask() {
            
            var result=_tasksServicios.GetTasks();
                       return Ok(result);
                    }
        #endregion

        #region Ejercicio 2
        // Crear un endpoint para obtener una tarea por ID usando HTTP GET
        [HttpGet]
        [Route("lista/{id}")]
        public IActionResult listaTask2([FromRoute]  int id )
        {
            // var task = _context.Tasks.Where( a=> a.Id == id ).FirstOrDefault();
            var result2 = _tasksServicios.GetTasks();
            var task =result2.Where(a => a.Id == id).FirstOrDefault();
            return Ok( task );
        }
        #endregion

        #region Ejercicio 3
        // Crear un endpoint para crear una nueva tarea usando HTTP POST

        [HttpPost("agregar")]
        public IActionResult createT([FromBody] TasksDTO task )
        {
            if (task == null)
            {
                return BadRequest("La tarea no puede estar vacía.");
            }
            var nuevo= new Tasks() { 
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            IsCompleted = task.IsCompleted,
            IsActive = task.IsActive
            
            };
            _tasksServicios.AddTask(nuevo);
            return Ok( nuevo );
            
        }

       
        
        #endregion

        #region Ejercicio 4
        // Crear un endpoint para marcar una tarea como completada usando HTTP PUT
        [HttpPut("{id}")]
        public IActionResult updateTt([FromRoute] int id,[FromBody] modiT task) {

            //var tarea=_context.Tasks.FirstOrDefault(t=>t.Id == id);
            if (task == null)
            {
                return BadRequest("debe llenar el campo si o si.");
            }

            var exiTasks = _tasksServicios.GetTasks();
            var existe = exiTasks.FirstOrDefault(t => t.Id == id);

            if (existe == null)
            {
                return NotFound("Tarea no encontrada.");
            }

            
            _tasksServicios.UpdateTask(id, task.IsCompleted);

            
            return Ok(existe);
        }
    

        #endregion
        #region Ejercicio 5
        // Crear un endpoint para dar de baja una tarea usando HTTP PUT (baja lógica)
        [HttpPut("{id}/tarea")]
        public IActionResult updateT([FromRoute] int id, [FromBody] bagLog act)
        {

            if (act == null)
            {
                return BadRequest("debe llenar el campo si o si.");
            }

            var exiTasks = _tasksServicios.GetTasks();
            var existe = exiTasks.FirstOrDefault(t => t.Id == id);

            if (existe == null)
            {
                return NotFound("no se encontro ninguna trea.");
            }
            _tasksServicios.UpdateTaskInt(id, act.IsActive);
            return Ok();
        }
        #endregion
    }
}
