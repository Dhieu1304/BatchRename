using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IBus
    {
        string Name { get; }
        string Description { get; }
        IData Data { get; set; }
        BindingList<IRenameRule> getAll();
        void startRename(BindingList<IRenameRule> rules, BindingList<string> paths);
        bool Insert(IRenameRule rule);

        //bool Save(BindingList<IRenameRule> rules);
        //void DependsOn(IData idata);
    }
}
