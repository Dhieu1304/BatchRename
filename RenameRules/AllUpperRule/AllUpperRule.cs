using Entity;
using System;

namespace AllUpperRule
{
    public class AllUpperRule : IRenameRule
    {
        public string Name => "AllUpperRule";

        public string Rename(string original)
        {
            string result = original.ToUpper();
            return result;
        }

        public string RenameDir(string original)
        {
            string result = original.ToUpper();
            return result;
        }
    }
}
