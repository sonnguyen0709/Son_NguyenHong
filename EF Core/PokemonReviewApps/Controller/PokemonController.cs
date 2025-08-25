using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApps.Dto;
using PokemonReviewApps.Interface;
using PokemonReviewApps.Models;
using PokemonReviewApps.Request;

namespace PokemonReviewApps.Controller
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet]
        public ActionResult GetAllPokemon()
        {
            var pokemons = _pokemonService.GetAllPokemons();

            return Ok(pokemons);
        }

        [Authorize(Roles = "Admin,User")]
        [HttpGet("{pokeId}")]
        public ActionResult GetPokemonById(int pokeId)
        {
            var pokemon = _pokemonService.GetPokemonById(pokeId);
            if (pokemon == null)
                return NotFound($"Pokemon with Id {pokeId} not found");
            return Ok(pokemon);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreatePokemon([FromBody] PokemonCreatedRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request data");

            var created = _pokemonService.CreatePokemon(request);

            if (!created)
                return StatusCode(500, "Something wrong while updating pokemon");

            return Ok("Pokemon created successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{pokeId}")]

        public IActionResult UpdatePokemon(int pokeId, [FromBody] PokemonUpdatedRequest request)
        {
            if (request == null)
                return BadRequest("Invalid request data");
            if (!_pokemonService.PokemonExists(pokeId))
                return NotFound($"Pokemon with Id {pokeId} not found");

            var updated = _pokemonService.UpdatePokemon(pokeId, request);

            if (!updated)
                return StatusCode(500, "Something wrong while updating pokemon");

            return Ok("Pokemon updated successfully");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{pokeId}")]
        public IActionResult DeletePokemon(int pokeId)
        {
            if (!_pokemonService.PokemonExists(pokeId))
                return NotFound($"Pokemon with Id {pokeId} not found");

            var deleted = _pokemonService.DeletePokemon(pokeId);
            if (!deleted)
                return StatusCode(500, "Something wrong while deleting Pokemon");

            return Ok("Pokemon deleted successfully");
        }
    }
}
