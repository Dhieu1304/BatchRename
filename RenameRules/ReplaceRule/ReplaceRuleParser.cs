using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReplaceRule
{
    public class ReplaceRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "Replace";
        public IRenameRule Parse(string line)
        {
            string[] tokens = line.Split(new string[] { "Replace " }, StringSplitOptions.None);
            string[] part = tokens[1].Split(new string[] { " => " }, StringSplitOptions.None);

            string needle = part[0].Replace("\"", "");
            string replacement = part[1].Replace("\"", "");

            IRenameRule rule = new ReplaceRule(needle, replacement);
            return rule;
        }
    }
}
