using PokemonReviewApps.Data;
using PokemonReviewApps.Models;

namespace PokemonReviewApps
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        public Seed(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public void SeedDataContext()
        {
            if (!_dataContext.PokemonSpecies.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Fire" },
                    new Category { Name = "Water" },
                    new Category { Name = "Grass" },
                    new Category { Name = "Electric" },
                    new Category { Name = "Psychic" },
                    new Category { Name = "Dragon"}
                };

                var countries = new List<Country>()
                {
                    new Country { Name = "Kanto" },
                    new Country { Name = "Johto" },
                    new Country { Name = "Hoenn" },
                    new Country { Name = "Sinnoh" },
                    new Country { Name = "Unova" },
                    new Country { Name = "Kalos" },
                    new Country { Name = "Alola" },
                    new Country { Name = "Galar" }
                };

                var owners = new List<Owner>()
                {
                    new Owner { FirstName = "Ash", LastName = "Ketchum" , Gym = "Pallet Town Gym", Country = countries[0] },
                    new Owner { FirstName = "Misty", LastName = "Williams", Gym = "Cerulean Gym", Country = countries[0] },
                    new Owner { FirstName = "Brock", LastName = "Harrison", Gym = "Pewter Gym", Country = countries[0] },
                    new Owner { FirstName = "Cynthia", LastName = "", Gym = "Champion", Country = countries[3] },
                    new Owner { FirstName = "Leon", LastName = "", Gym = "Champion", Country = countries[7] },
                    new Owner { FirstName = "Lance", LastName = "", Gym = "Dragon Master", Country = countries[0] },
                    new Owner { FirstName = "Gary", LastName = "Oak", Gym = "Researcher", Country = countries[0] }
                };

                var reviewers = new List<Reviewer>
                {
                    new Reviewer { FirstName = "Professor", LastName = "Oak" },
                    new Reviewer { FirstName = "Tracey", LastName = "Sketchit" },
                    new Reviewer { FirstName = "Nurse", LastName = "Joy" }
                };

                var species = new List<PokemonSpecies>
                {
                    new PokemonSpecies { Name = "Pikachu", Description = "Electric mouse Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[3] } } },
                    new PokemonSpecies { Name = "Charizard", Description = "Fire/Flying dragon Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[0] }, new PokemonCategory { Category = categories[5] } } },
                    new PokemonSpecies { Name = "Bulbasaur", Description = "Grass/Poison Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[2] } } },
                    new PokemonSpecies { Name = "Squirtle", Description = "Water turtle Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[1] } } },
                    new PokemonSpecies { Name = "Garchomp", Description = "Dragon/Ground Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[5] } } },
                    new PokemonSpecies { Name = "Psyduck", Description = "Water duck Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[1] }, new PokemonCategory { Category = categories[4] } } },
                    new PokemonSpecies { Name = "Dragonite", Description = "Dragon/Flying Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[5] } } },
                    new PokemonSpecies { Name = "Eevee", Description = "Evolution Pokémon", PokemonCategories = new List<PokemonCategory>{ } },
                    new PokemonSpecies { Name = "Lucario", Description = "Fighting/Steel Pokémon", PokemonCategories = new List<PokemonCategory>{ new PokemonCategory { Category = categories[4] } } },
                    new PokemonSpecies { Name = "Snorlax", Description = "Sleeping Pokémon", PokemonCategories = new List<PokemonCategory>{ } }
                };

                _dataContext.Categories.AddRange(categories);
                _dataContext.Countries.AddRange(countries);
                _dataContext.Owners.AddRange(owners);
                _dataContext.Reviewers.AddRange(reviewers);
                _dataContext.PokemonSpecies.AddRange(species);
                _dataContext.SaveChanges();

                var pokemons = new List<Pokemon>
                {
                    new Pokemon { Nickname = "Pikachu", BirthDate = new DateTime(2015, 5, 1), PokemonSpeciesId = species[0].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[0] } },
                        Reviews = new List<Review> { new Review { Title = "Super fast", Text = "One of the fastest Pokémon!", Rating = 5, Reviewer = reviewers[0] } }
                    },
                    new Pokemon { Nickname = "Charizard", BirthDate = new DateTime(2014, 7, 10), PokemonSpeciesId = species[1].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[0] } },
                        Reviews = new List<Review> { new Review { Title = "Powerful", Text = "Incredible battle skills.", Rating = 5, Reviewer = reviewers[1] } }
                    },
                    new Pokemon { Nickname = "Bulby", BirthDate = new DateTime(2016, 3, 15), PokemonSpeciesId = species[2].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[0] } }
                    },
                    new Pokemon { Nickname = "Squirtle", BirthDate = new DateTime(2016, 8, 21), PokemonSpeciesId = species[3].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[1] } }
                    },
                    new Pokemon { Nickname = "Garchomp", BirthDate = new DateTime(2013, 1, 5), PokemonSpeciesId = species[4].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[3] } }
                    },
                    new Pokemon { Nickname = "Psyduck", BirthDate = new DateTime(2017, 11, 11),     PokemonSpeciesId = species[5].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[1] } }
                    },
                    new Pokemon { Nickname = "Dragonite", BirthDate = new DateTime(2012, 4, 9), PokemonSpeciesId = species[6].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[5] } }
                    },
                    new Pokemon { Nickname = "Eevee", BirthDate = new DateTime(2018, 12, 1),    PokemonSpeciesId = species[7].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[6] } }
                    },
                    new Pokemon { Nickname = "Lucario", BirthDate = new DateTime(2015, 9, 30),  PokemonSpeciesId = species[8].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[4] } }
                    },
                    new Pokemon { Nickname = "Snorlax", BirthDate = new DateTime(2010, 6, 14), PokemonSpeciesId = species[9].Id,
                        PokemonOwners = new List<PokemonOwner> { new PokemonOwner { Owner = owners[2] } }
                    }
                };

                _dataContext.Pokemons.AddRange(pokemons);
                _dataContext.SaveChanges();

            }
        }
    }
}
