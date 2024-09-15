using Desafio.Pokemon.Business.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;
using Desafio.Pokemon.Business.Domain.Pokemon;
using Desafio.Pokemon.Business.Domain.Pokemon.Evolucao;
using Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao;
using Desafio.Pokemon.Business.Validations;
using Desafio.Pokemon.Business.Exceptions;

namespace Desafio.Pokemon.Business.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;             

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
        }
            

        public async Task<IEnumerable<PokemonDetalhes>?> ObterPokemons()
        {
            List<PokemonDetalhes> listaPokemons = new List<PokemonDetalhes>();            

            while (listaPokemons.Count < 10)
            {
                var input = new Random().Next(1, 151);

                var output = await ObterPokemonPorId(input);

                if (output != null)
                {
                    listaPokemons.Add(output);
                }
                else
                    throw new EntityValidationException(
                        "Erro ao obter detalhes do pokemon");
            }            

            return listaPokemons;
        }

        public async Task<PokemonDetalhes?> ObterPokemonPorId(int id)
        {
            var (responseDetalhes, outputDetalhes) = await ObterDetalhesPokemonPorId(id);

            if (responseDetalhes!.IsSuccessStatusCode)
            {
                var (responseEvolucao, outputEvolucao) = await ObterEvolucaoPokemonPorId(id);

                if (responseEvolucao!.IsSuccessStatusCode)
                {
                    if (!String.IsNullOrEmpty(outputEvolucao!.Evolution_Chain!.Url))
                    {
                        var primeiraFase = outputEvolucao.Evolution_Chain.Url
                            .Replace("https://pokeapi.co/api/v2/evolution-chain/", "").Replace("/","");

                        var (responseCadeia, outputCadeia) = 
                            await ObterCadeiaEvolucaoPokemonPorId(Convert.ToInt32(primeiraFase));

                        if (responseCadeia!.IsSuccessStatusCode)
                        {
                            outputDetalhes!.Evolucao = outputCadeia;
                        }
                        else
                            throw new EntityValidationException(
                                "Não foi possível obter cadeia de evolução");
                    }
                }
                else
                    throw new EntityValidationException(
                        "Não foi possível obter evolução do pokemon");
            }
            else
                throw new EntityValidationException(
                    "Não foi possível obter detalhes do pokemon");

            return outputDetalhes;            
        }

        public async Task<(HttpResponseMessage?, PokemonDetalhes?)> ObterDetalhesPokemonPorId(int id)
        {
            ValidarPokemonPrimeiraGeracao(id);

            var url = PrepareGetRoute($"pokemon-form/{id}", null);
            var response = await _httpClient.GetAsync(url);
            var output = await GetOutput<PokemonDetalhes>(response);
            
            return (response, output);
        }

        public async Task<(HttpResponseMessage?, PokemonEvolucao?)> ObterEvolucaoPokemonPorId(int id)
        {
            ValidarPokemonPrimeiraGeracao(id);

            var url = PrepareGetRoute($"pokemon-species/{id}", null);
            var response = await _httpClient.GetAsync(url);
            var output = await GetOutput<PokemonEvolucao>(response);

            return (response, output);
        }
        
        public async Task<(HttpResponseMessage?, CadeiaEvolucao?)> ObterCadeiaEvolucaoPokemonPorId(int id)
        {
            ValidarPokemonPrimeiraGeracao(id);

            var url = PrepareGetRoute($"evolution-chain/{id}", null);
            var response = await _httpClient.GetAsync(url);
            var output = await GetOutput<CadeiaEvolucao>(response);

            return (response, output);
        }

        private static void ValidarPokemonPrimeiraGeracao(int input)
        {
            PokemonValidation.MinLength(input, 1, "Id");
            PokemonValidation.MaxLength(input, 151, "Id");
        }

        private static async Task<TOutput?> GetOutput<TOutput>(HttpResponseMessage response)
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

        private static string PrepareGetRoute(
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
