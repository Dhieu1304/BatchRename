using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllUpperRule
{
    public class AllUpperRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "AllUpper";

        public IRenameRule Parse(string line)
        {
            IRenameRule rule = new AllUpperRule();
            return rule;
        }
    }
}
