using Desafio.Pokemon.Business.Exceptions;
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

        #region teste instancia classe Mestre Pokemon

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

        #endregion        

        #region teste instancia classe Mestre Pokemon Nome com Erro

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
                .WithMessage("Nome não pode ser vazio ou null");
            
        }

        [Theory(DisplayName = nameof(InstanciaMestrePokemonQuandoNomeMenorQue3))]
        [Trait("Domain", "MestrePokemon - Aggregates")]
        [MemberData(nameof(ObterNomeMenorQue3Caracteres), parameters: 10)]
        public void InstanciaMestrePokemonQuandoNomeMenorQue3(string? nomeMestrePokemon)
        {
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();

            Action action = () => new DomainEntity.MestrePokemon(
                nomeMestrePokemon!,
                mestrePokemonValido.Idade,
                mestrePokemonValido.Cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("Nome deve ser maior ou igual a 3 caracteres");

        }

        public static IEnumerable<object[]> ObterNomeMenorQue3Caracteres(int numberOfTests = 6)
        {
            var fixture = new MestrePokemonTestFixture();

            for (int i = 0; i < numberOfTests; i++)
            {
                var isOdd = i % 2 == 1;
                yield return new object[] {
                    fixture.ObterNomeMestrePokemonValido()[ ..(isOdd ? 1 : 2)]
                };
            }
        }

        [Fact(DisplayName = nameof(InstanciaMestrePokemonQuandoNomeMaiorQue30))]
        [Trait("Domain", "MestrePokemon - Aggregates")]        
        public void InstanciaMestrePokemonQuandoNomeMaiorQue30()
        {            
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();
            var nomeMestrePokemon = string.Join(null, Enumerable.Range(1, 31).Select(_ => "a").ToArray());

            Action action = () => new DomainEntity.MestrePokemon(
                nomeMestrePokemon!,
                mestrePokemonValido.Idade,
                mestrePokemonValido.Cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("Nome deve ser menor ou igual a 30 caracteres");

        }

        #endregion

        #region teste instancia classe Mestre Pokemon Idade com Erro

        [Theory(DisplayName = nameof(InstanciaMestrePokemonQuandoIdadeMenorQueDez))]
        [Trait("Domain", "MestrePokemon - Aggregates")]
        [InlineData(9)]
        [InlineData(1)]
        [InlineData(0)]
        public void InstanciaMestrePokemonQuandoIdadeMenorQueDez(byte idadeMestrePokemon)
        {
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();

            Action action = () => new DomainEntity.MestrePokemon(
                mestrePokemonValido.Nome,
                idadeMestrePokemon,
                mestrePokemonValido.Cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("Idade deve ser maior ou igual a 10");

        }

        [Theory(DisplayName = nameof(InstanciaMestrePokemonQuandoIdadeMaiorQueCem))]
        [Trait("Domain", "MestrePokemon - Aggregates")]
        [InlineData(109)]
        [InlineData(101)]
        [InlineData(200)]
        public void InstanciaMestrePokemonQuandoIdadeMaiorQueCem(byte idadeMestrePokemon)
        {
            var mestrePokemonValido = _fixture.ObterMestrePokemonValido();

            Action action = () => new DomainEntity.MestrePokemon(
                mestrePokemonValido.Nome,
                idadeMestrePokemon,
                mestrePokemonValido.Cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("Idade deve ser menor ou igual a 100");

        }

        #endregion        
    }
}
