﻿using Bogus.Extensions.Brazil;
using Desafio.Pokemon.IntegrationTests.Base;
using DomainEntity = Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.IntegrationTests.UnitOfWork
{
    [CollectionDefinition(nameof(UnitOfWorkTestFixture))]
    public class UnitOfWorkTestFixtureColection
        : ICollectionFixture<UnitOfWorkTestFixture>
    { }

    public class UnitOfWorkTestFixture
        : BaseFixture
    {
        public string ObterNomeMestrePokemonValido()
        {
            var nomeMestrePokemon = "";

            while (nomeMestrePokemon.Length < 3)
                nomeMestrePokemon = Faker.Commerce.Categories(1)[0];

            if (nomeMestrePokemon.Length > 30)
                nomeMestrePokemon = nomeMestrePokemon[..30];

            return nomeMestrePokemon;
        }

        public byte ObterIdadeMestrePokemonValido()
        {
            byte idade = 0;

            //regra para idade valida de 10 até 100 anos.
            idade = (byte)new Random().Next(10, 100);

            return idade;
        }

        public DomainEntity.Cpf ObterCPFMestrePokemonValido()
        {

            var cpf = new DomainEntity.Cpf(
                Faker.Person.Cpf().Replace("-", "").Replace(".", "")
            );

            return cpf;
        }

        public DomainEntity.MestrePokemon ObterMestrePokemonValido()
            => new(
                ObterNomeMestrePokemonValido(),
                ObterIdadeMestrePokemonValido(),
                ObterCPFMestrePokemonValido()
            );

        public List<DomainEntity.MestrePokemon> ObterMestrePokemonLista(int length = 10)
            => Enumerable.Range(1, length)
            .Select(_ => ObterMestrePokemonValido()).ToList();
    }
}
