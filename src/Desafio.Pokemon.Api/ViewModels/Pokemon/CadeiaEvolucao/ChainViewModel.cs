namespace Desafio.Pokemon.Api.ViewModels.Pokemon.CadeiaEvolucao
{
    public class ChainViewModel
    {
        public List<object>? Evolution_details { get; set; }        
        public List<EvolvesToViewModel>? Evolves_To { get; set; }        
        public SpeciesViewModel? Species { get; set; }
    }
}
