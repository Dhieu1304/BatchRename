using Entity;
using System;

namespace RemoveSpaceSE
{
    public class RemoveSpaceSE : IRenameRule
    {
        public string Name => "RemoveSpaceSE";

        public string Rename(string original)
        {
            string result = "";

            int dotIndex = original.LastIndexOf(".");
            string name = original.Substring(0, dotIndex);
            string ext = original.Substring(dotIndex + 1, original.Length - dotIndex - 1);

            result = $"{name.Trim()}.{ext}";
            return result;
        }

        public string RenameDir(string original)
        {
            string result = original.Trim();
            return result;
        }
    }
}
