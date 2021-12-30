using Entity;
using System;

namespace AllLowerRule
{
    public class AllLowerRule : IRenameRule
    {
        public string Name => "AllLowerRule";

        public string Rename(string original)
        {
            string result = original.ToLower();
            return result;
        }

        public string RenameDir(string original)
        {
            string result = original.ToLower();
            return result;
        }
    }
}
