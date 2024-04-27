namespace HW01_2024.Interfaces
{
    public interface IBattle
    {
        Trainer PerformBattle(Trainer player, Trainer enemy);
        Pokemon PerformRound(Pokemon playerPokemon, Pokemon enemyPokemon);
    }
}
