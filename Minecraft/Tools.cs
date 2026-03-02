using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minecraft
{
    public enum ToolType
    {
        Hand = 1,
        Schaufel = 2,
        Axt = 3,
        Spitzhacke = 4,
        GoldSpitzHacke = 5,
        DiamandSpitzHacke = 6
    }

    internal class Tools
    {
        public ToolType Type {  get; set; }
        public int Power { get; set; }

        public Tools(ToolType type, int power)
        {
            Type = type;
            Power = power;
        }
    }
}

