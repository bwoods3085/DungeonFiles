using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            int diceRoll = new Random().Next(1, 101);
            //random value between 1 - 100
            Thread.Sleep(30);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                //attack hits calculate damage below
                int damageDealt = attacker.CalcDamage();
                //to assign damage to defender
                defender.Life -= damageDealt;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{attacker.Name} hit {defender.Name} for {damageDealt} damage.");
                Console.ResetColor();
            }//end if attack
            else
            {
                Console.WriteLine($"{attacker.Name} missed!");
            }
        }// end DoAttack()

        public static void DoBattle(Player player, Enemy enemy)
        {
            //player attacks first
            DoAttack(player, enemy);

            //monster attacks second, if they're alive
            if (enemy.Life > 0)
            {
                DoAttack(enemy, player);
            }//end if

        }//end DoBattle()

    }//end class
}//end namespace
