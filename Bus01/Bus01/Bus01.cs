using Contract;
using Entity;
using System;
using System.ComponentModel;

namespace Bus01
{
    public class Bus01 : IBus
    {
        public string Name => "Bus01";

        public string Description => "BUS01 - Simple";

        public IData Data { get; set; }

        //public void DependsOn(IData idata)
        //{
        //    _idata = idata;
        //}

        public BindingList<IRenameRule> getAll()
        {
            return Data.getAll();
        }

        public bool Insert(IRenameRule rule)
        {
            return Data.Insert(rule);
        }

        //public bool Save(BindingList<IRenameRule> presets)
        //{
        //    return true;
        //}

        public void startRename(BindingList<IRenameRule> rules, BindingList<string> paths)
        {
            for (int i = 0; i < paths.Count; i++)
            {
                foreach (IRenameRule rule in rules)
                {
                    paths[i] = rule.Rename(paths[i]);
                }
            }
        }
    }
}
