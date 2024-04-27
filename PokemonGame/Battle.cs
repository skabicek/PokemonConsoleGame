using HW01_2024.Interfaces;
using System;

namespace HW01_2024
{
    public class Battle : IBattle
    {
        public Trainer PerformBattle(Trainer player, Trainer enemy)
        {
            int playerPokemonIndex = 0;
            int enemyPokemonIndex = 0;
            int roundNum = 1;

            while (playerPokemonIndex < 3 && enemyPokemonIndex < 3)
            {
                GraphicsUI.RoundAnnouncement(player.Pokemons[playerPokemonIndex],
                                       enemy.Pokemons[enemyPokemonIndex], roundNum);

                Pokemon playerPokemon = player.Pokemons[playerPokemonIndex];
                Pokemon enemyPokemon = enemy.Pokemons[enemyPokemonIndex];
                Pokemon winner = PerformRound(playerPokemon, enemyPokemon);

                if (winner == playerPokemon)
                    enemyPokemonIndex++;
                else
                    playerPokemonIndex++;

                roundNum++;
            }
            return enemyPokemonIndex == 3 ? player : enemy; //player has won against the enemy
        }

        public Pokemon PerformRound(Pokemon playerPokemon, Pokemon enemyPokemon)
        {
            Pokemon attacker = enemyPokemon;
            Pokemon defender = playerPokemon;

            if (playerPokemon.Speed >= enemyPokemon.Speed)
            {
                attacker = playerPokemon;
                defender = enemyPokemon;
            }
            while (true)
            {
                if (StrikeEval(attacker, defender)) //attacker haven't killed defender
                {
                    if (StrikeEval(defender, attacker)) //both Pokemons are still alive;
                        continue;

                    return defender;
                }
                return attacker;
            }
        }

        private static bool StrikeEval(Pokemon attacker, Pokemon defender)
        {
            int damage = attacker.Attack;

            if (attacker.Type == PokemonType.Leaf && defender.Type == PokemonType.Sea ||
                attacker.Type == PokemonType.Sea && defender.Type == PokemonType.Flame ||
                attacker.Type == PokemonType.Flame && defender.Type == PokemonType.Leaf)
            {
                damage *= 2;
            }
            defender.currentHP -= damage;

            GraphicsUI.RoundStatusPrintOut(attacker, defender, damage, defender.currentHP);

            //Method returns true, if the defender has at least 1 HP (= is still alive), false otherwise
            return defender.currentHP > 0;
        }
    }
}
