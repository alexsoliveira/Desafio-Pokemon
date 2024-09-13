using Desafio.Pokemon.Api.ViewModels;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Desafio.Pokemon.EndToEndTests.Api.CriarMestrePokemon
{
    [Collection(nameof(CriarMestrePokemonApiTestFixture))]
    public class CriarMestrePokemonApiTest : IDisposable
    {
        private readonly CriarMestrePokemonApiTestFixture _fixture;

        public CriarMestrePokemonApiTest(CriarMestrePokemonApiTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(CriarMestrePokemon))]
        [Trait("EndToEnd/API", "MestrePokemon/Criar - Endpoints")]
        public async Task CriarMestrePokemon()
        {
            var input = _fixture.ObterExemploMestrePokemon();

            var (response, output) = await _fixture
                .ApiClient.Post<ResultadoViewModel>(
                    "/api/v1/mestre-pokemon",
                    input
                );

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be(HttpStatusCode.Created);
            output.Should().NotBeNull();
            output!.Resultado.Nome.Should().Be(input.Nome);
            output.Resultado.Idade.Should().Be(input.Idade);
            output.Resultado.Cpf.Numero.Should().Be(input.Cpf.Numero);
            output.Resultado.Id.Should().NotBeEmpty();

            var dbMestrePokemon = await _fixture
                .Persistence.GetById(output.Resultado.Id);
            dbMestrePokemon.Should().NotBeNull();
            dbMestrePokemon!.Nome.Should().Be(input.Nome);
            dbMestrePokemon.Idade.Should().Be(input.Idade);
            dbMestrePokemon.Cpf.Numero.Should().Be(input.Cpf.Numero);
            dbMestrePokemon.Id.Should().NotBeEmpty();            
        }

        [Theory(DisplayName = nameof(ErrorQuandoInstanciaAggregate))]
        [Trait("EndToEnd/API", "MestrePokemon/Criar - Endpoints")]
        [MemberData(
            nameof(CriarMestrePokemonApiTestDataGenerator.ObterEntradasInvalidas),
            MemberType = typeof(CriarMestrePokemonApiTestDataGenerator)
        )]
        public async Task ErrorQuandoInstanciaAggregate(
            MestrePokemonViewModel input,
            string expectedDetail
        )
        {
            var (response, output) = await _fixture
                .ApiClient.Post<ProblemDetails>(
                    "/api/v1/mestre-pokemon",
                    input
                );

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
            output.Should().NotBeNull();
            output!.Title.Should().Be("One or more validation errors ocurred");
            output.Type.Should().Be("UnprocessableEntity");
            output.Status.Should().Be(StatusCodes.Status422UnprocessableEntity);
            output.Detail.Should().Be(expectedDetail);
        }

        public void Dispose()
            => _fixture.LimparPersistence();
    }
}