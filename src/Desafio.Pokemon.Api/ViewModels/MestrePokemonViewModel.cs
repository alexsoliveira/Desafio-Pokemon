using Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.Api.ViewModels
{
    public class MestrePokemonViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public byte Idade { get; set; }
        public Cpf Cpf { get; set; }

        public MestrePokemonViewModel(string nome, byte idade, Cpf cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
    }
}
