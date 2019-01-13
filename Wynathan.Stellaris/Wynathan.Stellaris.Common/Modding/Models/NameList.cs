using Wynathan.Stellaris.Common.Attributes;

namespace Wynathan.Stellaris.Common.Modding.Models
{
    internal class NameList
    {
        public NameList()
        {
            this.ShipNames = new ShipNamesList();
            this.ShipClassNames = new ShipNamesList();
            this.FleetNames = new NamingProperty();
            this.ArmyNames = new ArmyNamesList();
            this.PlanetNames = new PlanetNamesList();
            this.LeaderNames = new CharacterNamesListCollection();
        }
        
        [CommonBinding("randomized")]
        public ThreeWayBoolean? IsRandomised { get; set; }
        
        [CommonBinding("selectable")]
        public ThreeWayBoolean? IsSelectable { get; set; }

        [CommonBinding("alias")]
        public string Alias { get; set; }

        [CommonBinding("ship_names")]
        public ShipNamesList ShipNames { get; set; }

        [CommonBinding("ship_class_names")]
        public ShipNamesList ShipClassNames { get; set; }

        [CommonBinding("fleet_names")]
        public NamingProperty FleetNames { get; set; }

        [CommonBinding("army_names")]
        public ArmyNamesList ArmyNames { get; set; }

        [CommonBinding("planet_names")]
        public PlanetNamesList PlanetNames { get; set; }

        [CommonBinding("character_names")]
        public CharacterNamesListCollection LeaderNames { get; set; }
    }
}
