using Desafio.Pokemon.EndToEndTests.Api.MestrePokemon.CriarMestrePokemon;

namespace Desafio.Pokemon.EndToEndTests.Api.MestrePokemon.MestrePokemon.CriarMestrePokemon
{
    public static class CriarMestrePokemonApiTestDataGenerator
    {
        public static IEnumerable<object[]> ObterEntradasInvalidas()
        {
            var fixture = new CriarMestrePokemonApiTestFixture();
            var invalidInputsList = new List<object[]>();
            var totalInvalidCases = 5;

            for (int index = 0; index < totalInvalidCases; index++)
            {
                switch (index % totalInvalidCases)
                {
                    case 0:
                        var input1 = fixture.ObterExemploMestrePokemon();
                        input1.Nome = fixture.ObterNomeCurtoMestrePokemonInvalido();
                        invalidInputsList.Add(new object[] {
                            input1,
                            "Nome deve ser maior ou igual a 3 caracteres"
                        });
                        break;
                    case 1:
                        var input2 = fixture.ObterExemploMestrePokemon();
                        input2.Nome = fixture.ObterNomeLongoMestrePokemonInvalido();
                        invalidInputsList.Add(new object[] {
                            input2,
                            "Nome deve ser menor ou igual a 30 caracteres"
                    });
                        break;
                    case 2:
                        var input3 = fixture.ObterExemploMestrePokemon();
                        input3.Idade = fixture.ObterIdadeMenorMestrePokemonInvalido();
                        invalidInputsList.Add(new object[] {
                            input3,
                            "Idade deve ser maior ou igual a 10"
                        });
                        break;
                    case 3:
                        var input4 = fixture.ObterExemploMestrePokemon();
                        input4.Idade = fixture.ObterIdadeMaiorMestrePokemonInvalido();
                        invalidInputsList.Add(new object[] {
                            input4,
                            "Idade deve ser menor ou igual a 100"
                        });
                        break;
                    case 4:
                        var input5 = fixture.ObterExemploMestrePokemon();
                        input5.Nome = " ";
                        invalidInputsList.Add(new object[] {
                            input5,
                            "Nome não pode ser vazio ou null"
                        });
                        break;
                    default:
                        break;
                }
            }

            return invalidInputsList;
        }
    }
}