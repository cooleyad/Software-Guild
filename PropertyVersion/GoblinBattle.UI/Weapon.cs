using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinBattle.UI
{
    public class Weapon
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }

        public int CritHit { get; set; }


        internal int GenerateDamage(Goblin target)
        {
            int damage = (int)(RNG.Next(MinDamage, MaxDamage+1)*(1.0-target.GoblinArmor.PercentRedux));

            return damage;
        }
    }
}
