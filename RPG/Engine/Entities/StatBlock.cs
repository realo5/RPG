using RPG.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities
{
    struct StatBlock : IHitDie
    {
        public HitDie HD { get; set; } 

        public Ability Strength { get; set; }
        public Ability Dexterity { get; set; }
        public Ability Constitution { get; set; }
        public Ability Intelligence { get; set; }
        public Ability Wisdom { get; set; }
        public Ability Charisma { get; set; }

        public StatBlock(HitDie hitDie) : this()
        {
            HD = hitDie;
        }

        int IHitDie.Roll()
        {
            return HD.Roll(Constitution.Modifier * HD.Amount);
        }
    }
}
