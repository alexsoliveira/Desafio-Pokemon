using Desafio.Pokemon.Business.Exceptions;
using Desafio.Pokemon.Business.Domain;
using FluentAssertions;
using DomainEntity = Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.UnitTests.Domain.MestrePokemon
{
    [Collection(nameof(MestrePokemonTestFixture))]
    public class MestrePokemonTest
    {
        private readonly MestrePokemonTestFixture _fixture;

        public MestrePokemonTest(MestrePokemonTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(InstanciaMestrePokemon))]
        [Trait("Domain", "MestrePokemon - Aggregates")]
        public void InstanciaMestrePokemon()
        {
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();

            var mestrePokemon = new DomainEntity.MestrePokemon(
                mestrePokemonValido.Nome,
                mestrePokemonValido.Idade,
                mestrePokemonValido.Cpf
            );

            mestrePokemon.Should().NotBeNull();
            mestrePokemon.Nome.Should().Be(mestrePokemonValido.Nome);
            mestrePokemon.Idade.Should().Be(mestrePokemonValido.Idade);
            mestrePokemon.Cpf.Should().Be(mestrePokemonValido.Cpf);
        }

        [Theory(DisplayName = nameof(InstanciaMestrePokemonQuandoNomeVazio))]
        [Trait("Domain", "MestrePokemon - Aggregates")]
        [InlineData("")]
        [InlineData("  ")]
        [InlineData(null)]
        public void InstanciaMestrePokemonQuandoNomeVazio(string? nomeMestrePokemon)
        {
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();

            Action action = () => new DomainEntity.MestrePokemon(
                nomeMestrePokemon!,
                mestrePokemonValido.Idade,
                mestrePokemonValido.Cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("");
            
        }

        [Theory(DisplayName = nameof(InstanciaMestrePokemonQuandoIdadeMenorQueDezOuMaiorQueCem))]
        [Trait("Domain", "MestrePokemon - Aggregates")]
        [InlineData(9)]
        [InlineData(101)]
        [InlineData(0)]
        public void InstanciaMestrePokemonQuandoIdadeMenorQueDezOuMaiorQueCem(byte idadeMestrePokemon)
        {
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();

            Action action = () => new DomainEntity.MestrePokemon(
                mestrePokemonValido.Nome,
                idadeMestrePokemon,
                mestrePokemonValido.Cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("");

        }

        //[Theory(DisplayName = nameof(InstanciaMestrePokemonQuandoIdadeMenorQueDezOuMaiorQueCem))]
        //[Trait("Domain", "MestrePokemon - Aggregates")]
        //[InlineData("99999999999")]
        //[InlineData(" ")]
        //[InlineData("00000000000")]
        //[InlineData(null)]
        //public void InstanciaMestrePokemonQuandoCpfEhInvalido(string cpfMestrePokemon)
        //{
        //    var mestrePokemonValido = _fixture.ObterMestrePokemonValido();
        //    var cpfInvalido = new CPF();

        //    Action action = () => new DomainEntity.MestrePokemon(
        //        mestrePokemonValido.Nome,
        //        mestrePokemonValido.Idade,
        //        cpfMestrePokemon
        //    );

        //    action.Should()
        //        .Throw<EntityValidationException>()
        //        .WithMessage("");

        //}

        // Validar instancia mestre pokemon com cpf invalido
        // Validar instancia mestre pokemon com nome valido
        // Validar instancia mestre pokemon com idade valido
        // Validar instancia mestre pokemon com cpf valido
    }
}
