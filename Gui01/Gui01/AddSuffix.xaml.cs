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
    /// Interaction logic for AddSuffix.xaml
    /// </summary>
    public partial class AddSuffix : Window, INotifyPropertyChanged
    {
        public String newStr { get; set; }
        public string _status { get; set; }
        public AddSuffix(string SuStr)
        {
            InitializeComponent();
            SufixString.Text = SuStr;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            newStr = SufixString.Text;
            DialogResult = true;
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SufixString_TextChanged(object sender, TextChangedEventArgs e)
        {
            newStr = SufixString.Text;
            if (newStr.Length > 0)
            {
                if (!Regex.IsMatch(newStr, @"^[\w\-. ]+$"))
                {
                    _status = "Incorrect file name (no special characters)";
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
            _status = "";
            OKBtn.IsEnabled = true;
        }
    }
}
