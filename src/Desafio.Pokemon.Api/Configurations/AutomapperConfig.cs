using AutoMapper;
using Desafio.Pokemon.Api.ViewModels;
using Desafio.Pokemon.Business.Domain;

namespace Desafio.Pokemon.Api.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<MestrePokemon, MestrePokemonViewModel>().ReverseMap();                   
            CreateMap<Cpf, CpfViewModel>().ReverseMap();
        }
    }
}
