using System.Collections.Generic;

namespace Wynathan.Stellaris.Common.Modding.Models
{
    internal class CharacterNamesList
    {
        public CharacterNamesList()
        {
            this.first_names_male = new List<string>();
            this.first_names_female = new List<string>();
            this.first_names = new List<string>();
            this.second_names_male = new List<string>();
            this.second_names_female = new List<string>();
            this.second_names = new List<string>();
            this.regnal_first_names_male = new List<string>();
            this.regnal_first_names_female = new List<string>();
            this.regnal_first_names = new List<string>();
            this.regnal_second_names_male = new List<string>();
            this.regnal_second_names_female = new List<string>();
            this.regnal_second_names = new List<string>();
        }

        public string weight { get; set; }

        public List<string> first_names_male { get; set; }

        public List<string> first_names_female { get; set; }

        public List<string> first_names { get; set; }

        public List<string> second_names_male { get; set; }

        public List<string> second_names_female { get; set; }

        public List<string> second_names { get; set; }

        public List<string> regnal_first_names_male { get; set; }

        public List<string> regnal_first_names_female { get; set; }

        public List<string> regnal_first_names { get; set; }

        public List<string> regnal_second_names_male { get; set; }

        public List<string> regnal_second_names_female { get; set; }

        public List<string> regnal_second_names { get; set; }
    }
}
