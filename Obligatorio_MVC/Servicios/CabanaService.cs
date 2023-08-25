using Obligatorio_MVC.Models;
using System.Net.Http.Headers;
using System.Net.Http;

namespace Obligatorio_MVC.Servicios
{
    public class CabanaService : ICabanaService
    {
        private readonly IConfiguration configuracion;

        private readonly string cabanaBaseUrl;

        public CabanaService(IConfiguration configuracion)
        {
            this.configuracion = configuracion;
            cabanaBaseUrl = configuracion.GetSection("AppSettings").GetValue<string>("CabanaURL")!;
        }
        public async Task<IEnumerable<CabanaModel>> ObtenerTodas()
        {
            using (var cabana = new HttpClient())
            {
                var respuesta = await cabana.GetAsync($"cabanaBaseUrl/api/CabanasController");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();


            }
        }
        public async Task<IEnumerable<CabanaModel>> BuscarPorNombre(string nombre, string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarCabanaPorNombre/{nombre}");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }

        public async Task<IEnumerable<CabanaModel>> BuscarCabanaPorTipo(string tipo, string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarCabanaPorTipo/{tipo}");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }

        public async Task<IEnumerable<CabanaModel>> BuscarCabanaPorCantidadMaximaDePersonas(int maxpersonas, string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarCabanaPorCantidadMaximaDePersonas/{maxpersonas}");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }

        public async Task<IEnumerable<CabanaModel>> BuscarCabanasHabilitadas(string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarCabanasHabilitadas");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }
        public async Task<IEnumerable<CabanaModel>> BuscarTodas(string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarTodas");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }
        public async Task<IEnumerable<CabanaModel>> BuscarCabanas(string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarCabanas");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }
        public async Task<IEnumerable<CabanaModel>> BuscarPorTipoyMonto(ParaBuscarPorTipoyMontoModel model, string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BuscarPorTipoyMonto/{model.Tipo}/{model.Monto}");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }

        public async Task<IEnumerable<CabanaModel>> BusquedaCapacidad(int min, int max, string token)
        {
            using (var cabana = new HttpClient())
            {
                cabana.BaseAddress = new Uri(cabanaBaseUrl);
                cabana.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var respuesta = await cabana.GetAsync($"api/Cabanas/BusquedaCapacidad/{min}/{max}");
                if (respuesta.IsSuccessStatusCode)
                {
                    string contenidoRespuesta = await respuesta.Content.ReadAsStringAsync();
                    return Newtonsoft.Json.JsonConvert.DeserializeObject<IEnumerable<CabanaModel>>(contenidoRespuesta);

                }
                return Enumerable.Empty<CabanaModel>();
            }
        }

        
    }
}
