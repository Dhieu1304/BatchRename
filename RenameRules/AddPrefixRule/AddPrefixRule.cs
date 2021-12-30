using Entity;
using System;

namespace AddPrefixRule
{
    public class AddPrefixRule : IRenameRule
    {        
        public string Name => "AddPrefixRule";

        public string Prefix { get; set; }
        public AddPrefixRule(string prefix)
        {
            Prefix = prefix;
        }
        public string Rename(string original)
        {
            string result = "";
            result = $"{Prefix}{original}";
            return result;
        }

        public string RenameDir(string original)
        {
            string result = "";
            result = $"{Prefix}{original}";
            return result;
        }
    }
}
