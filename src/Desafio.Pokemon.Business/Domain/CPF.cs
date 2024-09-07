namespace Desafio.Pokemon.Business.Domain
{
    public class CPF
    {
        public string Numero { get; set; }

        public static bool Validar(string cpf)
        {
            var cpfValido = true;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                return false; 
            }

            return cpfValido;
        }
    }
}
