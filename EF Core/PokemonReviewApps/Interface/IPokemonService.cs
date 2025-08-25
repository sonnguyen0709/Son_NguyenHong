using PokemonReviewApps.Models;
using PokemonReviewApps.Dto;
using PokemonReviewApps.Request;

namespace PokemonReviewApps.Interface
{
    public interface IPokemonService
    {
        ICollection<PokemonDto> GetAllPokemons();
        PokemonDto? GetPokemonById(int id);
        bool PokemonExists(int pokeId);
        bool CreatePokemon(PokemonCreatedRequest request);
        bool UpdatePokemon(int id, PokemonUpdatedRequest request);
        bool DeletePokemon(int pokeId);
        bool Save();
    }
}
