using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.Models
{
    public class TagInfo
    {
        public string Group { get; set; }
        public string Element { get; set; }
        public string? Keyword { get; set; }
        public string? Name { get; set; }
        public string? VR { get; set; }
        public int Length { get; set; }
        public string? Value { get; set; }
    }
}
