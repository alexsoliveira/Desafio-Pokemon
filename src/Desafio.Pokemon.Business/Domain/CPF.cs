using Desafio.Pokemon.Business.Validations;

namespace Desafio.Pokemon.Business.Domain
{
    public class Cpf
    {
        public string Numero { get; private set; }

        public Cpf(string numero)
        {
            Numero = numero;

            ValidarCpf();
        }
        
        private void ValidarCpf()
        {
            CpfValidation.VerificarCPF(Cpf.Validar(Numero), Numero);
        }

        private static bool Validar(string cpf)
        {
            var cpfValido = true;

            if (string.IsNullOrWhiteSpace(cpf))
                DomainValidation.NotNullOrEmpty(cpf, nameof(cpf));

            cpfValido = VerificarSeCpfTem11Digitos(cpf, cpfValido);

            cpfValido = VerificarSeDigitoNumericoSeEhTodosNumerosIguais(cpf, cpfValido);

            cpfValido = VerificarDigitoDeControleCpf(cpf, cpfValido);

            return cpfValido;
        }        

        private static bool VerificarSeCpfTem11Digitos(string cpf, bool cpfValido)
        {
            if (cpf.Length != 11)
            {
                cpfValido = false;
                CpfValidation.VerificarCPF(false, cpf);
            }
            else
            {
                cpfValido = VerificarSeTodosOsCaracteresDeCpfSaoDigitosNumericos(cpf, cpfValido);
            }

            return cpfValido;
        }

        private static bool VerificarSeTodosOsCaracteresDeCpfSaoDigitosNumericos(string cpf, bool cpfValido)
        {
            for (var i = 0; i < cpf.Length; i++)
            {
                if (!Char.IsDigit(cpf[i]))
                {
                    cpfValido = false;
                    CpfValidation.VerificarCPF(false, cpf);
                    break;
                }
            }

            return cpfValido;
        }

        private static bool VerificarSeDigitoNumericoSeEhTodosNumerosIguais(string cpf, bool cpfValido)
        {
            if (cpfValido)
            {
                for (byte i = 0; i < 10; i++)
                {
                    var temp = new string(Convert.ToChar(i), 11);
                    if (cpf == temp)
                    {
                        cpfValido = false;
                        CpfValidation.VerificarCPF(false, cpf);
                        break;
                    }
                }
            }

            return cpfValido;
        }

        private static bool VerificarDigitoDeControleCpf(string cpf, bool cpfValido)
        {
            if (cpfValido)
            {
                var soma = 0;
                var multiplicador1 = 0;
                var multiplicador2 = 0;

                for (int i = 10; i > 1; i--)
                {
                    multiplicador1 += Convert.ToInt32(cpf.Substring(soma, 1)) * i;
                    soma++;
                }

                multiplicador1 = (multiplicador1 * 10) % 11;
                if (multiplicador1 == 10)
                    multiplicador1 = 0;

                if (multiplicador1 != Convert.ToInt32(cpf.Substring(9, 1)))
                {
                    cpfValido = false;
                    CpfValidation.VerificarCPF(false, cpf);
                }                    

                if (cpfValido)
                {
                    soma = 0;

                    for (int i = 11; i > 1; i--)
                    {
                        multiplicador2 += Convert.ToInt32(cpf.Substring(soma, 1)) * i;
                        soma++;
                    }

                    multiplicador2 = (multiplicador2 * 10) % 11;
                    if (multiplicador2 == 10)
                        multiplicador2 = 0;

                    if (multiplicador2 != Convert.ToInt32(cpf.Substring(10, 1)))
                    {
                        cpfValido = false;
                        CpfValidation.VerificarCPF(false, cpf);
                    }                        
                }
            }

            return cpfValido;
        }
    }
}
