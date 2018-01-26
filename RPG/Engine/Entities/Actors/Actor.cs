using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.ActorRaces;

namespace RPG.Engine.Entities.Actors
{
    class Actor : Entity
    {
        public string Name { get; set; }
        public ActorRace Race { get; set; }

        public static List<string> NamePrefixes = new List<string>()
        {
            "Gor",
            "Myd",
            "Fin",
            "Kras"
        };

        public static List<string> NameSuffixes = new List<string>()
        {
            "bar",
            "mel",
            "fink",
            "aloire"
        };

        private Dictionary<string, Ability> _abilities;

        public Dictionary<string, Ability> Abilities
        {
            get { return _abilities; }
            set { _abilities = value; }
        }

        public Actor()
        {

        }

        public Actor(double seed)
        {
            Console.WriteLine($"Actor: {this.GetHashCode()}");
            Console.WriteLine($"SessionTimeSeed: {seed}");

            Random prng = new Random((int)seed);

            Abilities = new Dictionary<string, Ability>()
            {
                { "Strength", new Ability(seed) },
                { "Dexterity", new Ability(seed) },
                { "Constitution", new Ability(seed) },
                { "Intelligence", new Ability(seed) },
                { "Wisdom", new Ability(seed) },
                { "Charisma", new Ability(seed) },
            };

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(NamePrefixes[prng.Next(0, NamePrefixes.Count -1)]);
            stringBuilder.Append(NameSuffixes[prng.Next(0, NameSuffixes.Count - 1)]);

            Name = stringBuilder.ToString();

            Console.Write($"{Name}: ");
            DisplayAbilities();
        }

        public void DisplayAbilities()
        {
            foreach (KeyValuePair<string, Ability> pair in Abilities)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Score}({pair.Value.Modifier})");
            }
        }
    }
}
