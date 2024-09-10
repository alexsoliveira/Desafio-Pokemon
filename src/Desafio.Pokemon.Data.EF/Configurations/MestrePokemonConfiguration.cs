using Desafio.Pokemon.Business.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Desafio.Pokemon.Data.EF.Configurations
{
    internal class MestrePokemonConfiguration 
        : IEntityTypeConfiguration<MestrePokemon> 
    {
        public void Configure(EntityTypeBuilder<MestrePokemon> builder)
        {
            builder.HasKey(mestrePokemon => mestrePokemon.Id);

            builder.Property(mestrePokemon => mestrePokemon.Nome)
                .HasMaxLength(30);

            builder.Property(mestrePokemon => mestrePokemon.Idade)
                .HasMaxLength(3);

            //builder.Property(mestrePokemon => mestrePokemon.Cpf)
            //    .HasMaxLength(11);

            builder.OwnsOne(mestrePokemon => mestrePokemon.Cpf, cpf =>
                cpf.Property(campo => campo.Numero)
                .HasColumnName("Cpf")
                .HasMaxLength(11)
            );

            //builder.OwnsOne<Cpf>("Cpf");

            //builder.OwnsOne(m => m.Cpf, c =>
            //{
            //    c.Property(x => x.Numero).HasColumnName("Cpf");
            //});
        }
    }
}
