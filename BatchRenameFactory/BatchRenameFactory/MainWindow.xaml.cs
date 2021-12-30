using Contract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BatchRenameFactory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var iui = new BindingList<IUI>();
            var ibus = new BindingList<IBus>();
            var idata = new BindingList<IData>();

            var exeFolder = AppDomain.CurrentDomain.BaseDirectory;
            var fis = new DirectoryInfo(exeFolder).GetFiles("*.dll");


            foreach (var fi in fis)
            {
                var assembly = Assembly.LoadFile(fi.FullName);
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                    if (type.IsClass)
                    {
                        if (typeof(IUI).IsAssignableFrom(type))
                        {
                            iui.Add(Activator.CreateInstance(type) as IUI);
                        }
                        else if (typeof(IBus).IsAssignableFrom(type))
                        {
                            ibus.Add(Activator.CreateInstance(type) as IBus);
                        }
                        else if (typeof(IData).IsAssignableFrom(type))
                        {
                            idata.Add(Activator.CreateInstance(type) as IData);
                        }
                    }
                }
            }

            uiCombobox.ItemsSource = iui;
            busCombobox.ItemsSource = ibus;
            dataCombobox.ItemsSource = idata;

            uiCombobox.SelectedIndex = 0;
            busCombobox.SelectedIndex = 0;
            dataCombobox.SelectedIndex = 0;
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            var ui = uiCombobox.SelectedItem as IUI;
            var bus = busCombobox.SelectedItem as IBus;
            var data = dataCombobox.SelectedItem as IData;

            ui.Bus = bus;
            bus.Data = data;
            //bus.DependsOn(data);
            //ui.DependsOn(bus);

            var screen = new Window1(ui.Show()); //ui.Show()
            screen.Show();
            this.Close();
        }
    }
}
