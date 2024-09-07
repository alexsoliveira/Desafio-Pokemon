using Bogus.Extensions.Brazil;
using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.UnitTests.Common;
using DomainEntity = Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.UnitTests.Domain.MestrePokemon
{
    [CollectionDefinition(nameof(MestrePokemonTestFixture))]
    public class MestrePokemonTestFixtureCollection
        : ICollectionFixture<MestrePokemonTestFixture>
    { }

    public class MestrePokemonTestFixture : BaseFixture
    {
        public MestrePokemonTestFixture()
            : base() { }

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
            idade = (byte) new Random().Next(10, 100);

            return idade;
        }

        public CPF ObterCPFMestrePokemonValido()
        {
            //regra obter cpf valido
            var cpf = new CPF();

            //cpf.Numero = GerarCpf();
            cpf.Numero = Faker.Person.Cpf();

            return cpf;
        }

        public DomainEntity.MestrePokemon ObterMestrePokemonValido()
            => new(
                ObterNomeMestrePokemonValido(), 
                ObterIdadeMestrePokemonValido(),
                ObterCPFMestrePokemonValido()
            );


        //private static String GerarCpf()
        //{
        //    int soma = 0, resto = 0;
        //    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        //    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        //    Random rnd = new Random();
        //    string semente = rnd.Next(100000000, 999999999).ToString();

        //    for (int i = 0; i < 9; i++)
        //        soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

        //    resto = soma % 11;
        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;

        //    semente = semente + resto;
        //    soma = 0;

        //    for (int i = 0; i < 10; i++)
        //        soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

        //    resto = soma % 11;

        //    if (resto < 2)
        //        resto = 0;
        //    else
        //        resto = 11 - resto;

        //    semente = semente + resto;
        //    return semente;
        //}
    }
}
