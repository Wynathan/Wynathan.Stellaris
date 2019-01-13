namespace Wynathan.Stellaris.Common.Modding.Models
{
    internal class PlanetNamesList : NamingProperty
    {
        public PlanetNamesList()
        {
            this.generic = new NamingProperty();
            this.pc_arid = new NamingProperty();
            this.pc_desert = new NamingProperty();
            this.pc_savannah = new NamingProperty();
            this.pc_alpine = new NamingProperty();
            this.pc_arctic = new NamingProperty();
            this.pc_tundra = new NamingProperty();
            this.pc_continental = new NamingProperty();
            this.pc_ocean = new NamingProperty();
            this.pc_tropical = new NamingProperty();
            this.pc_gaia = new NamingProperty();
            this.pc_nuked = new NamingProperty();
        }

        public NamingProperty generic { get; set; }

        public NamingProperty pc_arid { get; set; }

        public NamingProperty pc_desert { get; set; }

        public NamingProperty pc_savannah { get; set; }

        public NamingProperty pc_alpine { get; set; }

        public NamingProperty pc_arctic { get; set; }

        public NamingProperty pc_tundra { get; set; }

        public NamingProperty pc_continental { get; set; }

        public NamingProperty pc_ocean { get; set; }

        public NamingProperty pc_tropical { get; set; }

        public NamingProperty pc_gaia { get; set; }

        public NamingProperty pc_nuked { get; set; }
    }
}
