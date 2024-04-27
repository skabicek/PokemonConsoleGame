
namespace HW01_2024
{
    public class GraphicsUI
    {
        public static void ShowGameIntro()
        {
            do
            {
                Console.WriteLine("Type 'start' to begin :)");

            } while (Console.ReadLine().ToLower().Trim() != "start");

            Console.WriteLine("Welcome to Pokemon Championship!\n" +
                "Please, choose your three Pokemons: (use ' ' or ',' as a delimiter)");
        }

        public static void ColourConsoleName(string name, PokemonType type)
        {
            if (type == PokemonType.Leaf)
                Console.ForegroundColor = ConsoleColor.Green;
            else if (type == PokemonType.Sea)
                Console.ForegroundColor = ConsoleColor.Blue;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write($"{name}");
            Console.ResetColor();
        }

        public static void PrintoutPokemons(List<Pokemon> pokemons, bool calledFromInfo)
        {
            for (int i = 0; i < pokemons.Count; i++)
            {
                Console.Write($"{i + 1}.");
                ColourConsoleName(pokemons[i].Name, pokemons[i].Type);
                Console.Write($": {pokemons[i].Attack} Attack, {pokemons[i].HP} HP, {pokemons[i].Speed} Speed");

                if (calledFromInfo)
                    Console.Write($", level {pokemons[i].Level}, {pokemons[i].Experience}/100 XP");
                Console.WriteLine();
            }
        }

        public static void RoundStatusPrintOut(Pokemon attacker, Pokemon defender,
                                         int damageDealt, int HPremains)
        {
            ColourConsoleName(attacker.Name, attacker.Type);
            Console.Write($" dealt {damageDealt} damage to ");
            ColourConsoleName(defender.Name, defender.Type);

            if (HPremains <= 0)
            {
                Console.Write(". ");
                ColourConsoleName(defender.Name, defender.Type);
                Console.WriteLine(" is defeated!");
            }
            else
            {
                Console.Write(".\n");
                ColourConsoleName(defender.Name, defender.Type);
                Console.WriteLine($" has currently {HPremains} HP.");
            }
        }

        public static void RoundAnnouncement(Pokemon pokemon1, Pokemon pokemon2, int roundNum)
        {
            Console.WriteLine($"Round {roundNum}: ");
            ColourConsoleName(pokemon1.Name, pokemon1.Type);
            Console.Write(" vs. ");
            ColourConsoleName(pokemon2.Name, pokemon2.Type);
            Console.WriteLine();
        }

        public static void PrintChosenPokemons(Trainer player)
        {
            Console.Write("You have chosen ");

            for (int i = 0; i < 3; i++)
            {
                ColourConsoleName(player.Pokemons[i].Name, player.Pokemons[i].Type);
                if (i != 2)
                    Console.Write(", ");
            }
            Console.WriteLine();
            PrintPossibleCommands();
        }

        public static void PrintInvalidInput()
        {
            Console.WriteLine("Invalid input, try again!");
        }

        public static void PrintPossibleCommands()
        {
            Console.WriteLine("Your commands are: check, fight, info, sort, quit.");
        }

        public static void PrintEndGameStatus(bool playerHasWon)
        {
            if (playerHasWon)
                Console.WriteLine("Congratulations! You have won the Pokemon Championship!");
            else
                Console.WriteLine("You have lost the game :(");
        }

        public static void PrintEndBattleStatus(bool playerHasWon, int xpGained, bool newLevelReached)
        {
            if (playerHasWon)
                Console.WriteLine($"You won the battle! Pokemons gained {xpGained} XP! Your Pokemons leveled up!");
            else
            {
                Console.Write($"You lost the battle. Pokemons gained only {xpGained} XP. You ran away...");

                if (newLevelReached)
                    Console.WriteLine(" Your Pokemons leveled up!");
                else
                    Console.WriteLine();
            }
        }

        public static void PrintCheckStatus(Trainer enemy)
        {
            Console.WriteLine("The next trainer has these Pokemons:");
            PrintoutPokemons(enemy.Pokemons, false);
        }

        public static void PrintInfoStatus(Trainer player, int battlesWon)
        {
            Console.WriteLine($"Battles won: {battlesWon}\nYour Pokemons:");
            PrintoutPokemons(player.Pokemons, true);
        }

        public static void ShowSortIntro(Trainer player, bool orderWasUpdated)
        {
            if (!orderWasUpdated)
            {
                Console.WriteLine("Choose the order: (use ' ' or ',' as a delimiter)");
                for (int i = 0; i < 3; i++)
                {
                    Console.Write($"{i + 1}. ");
                    ColourConsoleName(player.Pokemons[i].Name, player.Pokemons[i].Type);
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("The order of your Pokemons has been updated.");
        }
    }
}
