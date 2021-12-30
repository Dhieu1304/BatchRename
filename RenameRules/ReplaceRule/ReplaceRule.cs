using Entity;
using System;

namespace ReplaceRule
{
    public class ReplaceRule : IRenameRule
    {
        public string Needles { get; set; }
        public string Replacer { get; set; }
        public string Name => "ReplaceRule";
        public ReplaceRule(string needles, string replacer)
        {
            this.Needles = needles;
            this.Replacer = replacer;
        }

        public string Rename(string original)
        {
            string result = "";

            int dotIndex = original.LastIndexOf(".");
            string name = original.Substring(0, dotIndex);
            string ext = original.Substring(dotIndex + 1, original.Length - dotIndex - 1);

            name = name.Replace(Needles, Replacer);
            result = $"{name}.{ext}";

            return result;
        }

        public string RenameDir(string original)
        {
            string result = original.Replace(Needles, Replacer);
            return result;
        }
    }
}
