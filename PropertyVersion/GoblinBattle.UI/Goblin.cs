using System;

namespace GoblinBattle.UI
{
    class Goblin
    {
        // we only need one rng for all goblin instances, so static
        //private static Random _rng = new Random();

        public double DodgeChance { get; set; }

        public Armor GoblinArmor{get; set; }

        public Weapon GoblinWeapon { get; set; }

        public double CritHit { get; set; }

        private int _hitPoints;
        public int HitPoints
        {
            get { return _hitPoints; }
            set
            {
                // check incoming value
                if (value < 0)
                    return;
                else // otherwise save it to the field
                    _hitPoints = value;
            }
        }

        public string Name { get; set; }
        public bool IsDead { get; private set; }

        // attack another goblin instance (target)
        public void Attack(Goblin target)
        {
            int damage = GoblinWeapon.GenerateDamage(target);
            
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");

            target.Hit(damage);
        }

        // for when this instance gets hit
        public void Hit(int damage)
        {
            if (RNG.NextDouble() < DodgeChance)
            {
                //dodged
                Console.WriteLine($"{Name} dodged!");
            }
            else
            {
                //damage = GoblinArmor.AdjustDamage( damage );
                // deduct damage
                _hitPoints -= damage;
                Console.WriteLine($"{Name} receives {damage} damage. They have {_hitPoints} health.");

                // should we die?
                if (_hitPoints <= 0)
                {
                    Console.WriteLine($"{Name} has died!");
                    IsDead = true;
                }
            }
        }
    }
}
