using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG.Engine.Entities.Actors.ActorRaces;

namespace RPG.Engine.Entities.Actors
{
    public class Actor : Entity
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

        private List<Ability> _abilities;

        public List<Ability> Abilities
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

            foreach(CoreAbilityKey key in Enum.GetValues(typeof(CoreAbilityKey)).Cast<CoreAbilityKey>().ToList<CoreAbilityKey>())
            {
                Abilities.Add(new Ability(key, seed));
            }

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(NamePrefixes[prng.Next(0, NamePrefixes.Count -1)]);
            stringBuilder.Append(NameSuffixes[prng.Next(0, NameSuffixes.Count - 1)]);

            Name = stringBuilder.ToString();

            Console.Write($"{Name}: ");
            //OnCreated(this);
        }

        private void DisplayAbilities()
        {
            foreach (Ability ability in Abilities)
            {
                Console.WriteLine($"{ability.Key}: {ability.Score}({ability.Modifier})");
            }
        }

        //public override void OnCreated(Entity source)
        //{
        //    DisplayAbilities();
        //}
    }
}
