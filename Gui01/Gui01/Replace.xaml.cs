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
    /// Interaction logic for Replace.xaml
    /// </summary>
    public partial class Replace : Window
    {
        public string ReFrom { get; set; }
        public string ReTo { get; set; }
        public Replace(string from, string to)
        {
            InitializeComponent();
            ReplaceFrom.Text = from;
            ReplaceTo.Text = to;
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            ReFrom = ReplaceFrom.Text;
            ReTo = ReplaceTo.Text;
            DialogResult = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
