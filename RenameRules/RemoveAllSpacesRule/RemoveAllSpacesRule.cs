using Entity;
using System;

namespace RemoveAllSpacesRule
{
    public class RemoveAllSpacesRule : IRenameRule
    {
        public string Name => "RemoveAllSpacesRule";

        public string Rename(string original)
        {
            string result = original;
            result = result.Replace(" ", "");
            return result;
        }

        public string RenameDir(string original)
        {
            string result = original;
            result = result.Replace(" ", "");
            return result;
        }
    }
}
