using GSCMasterGuide.Domain.Entities;

namespace GSCMasterGuide.Domain.DTOs
{
    public class DTOConverter
    {
        public static BasicPokemonDTO ConvertToBasic(Pokemon pokemon)
            => new BasicPokemonDTO
            {
                NationalNumber = pokemon.NationalNumber,
                Name = pokemon.Name,
                PrimaryType = pokemon.PrimaryType,
                SecondaryType = pokemon.SecondaryType,
                Tier = pokemon.Tier
            };

        public static BasicMoveDTO ConvertToBasic(Move move)
            => new BasicMoveDTO
            {
                Name = move.Name,
                Type = move.Type,
                Category = move.Category,
                Power = move.Power,
                Accuracy = move.Accuracy,
                PP = move.PP,
                Description = move.Description
            };

        public static FullPokemonDTO? ConvertToFull(Pokemon? pokemon)
            => pokemon is null ? null : new FullPokemonDTO
            {
                NationalNumber = pokemon.NationalNumber,
                Name = pokemon.Name,
                PrimaryType = pokemon.PrimaryType,
                SecondaryType = pokemon.SecondaryType,
                Tier = pokemon.Tier,
                HP = pokemon.HP,
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                SpAttack = pokemon.SpAttack,
                SpDefense = pokemon.SpDefense,
                Speed = pokemon.Speed,
                EvolutionLine = GetEvolutionLine(pokemon),
                Moves = pokemon.Moves.Select(move => ConvertToBasic(move)).ToList()
            };

        public static FullMoveDTO? ConvertToFull(Move? move)
            => move is null ? null : new FullMoveDTO
            {
                Name = move.Name,
                Type = move.Type,
                Category = move.Category,
                Power = move.Power,
                Accuracy = move.Accuracy,
                PP = move.PP,
                Effect = move.Effect,
                Description = move.Description,
                EligiblePokemon = move.EligiblePokemon.Select(eligiblePokemon => ConvertToBasic(eligiblePokemon)).ToList()
            };

        public static ItemDTO Convert(Item item)
            => new ItemDTO
            {
                Name = item.Name,
                Description = item.Description,
                IsConsumable = item.IsConsumable
            };

        public static IReadOnlyCollection<BasicPokemonDTO> GetEvolutionLine(Pokemon pokemon)
        {
            var currMon = pokemon;
            var evolutionLine = new List<BasicPokemonDTO>();

            while (currMon.PreEvolution is not null)
                currMon = currMon.PreEvolution;

            while (currMon is not null)
            {
                evolutionLine.Add(ConvertToBasic(currMon));

                if (currMon.Evolution.Count == 0)
                    break;
                else if (currMon.Evolution.Count == 1)
                    currMon = currMon.Evolution.First();
                else
                {
                    var evoStage = currMon.Evolution
                        .OrderBy(evo => evo.NationalNumber)
                        .Select(evo => ConvertToBasic(evo))
                        .ToList();

                    evolutionLine.AddRange(evoStage);

                    break;
                }
            }

            return evolutionLine;
        }
    }
}