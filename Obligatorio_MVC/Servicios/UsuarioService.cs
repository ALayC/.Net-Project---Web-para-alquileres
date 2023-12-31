﻿using Microsoft.AspNetCore.Mvc;
using Obligatorio_MVC.Models;
using System.Text;

namespace Obligatorio_MVC.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IConfiguration configuration;
        private readonly string usuarioBaseUrl;
        public UsuarioService(IConfiguration configuration)
        {

            this.configuration = configuration;
            usuarioBaseUrl = this.configuration.GetSection("AppSettings").GetValue<string>("CabanaURL")!;
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Login(UsuarioViewModel model)
        //{
        //    if (!ModelState.IsValid) { ViewBag.Error = "Los datos de Usuario no son válidos."; return View(model); }
        //    try
        //    {
        //        var token = await usuarioService.Login(model);
        //        HttpContext.Session.SetString("AccessToken", token);
        //        return RedirectToAction("Index", "Autor");
        //    }
        //    catch (Exception ex)
        //    {
        //        ViewBag.Error = ex.Message;
        //        return View(model);
        //    }
        //}

        public async Task<string> Login(UsuarioViewModel usuario)
        {
            using (var cliente = new HttpClient())
            {
                string cuerpoSolicitud = Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
                HttpContent contenido = new StringContent(cuerpoSolicitud, Encoding.UTF8, "application/json");

                // Realiza la petición a la API para autenticar al usuario
                var respuesta = await cliente.PostAsync($"{usuarioBaseUrl}/api/Seguridad/login", contenido);

                // Verifica si la respuesta es exitosa
                if (!respuesta.IsSuccessStatusCode)
                {
                    throw new Exception("No se pudo hacer el login.");
                }

                // Obtiene el token de la respuesta
                var token = await respuesta.Content.ReadAsStringAsync();

                return token;
            }
        }



        public async Task Registrar(UsuarioViewModel usuario)
        {
            using (var cliente = new HttpClient()) { 
            
                string cuerpoSolicitud = Newtonsoft.Json.JsonConvert.SerializeObject(usuario);
                HttpContent contenido = new StringContent(cuerpoSolicitud, new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));

                var respuesta = await cliente.PostAsync($"{usuarioBaseUrl}/api/Seguridad/Registrar", contenido);
                if (!respuesta.IsSuccessStatusCode) throw new Exception("No se pudo dar de alta el usuario");
            }
        }
    }
}
