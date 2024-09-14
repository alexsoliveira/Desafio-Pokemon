using Desafio.Pokemon.Business.Exceptions;

namespace Desafio.Pokemon.Business.Validations
{
    public static class PokemonValidation
    {
        public static void MinLength(int target, int minLength, string fieldName)
        {
            if (target < minLength)
                throw new EntityValidationException(
                    $"{fieldName} deve ser maior ou igual a {minLength} pokemon");
        }

        public static void MaxLength(int target, int maxLength, string fieldName)
        {
            if (target > maxLength)
                throw new EntityValidationException(
                    $"{fieldName} deve ser menor ou igual a {maxLength} pokemon");
        }
    }
}
