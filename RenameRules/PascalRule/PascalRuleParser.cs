using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PascalRule
{
    public class PascalRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "PascalRule";
        public IRenameRule Parse(string line)
        {
            IRenameRule rule = new PascalRule();
            return rule;
        }
    }
}
