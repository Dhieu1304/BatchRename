using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeExtensionRule
{
    public class ChangeExtensionRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "ChangeExtension";
        public IRenameRule Parse(string line)
        {
            string[] tokens = line.Split(new string[] { "ChangeExtension " }, StringSplitOptions.None);
            string newExt = tokens[1].Replace("\"", "");
            IRenameRule rule = new ChangeExtensionRule(newExt);
            return rule;
        }
    }
}
