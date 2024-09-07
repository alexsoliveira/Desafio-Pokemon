using Desafio.Pokemon.Business.Exceptions;

namespace Desafio.Pokemon.Business.Validations
{
    public class DomainValidation
    {
        public static void NotNull(object? target, string fieldName)
        {
            if (target is null)
                throw new EntityValidationException(
                    $"{fieldName} não pode ser null");
        }

        public static void NotNullOrEmpty(string? target, string fieldName)
        {
            if (String.IsNullOrWhiteSpace(target))
                throw new EntityValidationException(
                    $"{fieldName} não pode ser vazio ou null");
        }

        public static void MinLength(string target, int minLength, string fieldName)
        {
            if (target.Length < minLength)
                throw new EntityValidationException(
                    $"{fieldName} deve ser maior ou igual a {minLength} caracteres");
        }

        public static void MaxLength(string target, int maxLength, string fieldName)
        {
            if (target.Length > maxLength)
                throw new EntityValidationException(
                    $"{fieldName} deve ser menor ou igual a {maxLength} caracteres");
        }

        public static void MinLength(byte target, int minLength, string fieldName)
        {
            if (target < minLength)
                throw new EntityValidationException(
                    $"{fieldName} deve ser maior ou igual a {minLength}");
        }

        public static void MaxLength(byte target, int maxLength, string fieldName)
        {
            if (target > maxLength)
                throw new EntityValidationException(
                    $"{fieldName} deve ser menor ou igual a {maxLength}");
        }
    }
}
