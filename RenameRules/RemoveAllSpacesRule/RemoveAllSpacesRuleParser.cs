using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveAllSpacesRule
{
    public class RemoveAllSpacesRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "RemoveAllSpaces";
        public IRenameRule Parse(string line)
        {
            IRenameRule rule = new RemoveAllSpacesRule();
            return rule;
        }
    }
}
