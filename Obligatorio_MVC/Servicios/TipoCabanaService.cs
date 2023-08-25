using Obligatorio_MVC.Models;
using System.Net.Http.Headers;

namespace Obligatorio_MVC.Servicios
{
    public class TipoCabanaService : ITipoCabanaService
    {
        private readonly IConfiguration configuracion;
        private readonly string cabanaBaseUrl;

        public TipoCabanaService(IConfiguration configuracion)
        {
            this.configuracion = configuracion;
            cabanaBaseUrl = configuracion.GetSection("AppSettings").GetValue<string>("CabanaURL")!;
        }

        public async Task<IEnumerable<TipoCabanaModel>> Alta(string nombre, string descripcion, int CostoPorHuesped, string token)
        {
            using (var tipoCabana = new HttpClient())
            {
                tipoCabana.BaseAddress = new Uri(cabanaBaseUrl);
                tipoCabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await tipoCabana.PostAsync($"api/TiposCabanas/Alta/{nombre}/{descripcion}/{CostoPorHuesped}",null);
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TipoCabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<TipoCabanaModel>();
            }
        }

        public async Task<IEnumerable<TipoCabanaModel>> BuscarTipoCabanaPorNombre()
        {
            using (var mantenimiento = new HttpClient())
            {
                var respuesta = await mantenimiento.GetAsync($"CabanaURL/api/TiposCabanasController");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TipoCabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<TipoCabanaModel>();
                

            }
        }

        public async Task<IEnumerable<TipoCabanaModel>> ListarTipoCabana(string token)
        {
            using (var tipoCabana = new HttpClient())
            {
                tipoCabana.BaseAddress = new Uri(cabanaBaseUrl);
                tipoCabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await tipoCabana.GetAsync($"api/TiposCabanas/ListarTipoCabana");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TipoCabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<TipoCabanaModel>();
            }
        }
        public async Task<IEnumerable<TipoCabanaModel>> BuscarTipoPorNombre(string nombre, string token)
        {
            using (var tipoCabana = new HttpClient())
            {
                tipoCabana.BaseAddress = new Uri(cabanaBaseUrl);
                tipoCabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await tipoCabana.GetAsync($"api/TiposCabanas/BuscarTipoPorNombre/{nombre}");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<TipoCabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<TipoCabanaModel>();
            }
        }
        
    }
}
