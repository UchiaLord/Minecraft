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

            Dictionary<string, int> inventory = new Dictionary<string, int>();

                    Console.WriteLine(@"
            ###############################################
            #                                             #
            #        MINECRAFT CONSOLE EDITION            #
            #                                             #
            ###############################################");

            while (true)
            {

                Console.WriteLine("\n╔════════════════ INVENTAR ════════════════╗");
                if (inventory.Count == 0) // Hier wird geprüft, ob die "Liste" leer ist
                {
                    Console.WriteLine("Dein Inventar ist leer...");
                }
                foreach (var item in inventory)
                {
                    if (item.Value > 0 && !string.IsNullOrEmpty(item.Key))
                    {
                        Console.WriteLine($"  » {item.Key,-15} | x{item.Value}");
                    } 
                   
                }



                Console.WriteLine("┌──────────────────────────────────────────");
                Console.WriteLine("│ [WÄHLE DEIN WERKZEUG]                    ");
                Console.WriteLine("├──────────────────────────────────────────");
                Console.WriteLine("│ 1) [✋] Hand              (Power  1)     ");
                Console.WriteLine("│ 2) [🥄] Schaufel           (Power  2)    ");
                Console.WriteLine("│ 3) [🪓] Axt                (Power  4)     ");
                Console.WriteLine("│ 4) [⛏️ ] Eisen-Picke       (Power  6)    ");
                Console.WriteLine("│ 5) [✨] Gold-Picke        (Power  8)     ");
                Console.WriteLine("│ 6) [💎] Diamant-Picke     (Power 10)     ");
                Console.WriteLine("│ 7) [🚪] Beenden                          ");
                Console.WriteLine("└──────────────────────────────────────────");

                Console.WriteLine("Wähle dein Werkzeug > ");
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
                        Console.WriteLine("\nSpiel wird beendet... Bis zum nächsten Mal!");
                        Console.WriteLine("Drücke eine beliebige Taste...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }

                    if (toolChoice == "")
                    {
                        Console.WriteLine("⚠️ Du musst eine Wahl treffen!");
                        Console.WriteLine("Drücke eine beliebige Taste...");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    Console.WriteLine("\nWelchen Block möchtest du abbauen?");
                    Console.WriteLine("  [A] Gras (2 HP)   [B] Holz (15 HP)   [C] Stein (20 HP)");
                    Console.WriteLine("  [D] Diamant (40 HP) [E] Obsidian (50 HP)");
                    Console.Write("\nDeine Wahl > ");
                    string blockChoice = Console.ReadLine()?.ToUpper();

                    Block targetBlock = blockChoice switch
                    {
                        "A" => new Grasblock(),
                        "B" => new Woodblock(),
                        "C" => new Stoneblock(),
                        "D" => new Diamondblock(),
                        "E" => new Obsidianblock(),
                        _ => null
                    };

                    if (targetBlock != null)
                    {
                        Console.Clear();
                        targetBlock.BurnAlert();
                        Console.WriteLine("══════════════ ACTION ══════════════");
                        targetBlock.MineBlock(selectedTool, inventory);
                        Console.WriteLine("\n[Level abgeschlossen!] Drücke eine Taste...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("❌ Ungültige Eingabe! Probiere es nochmal.");
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

