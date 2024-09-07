using Bogus.Extensions.Brazil;
using Desafio.Pokemon.UnitTests.Common;
using DomainEntity = Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.UnitTests.Domain.CPF
{
    [CollectionDefinition(nameof(CpfTestFixture))]
    public class CpfTestFixtureCollection
    : ICollectionFixture<CpfTestFixture>
    { }

    public class CpfTestFixture : BaseFixture
    {
        public DomainEntity.Cpf ObterCPFValido()
        {

            var cpf = new DomainEntity.Cpf(
                Faker.Person.Cpf().Replace("-", "").Replace(".", "")
            );

            return cpf;
        }        
    }
}
