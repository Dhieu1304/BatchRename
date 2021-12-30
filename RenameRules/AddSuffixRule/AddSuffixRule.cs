using Entity;
using System;

namespace AddSuffixRule
{
    public class AddSuffixRule : IRenameRule
    {
        public string Name => "AddSuffixRule";

        public string Suffix { get; set; }
        public AddSuffixRule(string suffix)
        {
            Suffix = suffix;
        }
        public string Rename(string original)
        {
            string result = "";

            int dotIndex = original.LastIndexOf(".");
            string name = original.Substring(0, dotIndex);
            string ext = original.Substring(dotIndex + 1, original.Length - dotIndex - 1);

            result = $"{name}{Suffix}.{ext}";
            return result;
        }

        public string RenameDir(string original)
        {
            string result = "";
            result = $"{original}{Suffix}";
            return result;
        }
    }
}
