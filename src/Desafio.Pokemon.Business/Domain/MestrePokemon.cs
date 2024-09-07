using Desafio.Pokemon.Business.SeedWork;
using Desafio.Pokemon.Business.Validations;

namespace Desafio.Pokemon.Business.Domain
{
    public class MestrePokemon : AggregateRoot
    {                
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public Cpf Cpf { get; private set ; }

        public MestrePokemon(string nome, byte idade, Cpf cpf)
        {            
            Nome = nome;
            Idade = idade;
            Cpf = cpf;

            Validar();
        }

        private void Validar()
        {
            DomainValidation.NotNullOrEmpty(Nome, nameof(Nome));
            DomainValidation.MinLength(Nome, 3, nameof(Nome));
            DomainValidation.MaxLength(Nome, 30, nameof(Nome));

            DomainValidation.MinLength(Idade, 10, nameof(Idade));
            DomainValidation.MaxLength(Idade, 100, nameof(Idade));            
        }
    }
}
