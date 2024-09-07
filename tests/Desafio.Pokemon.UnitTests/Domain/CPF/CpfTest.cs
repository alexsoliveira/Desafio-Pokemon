using Desafio.Pokemon.Business.Exceptions;
using FluentAssertions;
using DomainEntity = Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.UnitTests.Domain.CPF
{
    [Collection(nameof(CpfTestFixture))]
    public class CpfTest
    {
        private readonly CpfTestFixture _fixture;

        public CpfTest(CpfTestFixture fixture)
            => _fixture = fixture;

        [Fact(DisplayName = nameof(InstanciaCPF))]
        [Trait("Domain", "CPF - Aggregates")]
        public void InstanciaCPF()
        {
            var cpfValido = _fixture.ObterCPFValido();

            var cpf = new DomainEntity.Cpf(
                cpfValido.Numero
            );

            cpf.Should().NotBeNull();
            cpf.Numero.Should().Be(cpfValido.Numero);            
        }
        
        [Theory(DisplayName = nameof(InstanciaCPFNumeroVazioOuNull))]
        [Trait("Domain", "CPF - Aggregates")]
        [InlineData("")]
        [InlineData(" ")]        
        [InlineData(null)]
        public void InstanciaCPFNumeroVazioOuNull(string cpf)
        {
            Action action = () => new DomainEntity.Cpf(
                cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage("cpf não pode ser vazio ou null");                
        }

        [Theory(DisplayName = nameof(InstanciaCPFNumeroInvalido))]
        [Trait("Domain", "CPF - Aggregates")]
        [InlineData("999999999999")]        
        [InlineData("0000000000000")]
        [InlineData("aaaaaaaaaaa")]
        [InlineData("12345678999")]
        public void InstanciaCPFNumeroInvalido(string cpf)
        {            
            Action action = () => new DomainEntity.Cpf(
                cpf
            );

            action.Should()
                .Throw<EntityValidationException>()
                .WithMessage($"{cpf} CPF invalido");            
        }        
    }
}
