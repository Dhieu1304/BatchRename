using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveSpaceSE
{
    public class RemoveSpaceSEParser : IRenameRuleParser
    {
        public static string MagicWord = "RemoveSpaceSE";

        public IRenameRule Parse(string line)
        {
            IRenameRule rule = new RemoveSpaceSE();
            return rule;
        }
    }
}
