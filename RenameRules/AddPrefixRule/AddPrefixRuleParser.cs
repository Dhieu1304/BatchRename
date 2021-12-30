using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddPrefixRule
{
    public class AddPrefixRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "AddPrefix";
        public IRenameRule Parse(string line)
        {
            string[] tokens = line.Split(new string[] { "AddPrefix " }, StringSplitOptions.None);
            string prefix = tokens[1].Replace("\"", "");
            IRenameRule rule = new AddPrefixRule(prefix);
            return rule;
        }
    }
}
