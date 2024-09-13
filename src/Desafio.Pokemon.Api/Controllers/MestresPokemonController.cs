using AutoMapper;
using Desafio.Pokemon.Api.ViewModels;
using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio.Pokemon.Api.Controllers
{
    [Route("api/v1/mestre-pokemon")]
    public class MestresPokemonController : MainController
    {
        private readonly IMestrePokemonService _mestrePokemonService;
        private readonly IMapper _mapper;

        public MestresPokemonController(
            IMestrePokemonService mestrePokemonService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _mestrePokemonService = mestrePokemonService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MestrePokemonViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status422UnprocessableEntity)]
        public async Task<IActionResult> Criar(
            [FromBody] InputViewModel input
        )
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);
           
            MestrePokemonViewModel mestrePokemonViewModel = new MestrePokemonViewModel(
                input.Nome,
                input.Idade,
                input.Cpf
            );                

            var resultado = await _mestrePokemonService
                .CriarMestrePokemon(_mapper.Map<MestrePokemon>(mestrePokemonViewModel));

            return CustomResponse(HttpStatusCode.Created, new { resultado });
        }
    }
}
