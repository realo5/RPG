using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Engine.Entities.Items.Goods
{
    abstract class Wine : Item
    {
        public string Region
        { get; set; }
        public decimal Acidity
        { get; set; }
    }

    class CabernetSauvignon : Wine
    {

    }

    class PinotNoir : Wine
    {

    }

    class Malbec : Wine
    {

    }

    class Chianti : Wine
    {

    }

    class WhiteRioja : Wine
    {

    }

    class SauvignonBlanc : Wine
    {

    }
}
