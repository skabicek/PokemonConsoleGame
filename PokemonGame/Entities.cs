using System;
using System.Collections.Generic;

namespace HW01_2024
{
    public enum PokemonType
    {
        Leaf,
        Flame,
        Sea
    }
    public class Pokemon(string name, int attack, int hp, int speed, PokemonType type)
    {
        public string Name { get; set; } = name;
        public int Attack { get; set; } = attack;
        public int HP { get; set; } = hp;
        public int currentHP { get; set; } = hp;
        public int Speed { get; set; } = speed;
        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public PokemonType Type { get; set; } = type;
    }
    public class Trainer
    {
        public List<Pokemon> Pokemons { get; set; }

        public Trainer(List<Pokemon> pokemons)
        {
            Pokemons = pokemons;
        }
    }
}
