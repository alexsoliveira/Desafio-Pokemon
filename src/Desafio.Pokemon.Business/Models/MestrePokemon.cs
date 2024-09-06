namespace Desafio.Pokemon.Business.Models
{
    public class MestrePokemon
    {        
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public byte Idade { get; private set; }
        public CPF Cpf { get; private set ; }

        public MestrePokemon(Guid id, string nome, byte idade, CPF cpf)
        {
            Id = id;
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
    }
}
