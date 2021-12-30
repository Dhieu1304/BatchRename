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

namespace Gui01
{
    /// <summary>
    /// Interaction logic for AddSuffix.xaml
    /// </summary>
    public partial class AddSuffix : Window
    {
        public String newStr { get; set; }
        public AddSuffix(string SuStr)
        {
            InitializeComponent();
            SufixString.Text = SuStr;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            newStr = SufixString.Text;
            DialogResult = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
