using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    public struct Ability
    {
        public CoreAbilityKey Key { get; set; }
        public int Score { get; set; }

        public int _modifier;
        public int Modifier
        {
            get => _modifier;
            set => _modifier = value;
        }

        public Ability(CoreAbilityKey key, int score) : this()
        {
            Key = key;
            Score = score;
            Modifier = (Score / 2) - 5;
        }
        public Ability(CoreAbilityKey key, double seed) : this()
        {
            Key = key;
            Score = new Random((int)seed).Next(3, 18);
        }
    }
}
