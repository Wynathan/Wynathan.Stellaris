using Wynathan.Stellaris.Common.Attributes;

namespace Wynathan.Stellaris.Common.Modding.Models
{
    internal class ArmyNamesList : NamingProperty
    {
        public ArmyNamesList()
        {
            this.Generic = new NamingProperty();
            this.AssaultArmy = new NamingProperty();
            this.DefenceArmy = new NamingProperty();
            this.SlaveArmy = new NamingProperty();
            this.CloneArmy = new NamingProperty();
            this.RoboticArmy = new NamingProperty();
            this.RoboticDefenceArmy = new NamingProperty();
            this.PsionicArmy = new NamingProperty();
            this.XenomorphArmy = new NamingProperty();
            this.GeneWarriorArmy = new NamingProperty();
            this.OccupationArmy = new NamingProperty();
            this.RoboticOccupationArmy = new NamingProperty();
            this.PrimitiveArmy = new NamingProperty();
            this.IndustrialArmy = new NamingProperty();
            this.PostAtomicArmy = new NamingProperty();
        }

        [CommonBinding("generic")]
        public NamingProperty Generic { get; set; }

        [CommonBinding("assault_army")]
        public NamingProperty AssaultArmy { get; set; }

        [CommonBinding("defense_army")]
        public NamingProperty DefenceArmy { get; set; }

        [CommonBinding("slave_army")]
        public NamingProperty SlaveArmy { get; set; }

        [CommonBinding("clone_army")]
        public NamingProperty CloneArmy { get; set; }

        [CommonBinding("robotic_army")]
        public NamingProperty RoboticArmy { get; set; }

        [CommonBinding("robotic_defense_army")]
        public NamingProperty RoboticDefenceArmy { get; set; }

        [CommonBinding("psionic_army")]
        public NamingProperty PsionicArmy { get; set; }

        [CommonBinding("xenomorph_army")]
        public NamingProperty XenomorphArmy { get; set; }

        [CommonBinding("gene_warrior_army")]
        public NamingProperty GeneWarriorArmy { get; set; }

        [CommonBinding("occupation_army")]
        public NamingProperty OccupationArmy { get; set; }

        [CommonBinding("robotic_occupation_army")]
        public NamingProperty RoboticOccupationArmy { get; set; }

        [CommonBinding("primitive_army")]
        public NamingProperty PrimitiveArmy { get; set; }

        [CommonBinding("industrial_army")]
        public NamingProperty IndustrialArmy { get; set; }

        [CommonBinding("postatomic_army")]
        public NamingProperty PostAtomicArmy { get; set; }
    }
}
