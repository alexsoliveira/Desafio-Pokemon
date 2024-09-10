namespace Desafio.Pokemon.Api.ViewModels
{
    public class CpfViewModel
    {
        public string Numero { get; set; }

        public CpfViewModel(string numero)
        {
            Numero = numero;
        }
    }
}
