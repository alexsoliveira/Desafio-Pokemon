using Desafio.Pokemon.Business.Exceptions;

namespace Desafio.Pokemon.Business.Validations
{
    public static class CpfValidation
    {
        public static void VerificarCPF(bool target, string fieldName)
        {
            if (!target)
                throw new EntityValidationException(
                    $"{fieldName} CPF invalido");
        }
    }
}
