using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    enum BlockColor
    {
        Green,
        Grey,
        Turquoise,
        Violet,
        Red
    }
    internal class Block
    {
        public int maxHealth { get; set; }
        public int CurrentHp { get; protected set; }

        /*
         * 
         * 
        Beispiele für Härtewerte:

        Gras/Erde: 0.6 (schnell abbaubar)
        Stein: 1.5
        Eisenblock: 5.0
        Obsidian: 50.0 (extrem langsam)
        Bedrock: -1.0 (unzerstörbar im Überlebensmodus)
         * 
         * 
         */
        public string Name { get; protected set; }

        public bool IsBurnable { get; protected set; }

        public string CorrectTool { get; protected set; }

        public BlockColor Color { get; protected set; }


        public Block(string name, int hp, string correctTool, BlockColor color, bool isBurnable = false)
        {
            Name = name;
            CurrentHp = hp;
            maxHealth = hp; // Wichtig: maxHealth auch setzen!
            CorrectTool = correctTool;
            Color = color;
            IsBurnable = isBurnable;
        }


        public void BurnAlert()
        {
            if (IsBurnable)
            {
                Console.WriteLine("Vorsicht dieses Material kann brennen");
            }
        }

        public virtual bool Dismantle(Tools tool) 
        {
            SetConsoleColor();

            int damage = (tool.Type.ToString() == CorrectTool) ? tool.Power * 2 : tool.Power;

            CurrentHp -= damage;

            Console.WriteLine($"Der Block {Name} wurde mit {tool.Type} getroffen. HP: {Math.Max(0, CurrentHp)}/{maxHealth}");

            if (CurrentHp <= 0)
            {
                Console.WriteLine($">>> {Name} wurde erfolgreich abgebaut! <<<");
            }

            Console.ResetColor();

            return true;
        }

        public void MineBlock(Tools tool, Dictionary<string, int> inventory)
        {
            Console.WriteLine($"Starte Abbau von {Name}...");
            while (CurrentHp > 0)
            {
                bool success = Dismantle(tool);
                if (!success)
                {
                    Console.WriteLine("Abbau abgebrochen: Falsches Werkzeug!"); 
                    return;
                }
            }
            if (inventory.ContainsKey(this.Name))
            {
                inventory[this.Name]++;
            }
            else
            {
                inventory[this.Name] = 1;
            }
        }

        public void SetConsoleColor()
        {
            Console.ForegroundColor = Color switch
            {
                BlockColor.Green => ConsoleColor.Green,
                BlockColor.Grey => ConsoleColor.Gray,
                BlockColor.Turquoise => ConsoleColor.Cyan,
                BlockColor.Violet => ConsoleColor.Magenta,
                BlockColor.Red => ConsoleColor.Red,
                _ => ConsoleColor.White // Standard
            };
        }
    }
}
