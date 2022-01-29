using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Replace : Window, INotifyPropertyChanged
    {
        public string ReFrom { get; set; }
        public string ReTo { get; set; }
        public string _status1 { get; set; }
        public string _status2 { get; set; }
        public Replace(string from, string to)
        {
            InitializeComponent();
            ReplaceFrom.Text = from;
            ReplaceTo.Text = to;
            _status1 = "";
            _status2 = "";
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        private void ReplaceFrom_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReFrom = ReplaceFrom.Text;
            if (ReFrom.Length > 0)
            {
                if (!Regex.IsMatch(ReFrom, @"^[\w\-. ]+$"))
                {
                    _status1 = "Incorrect file name (no special characters)";
                    OKBtn.IsEnabled = false;
                }
                else
                {
                    OkOk();
                }
            }
            else
            {
                OkOk();
            }
        }
        private void OkOk()
        {
            _status1 = "";
            checkBtnOk();
        }

        private void checkBtnOk()
        {
            if (_status1.Length < 2 && _status2.Length < 2)
            {
                OKBtn.IsEnabled = true;
            }
            else
            {
                OKBtn.IsEnabled = false;
            }
        }

        private void ReplaceTo_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReTo = ReplaceTo.Text;
            if (ReTo.Length > 0)
            {
                if (!Regex.IsMatch(ReTo, @"^[\w\-. ]+$"))
                {
                    _status2 = "Incorrect file name (no special characters)";
                    OKBtn.IsEnabled = false;
                }
                else
                {
                    OkOk1();
                }
            }
            else
            {
                OkOk1();
            }
        }
        private void OkOk1()
        {
            _status2 = "";
            checkBtnOk();
        }
    }
}
