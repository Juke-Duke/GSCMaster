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
                SecondaryType = pokemon.SecondaryType
            };
        
        public static BasicMoveDTO ConvertToBasic(Move move)
            => new BasicMoveDTO
            {
                Name = move.Name,
                Type = move.Type,
                Power = move.Power,
                Accuracy = move.Accuracy,
                PP = move.PP,
                Description = move.Description
            };

        public static FullPokemonDTO ConvertToFull(Pokemon pokemon)
            => new FullPokemonDTO
            {
                NationalNumber = pokemon.NationalNumber,
                Name = pokemon.Name,
                PrimaryType = pokemon.PrimaryType,
                SecondaryType = pokemon.SecondaryType,
                HP = pokemon.HP,
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                SpAttack = pokemon.SpAttack,
                SpDefense = pokemon.SpDefense,
                Speed = pokemon.Speed,
                Moves = pokemon.Moves.Select(m => ConvertToBasic(m)).ToList()
            };
        
        public static FullMoveDTO ConvertToFull(Move move)
            => new FullMoveDTO
            {
                Name = move.Name,
                Type = move.Type,
                Power = move.Power,
                Accuracy = move.Accuracy,
                PP = move.PP,
                Description = move.Description,
                EligiblePokemon = move.EligiblePokemon.Select(ep => ConvertToBasic(ep)).ToList()
            };

        public static ItemDTO Convert(Item item)
            => new ItemDTO
            {
                Name = item.Name,
                Description = item.Description,
                IsConsumable = item.IsConsumable
            };
    }
}
