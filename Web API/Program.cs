
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Obligatorio_AccesoDatos;
using Obligatorio_AccesoDatos.EntityFrameWork;
using Obligatorio_Aplicacion.CasosUso;
using Obligatorio_Aplicacion.InterfacesCasoUso;
using Obligatorio_Aplicacion.Servicios;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace Web_API
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
            builder.Services.AddSwaggerGen(opciones => {
                opciones.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme() { 
                
                    Description="Autorizacion estandar mediante esquema Barer",
                    In=ParameterLocation.Header,
                    Name="Authorization",
                    Type=SecuritySchemeType.ApiKey
                
                });

                opciones.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opciones =>
            {
                opciones.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:SecretTokenKey").Value!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });

            builder.Services.AddDbContext<ObligatorioDBContext>(opciones =>
            {
                opciones.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

            });

            builder.Services.AddScoped<ICabanaRepositorio, CabanaRepositorio >();
            builder.Services.AddScoped<IMantenimientoRepositorio, MantenimientoRepositorio>();
            builder.Services.AddScoped<ITipoCabanaRepositorio, TipoCabanaRepositorio>();
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<IBuscarTodasCabanas, BuscarTodas>();
            builder.Services.AddScoped<IBuscarCabanasHabilitadas, BuscarCabanasHabilitadas>();
            builder.Services.AddScoped<ICabanaObtenerPorCantidadMaxima, CabanaObtenerPorCantidadMaxima>();
            builder.Services.AddScoped<IBuscarCabanaPorTipo, BuscarCabanaPorTipo>();
            builder.Services.AddScoped<IBuscarPorNombre, BuscarPorNombre>();
            builder.Services.AddScoped<IMantenimientoObtenerTodos, MantenimientoObtenerTodos>();
            builder.Services.AddScoped<IBuscarMantenimientoEntreFechas, BuscarMantenimientoEntreFechas>();
            builder.Services.AddScoped<IRegistroMantenimiento, RegistroMantenimiento>();
            builder.Services.AddScoped<IBuscarUsuarioLogin, BuscarUsuarioLogin>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //autentication siempre va antes que autorizacion

            app.UseAuthentication();    
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}