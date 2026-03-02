namespace Minecraft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tools hand = new Tools(ToolType.Hand, 1);
            Tools eisenspitzhacke = new Tools(ToolType.Spitzhacke, 6);
            Tools axt = new Tools(ToolType.Axt, 4);
            Tools diamantspitzhacke = new Tools(ToolType.DiamandSpitzHacke, 10);
            Tools schaufel = new Tools(ToolType.Schaufel, 2);
            Tools goldspitzhacke = new Tools(ToolType.GoldSpitzHacke, 8);

            while (true) {
                
                Console.WriteLine("--- Willkommen beim Minecraft Konsolen Spiel ---");
                Console.WriteLine("Wähle dein Werkzeug:");
                Console.WriteLine("1) Hand (Power 1)");
                Console.WriteLine("2) Schaufel (Power 2)");
                Console.WriteLine("3) Axt (Power 4)");
                Console.WriteLine("4) Eisen-Spitzhacke (Power 6)");
                Console.WriteLine("5) Gold-Spitzhacke (Power 8)");
                Console.WriteLine("6) Diamant-Spitzhacke (Power 10)");
                Console.WriteLine("7) Beenden");

                string toolChoice = Console.ReadLine();
                Tools selectedTool = toolChoice switch
                {
                    "1" => hand,
                    "2" => schaufel,
                    "3" => axt,
                    "4" => eisenspitzhacke,
                    "5" => goldspitzhacke,
                    "6" => diamantspitzhacke,
                    "7" => null,
                    _ => hand,
                };

                if (toolChoice == "7")
                {
                    Console.WriteLine("Spiel wird beendet...");
                    Console.WriteLine("Drücke eine beliebige Taste...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }

                if ( toolChoice == "")
                {
                    Console.WriteLine("Du musst eine Wahl treffen...");
                    Console.WriteLine("Drücke eine beliebige Taste...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                Console.WriteLine("\nWelchen Block möchtest du abbauen?");
                Console.WriteLine("A) Gras (2 HP");
                Console.WriteLine("B) Holz (15 HP");
                Console.WriteLine("C) Stein (20 HP");
                Console.WriteLine("D) Diamant (40 HP");
                Console.WriteLine("E) Obsidian (50 HP");

                string blockChoice = Console.ReadLine()?.ToUpper();

                Block targetBlock = blockChoice switch
                {
                    "A" => new Grasblock(),
                    "B" => new Woodblock(),
                    "C" => new Stoneblock(),
                    "D" => new Diamondblock(),
                    "E" => new Obsidianblock(),
                    _=> null
                };

                if (targetBlock != null) 
                {
                    Console.Clear();
                    targetBlock.BurnAlert();

                    targetBlock.MineBlock(selectedTool);
                    Console.WriteLine("\nDrücke eine Taste für das nächste Level!");
                    Console.ReadKey();
                    Console.Clear();
                } else
                {
                    Console.WriteLine("Ungültige Eingabe beginnen Sie von vorne");
                    Console.WriteLine("Drücke eine beliebige Taste...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                

            }
            Console.WriteLine("Ich hoffe du hattest Spaß!");
        }
    }
}
