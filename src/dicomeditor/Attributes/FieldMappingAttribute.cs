using FellowOakDicom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dicomeditor.Attributes
{
    public class FieldMappingAttribute : Attribute
    {
        public uint Tag { get; set; }
        public string? Description { get; set; }
        public FieldMappingAttribute(uint tag)
        {
            Tag = tag;
        }
    }
}
