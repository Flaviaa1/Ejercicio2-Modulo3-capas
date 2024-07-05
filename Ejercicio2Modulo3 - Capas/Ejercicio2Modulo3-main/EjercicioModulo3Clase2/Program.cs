using EjercicioModulo3Clase2.Repository;
using EjercicioModulo3Clase2.servicios;
using EjercicioModulo3Clase2.servicios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EjercicioModulo3Clase2
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           var con= builder.Configuration.GetConnectionString("conexion1");
            builder.Services.AddDbContext<ToDoListDBContext>(opt => { 
            opt.UseSqlServer(con);
            });
            //conector de dependencias
            builder.Services.AddScoped<ITasksAervicios, TasksServicios>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}