using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IData
    {
        string Name { get; }
        string Description { get; }
        BindingList<IRenameRule> getAll();
        bool Insert(IRenameRule rule);
 
        //bool Save(BindingList<IRenameRule> presets);
    }
}
