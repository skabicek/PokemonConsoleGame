
namespace HW01_2024
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pokemon> userPokemons = [
                new Pokemon("Aquafin", 4, 6, 4, PokemonType.Sea),
                new Pokemon("Embergeist", 6, 4, 4, PokemonType.Flame),
                new Pokemon("Photosprout", 5, 6, 4, PokemonType.Leaf),
                new Pokemon("Splashback", 3, 6, 5, PokemonType.Sea),
                new Pokemon("Pyroclaw", 2, 10, 3, PokemonType.Flame),
                new Pokemon("Petalshade", 6, 10, 2, PokemonType.Leaf)
            ];

            List<Pokemon> enemyPokemons = [
                new Pokemon("Maritide", 2, 9, 5, PokemonType.Sea),
                new Pokemon("Incendrake", 2, 15, 4, PokemonType.Flame),
                new Pokemon("Sylvasprint", 6, 1, 5, PokemonType.Leaf),
                new Pokemon("Aquanoxus", 6, 8, 5, PokemonType.Sea),
                new Pokemon("Tidalkraken", 7, 12, 4, PokemonType.Sea),
                new Pokemon("Nepturion", 8, 25, 3, PokemonType.Sea),
                new Pokemon("Poseidon", 5, 10, 4, PokemonType.Sea),
                new Pokemon("Infernodragon", 8, 8, 3, PokemonType.Flame),
                new Pokemon("Danzaburo", 4, 12, 5, PokemonType.Leaf)
            ];

            Trainer player = new([]);
            Trainer enemy_1 = new([]);
            Trainer enemy_2 = new([]);
            Trainer enemy_3 = new([]);
            Trainer[] enemies = [enemy_1, enemy_2, enemy_3];

            Game game = new(userPokemons, enemyPokemons, player, enemies);
            game.Start();
        }
    }
}