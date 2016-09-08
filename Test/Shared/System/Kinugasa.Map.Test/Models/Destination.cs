using System.Collections.Generic;
using Kinugasa.Map.Attributes;

namespace Kinugasa.Map.Test.Models
{
    public class Destination
    {
        public string StringA { get; set; } = null;

        public string StringB { get; set; } = null;

        public int IntA { get; set; } = 0;

        public int IntB { get; set; } = 0;

        public List<string> StringList { get; set; } = new List<string>();

        [MapAttribute("AttributeB")]
        public string AttributeA { get; set; }

        [MapAttribute("AttributeA")]
        public string AttributeB { get; set; }

        [MapAttribute("AttributeInt2")]
        public int AttributeInt { get; set; } 

        [MapAttribute("AttributeInt")]
        public int AttributeInt2 { get; set; }
    }
}
