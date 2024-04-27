using HW01_2024.Interfaces;

namespace HW01_2024
{
    public partial class Game : IGame
    {
        public void UserCommandEval()
        {
            switch (Console.ReadLine().ToLower().Trim())
            {
                case "check":
                    GraphicsUI.PrintCheckStatus(enemies[battlesWon]);
                    break;
                case "fight":
                    Fight(player, enemies);
                    break;
                case "info":
                    GraphicsUI.PrintInfoStatus(player, battlesWon);
                    break;
                case "sort":
                    Sort(player);
                    break;
                case "quit":
                    GraphicsUI.PrintEndGameStatus(false);
                    Environment.Exit(0);
                    break;
                default:
                    GraphicsUI.PrintInvalidInput();   
                    GraphicsUI.PrintPossibleCommands();
                    break;
            }
        }

        private void Fight(Trainer player, Trainer[] enemies)
        {
            int xpGained = 100;
            Battle battle = new();
            Trainer winner = battle.PerformBattle(player, enemies[battlesWon]);

            if (winner == player)
            {
                battlesWon++;
                xpGained += 50;

                if (battlesWon == 3)
                {
                    GraphicsUI.PrintEndGameStatus(true); //player has won the championship
                    Environment.Exit(0);
                }
                GraphicsUI.PrintEndBattleStatus(true, xpGained, true);
            }
            else
            {
                GraphicsUI.PrintEndBattleStatus(false, xpGained, player.Pokemons[0].Experience + xpGained >= 100);
                Utils.SetBackHP(enemies[battlesWon]);
            }
            Utils.SetBackHP(player);
            for (int i = 0; i < 3; i++) player.Pokemons[i].Experience += xpGained;
            Utils.LevelUpPokemons(player);
        }

        private static void Sort(Trainer player)
        {
            GraphicsUI.ShowSortIntro(player, false);

            while (true)
            {
                string[] newOrder = Console.ReadLine().Trim().Split(' ', ',');

                if (Validation.SelectionIsValid(newOrder, 3))
                {
                    List<Pokemon> sortedPokemons = [];
                    for (int i = 0; i < 3; i++)
                    {
                        int newIdx = int.Parse(newOrder[i]);
                        sortedPokemons.Add(player.Pokemons[newIdx - 1]);
                    }
                    player.Pokemons = sortedPokemons;
                    GraphicsUI.ShowSortIntro(player, true);
                    break;
                }
                GraphicsUI.PrintInvalidInput();
            }
        }
    }
}
