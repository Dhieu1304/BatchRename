using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCounter
{
    public class AddCounterRuleParser : IRenameRuleParser
    {
        public static string MagicWord = "AddCounter";

        public IRenameRule Parse(string line)
        {
            string[] tokens = line.Split(new string[] { "AddCounter " }, StringSplitOptions.None);
            string counter = tokens[1].Replace("\"", "");
            IRenameRule rule = new AddCounterRule(counter);
            return rule;
        }
    }
}
