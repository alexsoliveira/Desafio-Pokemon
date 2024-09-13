namespace Desafio.Pokemon.Api.ViewModels
{
    public class InputViewModel
    {
        public string Nome { get; set; }
        public byte Idade { get; set; }
        public CpfViewModel Cpf { get; set; }

        public InputViewModel(string nome, byte idade, CpfViewModel cpf)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
        }
    }
}
