using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMeCore.Core.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string FilePath { get; set; }

        public Gender Gender { get; set; }
    }
}
