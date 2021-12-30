using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllLowerRule
{
    public class AllLowerRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "AllLower";

        public IRenameRule Parse(string line)
        {
            IRenameRule rule = new AllLowerRule();
            return rule;
        }
    }
}
