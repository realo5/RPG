using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    struct Ability
    {
        public int Score { get; set; }
        public int _modifier;
        public int Modifier
        {
            get => _modifier;
            private set
            {
                _modifier = value;
            }
        }
        public Ability(int score) : this()
        {
            Score = score;
            Modifier = (Score / 2) - 5;
        }
    }
}
