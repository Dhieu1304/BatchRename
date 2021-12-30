using Entity;
using System;

namespace ChangeExtensionRule
{
    public class ChangeExtensionRule : IRenameRule
    {
        public string Name => "ChangeExtensionRule";
        public string NewExt { get; set; }
        public ChangeExtensionRule(string newExt)
        {
            NewExt = newExt;
        }
        public string Rename(string original)
        {
            string result = "";

            int dotIndex = original.LastIndexOf(".");
            string name = original.Substring(0, dotIndex);

            result = $"{name}.{NewExt}";
            return result;
        }

        public string RenameDir(string original)
        {
            //Do Nothing
            return original;
        }
    }
}
