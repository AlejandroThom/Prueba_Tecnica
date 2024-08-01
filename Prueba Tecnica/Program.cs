
using CasosDeUso.CUPosts.Implementacion;
using CasosDeUso.CUPosts.Interfaces;
using CasosDeUso.CUUsuarios.Implementacion;
using CasosDeUso.CUUsuarios.Interfaces;
using LogicaAccesoADatos.IRepositorio;
using LogicaAccesoADatos.Repositorios;

namespace Prueba_Tecnica
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            builder.Services.AddScoped<ICUSeguirUsuario, CUSeguirUsuario>();
            builder.Services.AddScoped<ICUVerificarSeguidorDeUsuario,CUVerificarSeguidorDeUsuario>();
            builder.Services.AddScoped<ICUObtenerUsuario,CUObtenerUsuario>();
            builder.Services.AddScoped<ICUObtenerSeguidosDeUsuario,CUObtenerSeguidosDeUsuario>();

            builder.Services.AddScoped<IRepositorioPost, RepositorioPost>();

            builder.Services.AddScoped<ICUCrearPost, CUCrearPost>();
            builder.Services.AddScoped<ICUObtenerPostsDeUsuarios, CUObtenerPostsDeUsuarios>();
            builder.Services.AddScoped<ICUObtenerPostPorId, CUObtenerPostPorId>();


            builder.Services.AddSwaggerGen(option => option.IncludeXmlComments("PruebaTecnica.xml"));

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
