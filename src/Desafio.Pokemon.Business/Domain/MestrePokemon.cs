using Desafio.Pokemon.Business.Validations;
using System.Xml.Linq;

namespace Desafio.Pokemon.Business.Domain
{
    public class MestrePokemon
    {        
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public CPF Cpf { get; private set ; }

        public MestrePokemon(string nome, byte idade, CPF cpf)
        {            
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }

        private void Validate()
        {
            DomainValidation.NotNullOrEmpty(Nome, nameof(Nome));
            DomainValidation.MinLength(Nome, 3, nameof(Nome));
            DomainValidation.MaxLength(Nome, 30, nameof(Nome));

            DomainValidation.MinLength(Idade, 10, nameof(Idade));
            DomainValidation.MaxLength(Idade, 100, nameof(Idade));
        }
    }
}
