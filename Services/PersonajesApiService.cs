using AppComida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace AppComida.Services
{
    public class PersonajesApiService : IPersonajesMService
    {
        private string urlApi = "https://rickandmortyapi.com/api/character";
        
        public async Task<List<Personajes>> Obtener()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);
            JsonNode results = nodos["results"];
            var personajeData = JsonSerializer.Deserialize<List<Personajes>>(results.ToString());
            return personajeData;
        }
    }
}
