using System;

namespace GoblinBattle.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Goblin g1 = new Goblin();
            Goblin g2 = new Goblin();
            
            g1.HitPoints = 10;
            g1.Name = "Bob";
            g1.DodgeChance = 0.25;

            g1.GoblinArmor = new Armor();
            g1.GoblinArmor.PercentRedux = 0.5;

            g1.GoblinWeapon = new Weapon();
            g1.GoblinWeapon.MinDamage = 2;
            g1.GoblinWeapon.MaxDamage = 7;   
            

            g2.HitPoints = 10;
            g2.Name = "Tom";
            g2.DodgeChance = 0.15;

            g2.GoblinArmor = new Armor();
            g2.GoblinArmor.PercentRedux = 0.25;

            g2.GoblinWeapon = new Weapon();
            g2.GoblinWeapon.MinDamage = 8;
            g2.GoblinWeapon.MaxDamage = 10;


            // they should take turns attacking, goblin 1 will go first
            int whoseTurn = 1;

            while (!g1.IsDead && !g2.IsDead)
            {
                if (whoseTurn == 1)
                {
                    g1.Attack(g2);
                    whoseTurn = 2;
                }                    
                else
                {
                    g2.Attack(g1);
                    whoseTurn = 1;
                }
            }

            Console.WriteLine("The battle is ended!");
            Console.ReadLine();
        }
    }
}
