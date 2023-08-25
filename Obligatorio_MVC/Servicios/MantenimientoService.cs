using Obligatorio_MVC.Models;
using System.Net.Http.Headers;

namespace Obligatorio_MVC.Servicios
{
    public class MantenimientoService : IMantenimientoService
    {
        private readonly IConfiguration configuracion;
        private readonly string mantenimientoURL;

        public MantenimientoService(IConfiguration configuracion)
        {
            this.configuracion = configuracion;
            mantenimientoURL = configuracion.GetSection("AppSettings").GetValue<string>("CabanaURL")!;
        }
        public async Task<IEnumerable<MantenimientoModel>> ObtenerTodos()
        {
            //    using (var mantenimiento = new HttpClient())
            //    {
            //        var respuesta = await mantenimiento.GetAsync($"MantenimientoURL/api/MantenimientosController");
            //        if (respuesta.IsSuccessStatusCode)
            //        {
            //            string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
            //            return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<MantenimientoModel>>(contenidoRespuesta);

            //        }
            return Enumerable.Empty<MantenimientoModel>();


            //    }
        }

        public async Task<IEnumerable<MantenimientoModel>> BuscarMantenimientoEntreFechas(int id, DateTime fechaInicio, DateTime fechaFin, string token)
        {


            using (var mantenimiento = new HttpClient())
            {
                mantenimiento.BaseAddress = new Uri(mantenimientoURL);
                mantenimiento.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
               var respuesta = await mantenimiento.GetAsync($"api/Mantenimientos/BuscarMantenimientoEntreFechas/{id}/{fechaInicio.ToString("yyyy-MM-dd")}/{fechaFin.ToString("yyyy-MM-dd")}");


                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<MantenimientoModel>>(contenidoRespuesta);
                }
                return Enumerable.Empty<MantenimientoModel>();
            }
        }
        public async Task<IEnumerable<MantenimientoModel>> RegistroMantenimiento(int id, DateTime fecha, int costo, string descripcion, string trabajador, string token)
        {
            using (var mantenimiento = new HttpClient())
            {
                mantenimiento.BaseAddress = new Uri(mantenimientoURL);
                mantenimiento.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await mantenimiento.PostAsync($"api/Mantenimientos/RegistroMantenimiento/{id}/{fecha.ToString("yyyy-MM-dd")}/{costo}/{descripcion}/{trabajador}", null);

                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<MantenimientoModel>>(contenidoRespuesta);
                }
                return Enumerable.Empty<MantenimientoModel>();
            }
        }

    }
}
