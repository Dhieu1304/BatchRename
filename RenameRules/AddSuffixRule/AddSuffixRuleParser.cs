using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddSuffixRule
{
    public class AddSuffixRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "AddSuffix";

        public IRenameRule Parse(string line)
        {
            string[] tokens = line.Split(new string[] { "AddSuffix " }, StringSplitOptions.None);
            string suffix = tokens[1].Replace("\"", "");
            IRenameRule rule = new AddSuffixRule(suffix);
            return rule;
        }
    }
}
