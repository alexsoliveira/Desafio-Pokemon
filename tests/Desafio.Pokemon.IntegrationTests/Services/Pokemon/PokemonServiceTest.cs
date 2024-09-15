using Desafio.Pokemon.Business.Exceptions;
using Desafio.Pokemon.IntegrationTestsApi.Pokemon;
using FluentAssertions;
using System.Net;
using DomainService = Desafio.Pokemon.Business.Services;

namespace Desafio.Pokemon.IntegrationTests.Services.Pokemon
{
    [Collection(nameof(PokemonServiceTestFixture))]
    public class PokemonServiceTest
    {
        private readonly PokemonServiceTestFixture _fixture;

        public PokemonServiceTest(PokemonServiceTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(ObterPokemonPorId))]
        [Trait("Integration/Services", "ObterPokemonPorId - Services")]
        public async Task ObterPokemonPorId()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonValido();            
            var service = new DomainService.PokemonService(
                new HttpClient()
            );
            var output = await service.ObterPokemonPorId(input);
            //var (response, output) = await service.ObterPokemonPorId(input);

            //response.Should().NotBeNull();
            //response!.StatusCode.Should().Be(HttpStatusCode.OK);
            output.Should().NotBeNull();
            output!.Id.Should().Be(input);
        }

        [Fact(DisplayName = nameof(ObterDetalhesPokemonPorId))]
        [Trait("Integration/Services", "ObterDetalhesPokemonPorId - Services")]
        public async Task ObterDetalhesPokemonPorId()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonValido();
            var service = new DomainService.PokemonService(
                new HttpClient()
            );
            var (response, output) = await service.ObterDetalhesPokemonPorId(input);

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be(HttpStatusCode.OK);
            output.Should().NotBeNull();
            output!.Id.Should().Be(input);            
        }

        [Fact(DisplayName = nameof(ObterEvolucaoPokemonPorId))]
        [Trait("Integration/Services", "ObterEvolucaoPokemonPorId - Services")]
        public async Task ObterEvolucaoPokemonPorId()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonValido();
            var service = new DomainService.PokemonService(
                new HttpClient()
            );
            var (response, output) = await service.ObterEvolucaoPokemonPorId(input);

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be(HttpStatusCode.OK);
            output.Should().NotBeNull();
            output!.Id.Should().Be(input);
        }

        [Fact(DisplayName = nameof(ObterCadeiaEvolucaoPokemonPorId))]
        [Trait("Integration/Services", "ObterCadeiaEvolucaoPokemonPorId - Services")]
        public async Task ObterCadeiaEvolucaoPokemonPorId()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonValido();
            var service = new DomainService.PokemonService(
                new HttpClient()
            );
            var (response, output) = await service.ObterCadeiaEvolucaoPokemonPorId(input);

            response.Should().NotBeNull();
            response!.StatusCode.Should().Be(HttpStatusCode.OK);
            output.Should().NotBeNull();
            output!.Id.Should().Be(input);
        }

        [Fact(DisplayName = nameof(ObterDetalhesPokemonPorIdMaiorQue151Error))]
        [Trait("Integration/Services", "ObterDetalhesPokemonPorId - Services")]
        public async Task ObterDetalhesPokemonPorIdMaiorQue151Error()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonInvalido();
            var service = new DomainService.PokemonService(
                new HttpClient()
            );

            Func<Task> task = async () => await service.ObterDetalhesPokemonPorId(input);

            await task.Should()
                .ThrowAsync<EntityValidationException>()
                .WithMessage("Id deve ser menor ou igual a 151 pokemon");            
        }

        [Fact(DisplayName = nameof(ObterEvolucaoPokemonPorIdMaiorQue151Error))]
        [Trait("Integration/Services", "ObterEvolucaoPokemonPorId - Services")]
        public async Task ObterEvolucaoPokemonPorIdMaiorQue151Error()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonInvalido();
            var service = new DomainService.PokemonService(
                new HttpClient()
            );

            Func<Task> task = async () => await service.ObterEvolucaoPokemonPorId(input);

            await task.Should()
                .ThrowAsync<EntityValidationException>()
                .WithMessage("Id deve ser menor ou igual a 151 pokemon");
        }

        [Fact(DisplayName = nameof(ObterCadeiaEvolucaoPokemonPorIdMaiorQue151Error))]
        [Trait("Integration/Services", "ObterCadeiaEvolucaoPokemonPorId - Services")]
        public async Task ObterCadeiaEvolucaoPokemonPorIdMaiorQue151Error()
        {
            var input = _fixture.ObterIdPrimeiraGeracaoPokemonInvalido();
            var service = new DomainService.PokemonService(
                new HttpClient()
            );

            Func<Task> task = async () => await service.ObterCadeiaEvolucaoPokemonPorId(input);

            await task.Should()
                .ThrowAsync<EntityValidationException>()
                .WithMessage("Id deve ser menor ou igual a 151 pokemon");
        }

        [Theory(DisplayName = nameof(ObterDetalhesPokemonPorIdMenorQue1Error))]
        [Trait("Integration/Services", "ObterDetalhesPokemonPorId - Services")]        
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ObterDetalhesPokemonPorIdMenorQue1Error(int input)
        {            
            var service = new DomainService.PokemonService(
                new HttpClient()
            );

            Func<Task> task = async () => await service.ObterDetalhesPokemonPorId(input);

            await task.Should()
                .ThrowAsync<EntityValidationException>()
                .WithMessage("Id deve ser maior ou igual a 1 pokemon");
        }

        [Theory(DisplayName = nameof(ObterEvolucaoPokemonPorIdMenorQue1Error))]
        [Trait("Integration/Services", "ObterEvolucaoPokemonPorId - Services")]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ObterEvolucaoPokemonPorIdMenorQue1Error(int input)
        {
            var service = new DomainService.PokemonService(
                new HttpClient()
            );

            Func<Task> task = async () => await service.ObterEvolucaoPokemonPorId(input);

            await task.Should()
                .ThrowAsync<EntityValidationException>()
                .WithMessage("Id deve ser maior ou igual a 1 pokemon");
        }

        [Theory(DisplayName = nameof(ObterCadeiaEvolucaoPokemonPorIdMenorQue1Error))]
        [Trait("Integration/Services", "ObterCadeiaEvolucaoPokemonPorId - Services")]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task ObterCadeiaEvolucaoPokemonPorIdMenorQue1Error(int input)
        {
            var service = new DomainService.PokemonService(
                new HttpClient()
            );

            Func<Task> task = async () => await service.ObterCadeiaEvolucaoPokemonPorId(input);

            await task.Should()
                .ThrowAsync<EntityValidationException>()
                .WithMessage("Id deve ser maior ou igual a 1 pokemon");
        }
    }
}
