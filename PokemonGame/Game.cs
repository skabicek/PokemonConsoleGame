using HW01_2024.Interfaces;

namespace HW01_2024
{
    public partial class Game : IGame
    {
        private readonly List<Pokemon> allAvailablePokemons;
        private readonly List<Pokemon> enemyPokemons;
        private readonly Trainer player;
        private readonly Trainer[] enemies;
        private int battlesWon = 0;

        public Game(List<Pokemon> allAvailablePokemons, List<Pokemon> enemyPokemons, 
                    Trainer player, Trainer[] enemies)
        {
            this.allAvailablePokemons = allAvailablePokemons;
            this.enemyPokemons = enemyPokemons;
            this.player = player;
            this.enemies = enemies;
        }

        public void Start()
        {
            GraphicsUI.ShowGameIntro();
            Utils.PlayerPokemonsInit(allAvailablePokemons, player);
            Utils.EnemyPokemonsInit(enemyPokemons, enemies);

            while (true) UserCommandEval();
        }
    }
}
