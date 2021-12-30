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
    /// Interaction logic for ChangeExtension.xaml
    /// </summary>
    public partial class ChangeExtension : Window
    {
        public string NewExt { get; set; }
        public ChangeExtension(string ext)
        {
            InitializeComponent();
            NewExtension.Text = ext;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            NewExt = NewExtension.Text;
            DialogResult = true;
        }
    }
}
