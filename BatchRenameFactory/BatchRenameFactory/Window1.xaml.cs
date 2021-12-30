using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BatchRenameFactory
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        UserControl mainUc;
        public Window1(UserControl uc)
        {
            //InitializeComponent();
            this.LoadViewFromUri("/BatchRenameFactory;component/window1.xaml");
            mainUc = uc;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            mainGrid.Children.Add(mainUc);
        }
    }
}
