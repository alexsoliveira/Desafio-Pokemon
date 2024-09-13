using Desafio.Pokemon.Business.Domain;
using Microsoft.AspNetCore.Components.Forms;

namespace Desafio.Pokemon.Api.ViewModels
{
    public class MestrePokemonViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public byte Idade { get; set; }
        public CpfViewModel Cpf { get; set; }

        public MestrePokemonViewModel(string nome, byte idade, CpfViewModel cpf)
        {                        
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }                   
    }
}
