using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    internal class Obsidianblock : Block
    {
        public Obsidianblock() : base("Obsidian", 50, "DiamandSpitzHacke", BlockColor.Violet, false) { }



        public override bool Dismantle(Tools tool)
        {
            base.SetConsoleColor();

            if (tool.Type != ToolType.DiamandSpitzHacke)
            {
                Console.WriteLine("-> Das Tool ist zu schwach für Obsidian! (0 Schaden)");
                return false; 
            }

            CurrentHp -= tool.Power;
            Console.WriteLine($"Diamant-Power! Obsidian HP: {Math.Max(0, CurrentHp)}/{maxHealth}");

            if (CurrentHp <= 0)
            {
                Console.WriteLine(">>> Obsidian wurde erfolgreich abgebaut! <<<");
            }

            return true; 
        }
    }
}
