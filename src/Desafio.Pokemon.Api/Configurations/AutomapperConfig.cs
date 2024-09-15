using AutoMapper;
using Desafio.Pokemon.Api.ViewModels;
using Desafio.Pokemon.Api.ViewModels.Pokemon;
using Desafio.Pokemon.Api.ViewModels.Pokemon.CadeiaEvolucao;
using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Business.Domain.Pokemon;
using Desafio.Pokemon.Business.Domain.Pokemon.Evolucao.CadeiaEvolucao;

namespace Desafio.Pokemon.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<MestrePokemon, MestrePokemonViewModel>().ReverseMap();                   
            CreateMap<Cpf, CpfViewModel>().ReverseMap();

            CreateMap<PokemonDetalhes, PokemonDetalhesViewModel>().ReverseMap();
            CreateMap<PokemonSprites, PokemonSpritesViewModel>().ReverseMap();
            CreateMap<PokemonType, PokemonTypeViewModel>().ReverseMap();
            CreateMap<Tipo, TypeViewModel>().ReverseMap();

            CreateMap<CadeiaEvolucao, CadeiaEvolucaoViewModel>().ReverseMap();
            CreateMap<Chain,  ChainViewModel>().ReverseMap();
            CreateMap<EvolvesTo, EvolvesToViewModel>().ReverseMap();
            CreateMap<Species, SpeciesViewModel>().ReverseMap();
        }
    }
}
