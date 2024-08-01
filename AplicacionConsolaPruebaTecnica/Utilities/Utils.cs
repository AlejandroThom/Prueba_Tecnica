using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AplicacionConsolaPruebaTecnica.Utilities
{
    public class Utils
    {
        public static async Task<HttpResponseMessage> RealizarPeticion(string uri)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(uri);
            HttpResponseMessage response = await cliente.GetAsync(cliente.BaseAddress);
            return response;
        }


        public static async Task<HttpResponseMessage> RealizarPeticionPost(string uri, object objeto)
        {
            HttpClient cliente = new HttpClient();
            cliente.BaseAddress = new Uri(uri);
            string objetus = JsonSerializer.Serialize(objeto);
            var content = new StringContent(objetus, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await cliente.PostAsync(cliente.BaseAddress,content);
            string valeu = await response.Content.ReadAsStringAsync();
            return response;
        }
    }
}
