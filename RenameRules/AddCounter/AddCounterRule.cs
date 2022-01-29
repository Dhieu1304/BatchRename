using Entity;
using System;

namespace AddCounter
{
    public class AddCounterRule : IRenameRule
    {
        public string Name => "AddCounter";

        public string _counter { get; set; }
        public AddCounterRule(string counter)
        {
            _counter = counter;
        }

        public string Rename(string original)
        {
            string result = "";

            int dotIndex = original.LastIndexOf(".");
            string name = original.Substring(0, dotIndex);
            string ext = original.Substring(dotIndex + 1, original.Length - dotIndex - 1);

            result = $"{name}{_counter}.{ext}";
            return result;
        }

        public string RenameDir(string original)
        {
            string result = "";
            result = $"{original}{_counter}";
            return result;
        }
    }
}
