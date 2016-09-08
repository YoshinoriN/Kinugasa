using System.Collections.Generic;

namespace Kinugasa.Map.Test.Models
{
    public class Source
    {
        public string StringA { get; set; } = "A";

        public int IntA { get; set; } = 1;

        public List<string> StringList { get; set; } = new List<string>() { "A", "B", "C" };

        public string AttributeA { get; set; } = "AttributeA";

        public string AttributeB { get; set; } = "AttributeB";

        public int AttributeInt { get; set; } = 1;

        public int AttributeInt2 { get; set; } = 2;
    }
}
