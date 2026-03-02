using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    internal class Diamondblock : Block
    {
        public Diamondblock() : base("Obsidian", 40, "GoldSpitzHacke", BlockColor.Turquoise, false) { }

        public override void Dismantle(Tools tool) // <--- Jetzt passt es zum virtual oben!
        {
            base.SetConsoleColor();
            if (tool.Type != ToolType.GoldSpitzHacke)
            {
                Console.WriteLine("-> Das Tool ist zu schwach für Obsidian! (0 Schaden)");
                return;
            }

            // Schaden berechnen (Obsidian ist zäh, also kein Bonus-Schaden hier)
            CurrentHp -= tool.Power;
            Console.WriteLine($"Diamant-Power! Obsidian HP: {Math.Max(0, CurrentHp)}");

            if (CurrentHp <= 0)
            {
                Console.WriteLine(">>> Obsidian wurde mühsam abgebaut! <<<");
            }
        }
    }

}

