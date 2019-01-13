using System.Collections.Generic;
using Wynathan.Stellaris.Common.Attributes;

namespace Wynathan.Stellaris.Common.Modding.Models
{
    internal class NamingProperty
    {
        public NamingProperty()
        {
            this.NamesPool = new List<string>();
            this.RandomNamesPool = new List<string>();
        }

        [CommonBinding("names")]
        public List<string> NamesPool { get; set; }

        [CommonBinding("random_names")]
        public List<string> RandomNamesPool { get; set; }

        [CommonBinding("sequential_name")]
        public string SequentialNamePattern { get; set; }
    }
}
