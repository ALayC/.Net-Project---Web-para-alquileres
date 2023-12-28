using Microsoft.AspNetCore.Authentication.Cookies;
using Obligatorio_MVC.Servicios;

namespace Obligatorio_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); // Consider increasing this if necessary
            });

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Login"; // The path to the login action
                    options.AccessDeniedPath = "/Home/AccessDenied"; // The path to the access denied action
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
                });

            // Register your services
            builder.Services.AddScoped<ICabanaService, CabanaService>();
            builder.Services.AddScoped<IMantenimientoService, MantenimientoService>();
            builder.Services.AddScoped<ITipoCabanaService, TipoCabanaService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication(); // This should come before UseAuthorization
            app.UseAuthorization();

            // Define the default route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}");

            app.Run();
        }
    }
}
