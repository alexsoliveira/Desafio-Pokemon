using Desafio.Pokemon.Business.Domain;
using Desafio.Pokemon.Business.Interfaces;

namespace Desafio.Pokemon.Business.Services
{
    public class MestrePokemonService : IMestrePokemonService
    {
        public readonly IMestrePokemonRepository<MestrePokemon> _mestrePokemonRepository;
        public readonly IUnitOfWork _unitOfWork;

        public MestrePokemonService(
            IMestrePokemonRepository<MestrePokemon> mestrePokemonRepository, 
            IUnitOfWork unitOfWork)
        {
            _mestrePokemonRepository = mestrePokemonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<MestrePokemon> CriarMestrePokemon(
            MestrePokemon mestrePokemon)
        {
            await _mestrePokemonRepository.Insert(mestrePokemon);
            await _unitOfWork.Commit();

            return mestrePokemon;
        }
    }
}
