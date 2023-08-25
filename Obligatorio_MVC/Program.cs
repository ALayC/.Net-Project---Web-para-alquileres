
using Obligatorio_MVC.Servicios;

namespace Obligatorio_MVC
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //// Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(opciones =>
            {

                opciones.IdleTimeout = TimeSpan.FromSeconds(30);
            });


            builder.Services.AddScoped<ICabanaService, CabanaService> ();
            builder.Services.AddScoped<IMantenimientoService, MantenimientoService> ();
            builder.Services.AddScoped<ITipoCabanaService, TipoCabanaService> ();
            builder.Services.AddScoped<IUsuarioService, UsuarioService> ();

            

             var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
