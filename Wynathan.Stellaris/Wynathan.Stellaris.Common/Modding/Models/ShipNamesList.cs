using System.Collections.Generic;
using Wynathan.Stellaris.Common.Attributes;

namespace Wynathan.Stellaris.Common.Modding.Models
{
    internal class ShipNamesList : NamingProperty
    {
        public ShipNamesList()
        {
            this.Corvette = new List<string>();
            this.Destroyer = new List<string>();
            this.Cruiser = new List<string>();
            this.Battleship = new List<string>();
            this.Titan = new List<string>();
            this.Colossus = new List<string>();
            this.DefenceStation = new List<string>();
            this.IonCannonStation = new List<string>();
            this.Transport = new List<string>();
            this.Constructor = new List<string>();
            this.Colony = new List<string>();
            this.Science = new List<string>();
        }

        [CommonBinding("corvette")]
        public List<string> Corvette { get; set; }

        [CommonBinding("destroyer")]
        public List<string> Destroyer { get; set; }

        [CommonBinding("cruiser")]
        public List<string> Cruiser { get; set; }

        [CommonBinding("battleship")]
        public List<string> Battleship { get; set; }

        [CommonBinding("titan")]
        public List<string> Titan { get; set; }

        [CommonBinding("colossus")]
        public List<string> Colossus { get; set; }

        [CommonBinding("military_station_small")]
        public List<string> DefenceStation { get; set; }

        [CommonBinding("ion_cannon")]
        public List<string> IonCannonStation { get; set; }

        [CommonBinding("transport")]
        public List<string> Transport { get; set; }

        [CommonBinding("constructor")]
        public List<string> Constructor { get; set; }

        [CommonBinding("colonizer")]
        public List<string> Colony { get; set; }

        [CommonBinding("science")]
        public List<string> Science { get; set; }
    }
}
