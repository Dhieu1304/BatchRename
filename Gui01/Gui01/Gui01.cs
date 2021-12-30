using Contract;
using System;
using System.Windows.Controls;

namespace Gui01
{
    public class Gui01 : IUI
    {
        //private IBus _bus;
        public string Name => "Gui01";

        public string Description => "GUI01 - GiaoDien1";

        public IBus Bus { get; set; }

        //public void DependsOn(IBus ibus)
        //{
        //    _bus = ibus;
        //}

        public UserControl Show()
        {
            return new UserControl1(Bus);
        }
    }
}
