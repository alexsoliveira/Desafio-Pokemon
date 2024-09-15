using AutoMapper;
using Desafio.Pokemon.Api.ViewModels.Pokemon;
using Desafio.Pokemon.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio.Pokemon.Api.Controllers
{
    [Route("api/v1/pokemon")]
    public class PokemonsController : MainController
    {
        private readonly IPokemonService _pokemonService;
        private readonly IMapper _mapper;

        public PokemonsController(
            IPokemonService pokemonService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _pokemonService = pokemonService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PokemonDetalhesViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> ObterPokemons()
        {                                                 
            var resultado = _mapper.Map<IEnumerable<PokemonDetalhesViewModel>>(await _pokemonService.ObterPokemons());

            return CustomResponse(HttpStatusCode.OK, new { resultado });
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PokemonDetalhesViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> ObterPokemonPorID(
            [FromRoute] int id)
        {

            var resultado = _mapper.Map<PokemonDetalhesViewModel>(await _pokemonService.ObterPokemonPorId(id));

            return CustomResponse(HttpStatusCode.OK, new { resultado });
        }
    }
}
