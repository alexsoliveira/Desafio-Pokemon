using Desafio.Pokemon.Business.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Desafio.Pokemon.Business.Domain.Pokemon;

namespace Desafio.Pokemon.Business.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
            => _httpClient = httpClient;

        public async Task<(HttpResponseMessage?, List<PokemonDetalhes>?)> ObterPokemons()
        {
            var url = PrepareGetRoute("https://pokeapi.co/api/v2/pokemon-form/", null);
            var response = await _httpClient.GetAsync(url);
            var output = await GetOutput<List<PokemonDetalhes>>(response);
            return (response, output);

            //    var request = new HttpRequestMessage(HttpMethod.Get, $"");
            //    var response = await _httpClient.GetAsync(request);

            //    var response = await _httpClient.PostAsync(
            //        route,
            //        new StringContent(
            //            JsonSerializer.Serialize(payload),
            //            Encoding.UTF8,
            //            "application/json"
            //        )
            //    );
            //    var output = await GetOutput<TOutput>(response);
            //    return (response, output);

            //    public async Task<(HttpResponseMessage?, TOutput?)> Get<TOutput>(
            //    string route,
            //    object? queryStringParametersObject = null
            //)
            //    where TOutput : class
            //    {
            //        var url = PrepareGetRoute("");
            //        var response = await _httpClient.GetAsync(url);
            //        var output = await GetOutput<TOutput>(response);
            //        return (response, output);
            //    }
        }

        public async Task<(HttpResponseMessage?, PokemonDetalhes?)> ObterPorId(int id)
        {
            var url = PrepareGetRoute("",id);
            var response = await _httpClient.GetAsync(url);
            var output = await GetOutput<PokemonDetalhes>(response);
            return (response, output);            
        }

        private async Task<TOutput?> GetOutput<TOutput>(HttpResponseMessage response)
            where TOutput : class
        {
            var outputString = await response.Content.ReadAsStringAsync();
            TOutput? output = null;
            if (!string.IsNullOrWhiteSpace(outputString))
                output = JsonSerializer.Deserialize<TOutput>(outputString,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            return output;
        }

        private string PrepareGetRoute(
            string route,
            object? queryStringParametersObject
        )
        {
            if (queryStringParametersObject is null)
                return route;

            var parametersJson = JsonSerializer.Serialize(queryStringParametersObject);
            var parametersDictionary = Newtonsoft.Json.JsonConvert
                .DeserializeObject<Dictionary<string, string>>(parametersJson);
            return QueryHelpers.AddQueryString(route, parametersDictionary!);
        }
    }
}
