using Bogus;
using Desafio.Pokemon.Business.Exceptions;
using Desafio.Pokemon.Business.Validations;
using FluentAssertions;

namespace Desafio.Pokemon.UnitTests.Domain.Validations
{
    public class DomainValidationTest
    {
        private Faker Faker { get; set; } = new Faker();

        [Fact(DisplayName = nameof(NotNullOK))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullOK()
        {
            var target = Faker.Commerce.ProductName();
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.NotNull(target, fieldName);
            action.Should().NotThrow();
        }

        [Fact(DisplayName = nameof(NotNullThrowWhenNull))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullThrowWhenNull()
        {
            string? target = null;
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.NotNull(target, fieldName);

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{fieldName} não pode ser null");
        }

        [Fact(DisplayName = nameof(NotNullOrEmptyOK))]
        [Trait("Domain", "DomainValidation - Validation")]
        public void NotNullOrEmptyOK()
        {
            var target = Faker.Commerce.ProductName();
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.NotNullOrEmpty(target, fieldName);
            action.Should().NotThrow();
        }

        [Theory(DisplayName = nameof(NotNullOrEmptyThrowWhenEmpty))]
        [Trait("Domain", "DomainValidation - Validation")]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void NotNullOrEmptyThrowWhenEmpty(string? target)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.NotNullOrEmpty(target, fieldName);

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{fieldName} não pode ser vazio ou null");
        }

        [Theory(DisplayName = nameof(MinLengthOK))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(GetValuesGreaterThanTheMin), parameters: 10)]
        public void MinLengthOK(string target, int minLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MinLength(target, minLength, fieldName);

            action
                .Should()
                .NotThrow();
        }

        public static IEnumerable<object[]> GetValuesGreaterThanTheMin(int numbersOfTests = 5)
        {
            yield return new object[] { "12345", 5 };

            var faker = new Faker();

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = faker.Commerce.ProductName();
                var minLength = example.Length - (new Random()).Next(1, 5);
                yield return new object[] { example, minLength };
            }
        }

        [Theory(DisplayName = nameof(MinLengthThrowWhenLess))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(GetValuesSmallerThanTheMin), parameters: 10)]
        public void MinLengthThrowWhenLess(string target, int minLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MinLength(target, minLength, fieldName);

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{fieldName} deve ser maior ou igual a {minLength} caracteres");
        }

        public static IEnumerable<object[]> GetValuesSmallerThanTheMin(int numbersOfTests = 5)
        {
            yield return new object[] { "12345", 10 };

            var faker = new Faker();

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = faker.Commerce.ProductName();
                var minLength = example.Length + (new Random()).Next(1, 20);
                yield return new object[] { example, minLength };
            }
        }
        // tamanho maximo
        [Theory(DisplayName = nameof(MaxLengthOK))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(GetValuesLessThanTheMax), parameters: 10)]
        public void MaxLengthOK(string target, int maxLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MaxLength(target, maxLength, fieldName);

            action
                .Should()
                .NotThrow();
        }

        public static IEnumerable<object[]> GetValuesLessThanTheMax(int numbersOfTests = 5)
        {
            yield return new object[] { "12345", 5 };

            var faker = new Faker();

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = faker.Commerce.ProductName();
                var maxLength = example.Length + (new Random()).Next(0, 5);
                yield return new object[] { example, maxLength };
            }
        }

        [Theory(DisplayName = nameof(MaxLengthThrowWhenGreater))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(GetValuesSmallerThanTheMax), parameters: 10)]
        public void MaxLengthThrowWhenGreater(string target, int maxLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MaxLength(target, maxLength, fieldName);

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{fieldName} deve ser menor ou igual a {maxLength} caracteres");
        }

        public static IEnumerable<object[]> GetValuesSmallerThanTheMax(int numbersOfTests = 5)
        {
            yield return new object[] { "123456", 5 };

            var faker = new Faker();

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = faker.Commerce.ProductName();
                var maxLength = example.Length - (new Random()).Next(1, 5);
                yield return new object[] { example, maxLength };
            }
        }

        [Theory(DisplayName = nameof(MinByteOK))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(ObterValorMaiorQueMinimoByte), parameters: 10)]
        public void MinByteOK(byte target, int minLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MinLength(target, minLength, fieldName);

            action
                .Should()
                .NotThrow();
        }

        public static IEnumerable<object[]> ObterValorMaiorQueMinimoByte(int numbersOfTests = 5)
        {            
            yield return new object[] { 5, 5 };            

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = (byte)new Random().Next(5, 100);
                var minLength = example - (new Random()).Next(0, 5);
                yield return new object[] { example, minLength };
            }
        }

        [Theory(DisplayName = nameof(ErrorQuandoValorMinimoForMenorQueMinimo))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(ObterValorMenorQueMinimo), parameters: 10)]
        public void ErrorQuandoValorMinimoForMenorQueMinimo(byte target, int minLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MinLength(target, minLength, fieldName);

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{fieldName} deve ser maior ou igual a {minLength}");
        }

        public static IEnumerable<object[]> ObterValorMenorQueMinimo(int numbersOfTests = 5)
        {
            yield return new object[] { 4, 5 };

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = (byte)new Random().Next(5, 100);
                var minLength = example + (new Random()).Next(1, 5);
                yield return new object[] { example, minLength };
            }            
        }
        
        [Theory(DisplayName = nameof(MaxByteOK))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(ObterValorMenorOrIgualAMaximo), parameters: 10)]
        public void MaxByteOK(byte target, int maxLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MaxLength(target, maxLength, fieldName);

            action
                .Should()
                .NotThrow();
        }

        public static IEnumerable<object[]> ObterValorMenorOrIgualAMaximo(int numbersOfTests = 5)
        {
            yield return new object[] { 5, 5 };            

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = (byte)new Random().Next(5, 100);
                var maxLength = example + (new Random()).Next(0, 5);
                yield return new object[] { example, maxLength };
            }            
        }

        [Theory(DisplayName = nameof(ErrorQuandoValorMaximoForMaiorQueMaximo))]
        [Trait("Domain", "DomainValidation - Validation")]
        [MemberData(nameof(ObterValorMaiorQueMaximo), parameters: 10)]
        public void ErrorQuandoValorMaximoForMaiorQueMaximo(byte target, int maxLength)
        {
            var fieldName = Faker.Commerce.ProductName().Replace(" ", "");

            Action action =
                () => DomainValidation.MaxLength(target, maxLength, fieldName);

            action
                .Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{fieldName} deve ser menor ou igual a {maxLength}");
        }

        public static IEnumerable<object[]> ObterValorMaiorQueMaximo(int numbersOfTests = 5)
        {
            yield return new object[] { 6, 5 };            

            for (int i = 0; i < (numbersOfTests - 1); i++)
            {
                var example = (byte)new Random().Next(5, 100);
                var maxLength = example - (new Random()).Next(1, 5);
                yield return new object[] { example, maxLength };
            }
        }
    }
}
