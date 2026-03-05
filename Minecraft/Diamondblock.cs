using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    internal class Diamondblock : Block
    {
        public Diamondblock() : base("Diamant", 40, "GoldSpitzHacke", BlockColor.Turquoise, false) { }

        public override bool Dismantle(Tools tool) 
        {

            base.SetConsoleColor();

            if (tool.Type != ToolType.GoldSpitzHacke && tool.Type != ToolType.DiamandSpitzHacke)
            {
                Console.WriteLine("-> Das Tool ist zu schwach für Diamant! (0 Schaden)");
                return false; 
            }

            
            CurrentHp -= tool.Power;
            Console.WriteLine($"Diamant-Power! Diamant HP: {Math.Max(0, CurrentHp)}/{maxHealth}");

            if (CurrentHp <= 0)
            {
                Console.WriteLine(">>> Diamant wurde erfolgreich abgebaut! <<<");
            }

            return true; 
        }
    }
}
    


