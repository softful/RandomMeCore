using System.Collections.Generic;

namespace RandomMeCore.Core.Models
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<NameBlock> NameBlocks { get; set; }
    }
}
