using Contract;
using Entity;
using System;
using System.ComponentModel;

namespace Data01
{
    public class Data01 : IData
    {
        public string Name => "Data01";

        public string Description => "Data01 - Text";

        public BindingList<IRenameRule> getAll()
        {
            //TODO
            BindingList<IRenameRule> result = null;
            return result;
        }

        public bool Insert(IRenameRule rule)
        {
            //TODO
            return true;
        }
    }
}
