using System;
using System.Windows.Controls;

namespace Contract
{
    public interface IUI
    {
        string Name { get; }
        string Description { get; }
        //UserControl MainScreen { get; }
        IBus Bus { get; set; }
        UserControl Show();

        //void DependsOn(IBus ibus);
    }
}
