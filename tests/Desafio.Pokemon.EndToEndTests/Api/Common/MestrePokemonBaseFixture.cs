using Bogus.Extensions.Brazil;
using Desafio.Pokemon.Api.ViewModels;
using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.EndToEndTests.Base;

namespace Desafio.Pokemon.EndToEndTests.Api.Common
{
    public class MestrePokemonBaseFixture
        : BaseFixture
    {
        public MestrePokemonPersistence Persistence;

        public MestrePokemonBaseFixture()
            : base()
        {
            Persistence = new MestrePokemonPersistence(
                CriarDbContext()
            );
        }

        public string ObterNomeMestrePokemonValido()
        {
            var nomeMestrePokemon = "";

            while (nomeMestrePokemon.Length < 3)
                nomeMestrePokemon = Faker.Commerce.Categories(1)[0];

            if (nomeMestrePokemon.Length > 30)
                nomeMestrePokemon = nomeMestrePokemon[..30];

            return nomeMestrePokemon;
        }

        public byte ObterIdadeMestrePokemonValido()
        {
            byte idade = 0;

            //regra para idade valida de 10 até 100 anos.
            idade = (byte)new Random().Next(10, 100);

            return idade;
        }

        public CpfViewModel ObterCPFMestrePokemonValido()
        {

            var cpf = new CpfViewModel(
                Faker.Person.Cpf().Replace("-", "").Replace(".", "")
            );

            return cpf;
        }

        public string ObterNomeCurtoMestrePokemonInvalido()
        {
            var nomeMestrePokemon = "";

            while (nomeMestrePokemon.Length < 2)
                nomeMestrePokemon = Faker.Commerce.ProductName().Substring(0, 2);
            
            return nomeMestrePokemon;
        }

        public string ObterNomeLongoMestrePokemonInvalido()
        {            
            var nomeMestrePokemon = Faker.Commerce.ProductName();

            while (nomeMestrePokemon.Length <= 30)
                nomeMestrePokemon = $"{nomeMestrePokemon} {Faker.Commerce.ProductName()}";
            
            return nomeMestrePokemon;
        }

        public byte ObterIdadeMenorMestrePokemonInvalido()
        {
            byte idade = 0;
            
            idade = (byte)new Random().Next(0, 9);

            return idade;
        }

        public byte ObterIdadeMaiorMestrePokemonInvalido()
        {
            byte idade = 0;
            
            idade = (byte)new Random().Next(101, 190);

            return idade;
        }
    }
}
