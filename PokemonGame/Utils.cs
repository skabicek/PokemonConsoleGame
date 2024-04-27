
namespace HW01_2024
{
    public class Utils
    {
        public static void PlayerPokemonsInit(List<Pokemon> allAvailablePokemons, Trainer player)
        {
            GraphicsUI.PrintoutPokemons(allAvailablePokemons, false);
            while (true)
            {
                string[] userSelection = Console.ReadLine().Trim().Split(' ', ',');

                if (Validation.SelectionIsValid(userSelection, allAvailablePokemons.Count))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        int index = int.Parse(userSelection[i]) - 1;
                        player.Pokemons.Add(allAvailablePokemons[index]);
                    }
                    GraphicsUI.PrintChosenPokemons(player);
                    break;
                }
                GraphicsUI.PrintInvalidInput();
            }
        }

        /* Function randomly assignes Pokemons to 3 enemy Trainers, 3 Pokemons for each
          uses set to avoid using same Pokemons indexes, then calls StrenghtenHigherEnemies()
          which sets higher Attack & HP to Trainers 2 and 3 */
        public static void EnemyPokemonsInit(List<Pokemon> enemyPokemons, Trainer[] enemyTrainers)
        {
            Random random = new();

            var set = new HashSet<int>(Enumerable.Range(0, enemyPokemons.Count));

            for (int i = 0; i < 9; i++)
            {
                int currentIndex = set.ElementAt(random.Next(set.Count));
                enemyTrainers[i / 3].Pokemons.Add(enemyPokemons[currentIndex]);
                set.Remove(currentIndex);
            }
            StrenghtenHigherEnemies(enemyTrainers);
        }

        private static void StrenghtenHigherEnemies(Trainer[] enemyTrainers)
        {
            for (int i = 1; i < 3; i++)

                for(int j = 0; j < 3; j++)
                {
                    enemyTrainers[i].Pokemons[j].Attack += i * 2;
                    enemyTrainers[i].Pokemons[j].HP += i * 2;
                    enemyTrainers[i].Pokemons[j].currentHP += i * 2;
                }
        }

        public static void LevelUpPokemons(Trainer player)
        {
            Random random = new();

            while (player.Pokemons[0].Experience - 100 >= 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    player.Pokemons[i].Level++;
                    player.Pokemons[i].Experience -= 100;
                    player.Pokemons[i].Attack += random.Next(1, 3);
                    player.Pokemons[i].HP += random.Next(1, 3);
                    player.Pokemons[i].currentHP = player.Pokemons[i].HP;
                }
            }
        }

        public static void SetBackHP(Trainer player)
        {
            for (int i = 0; i < 3; i++) 
                player.Pokemons[i].currentHP = player.Pokemons[i].HP;
        }
    }
}
