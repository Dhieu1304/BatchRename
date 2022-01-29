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
    /// Interaction logic for AddCounter.xaml
    /// </summary>
    public partial class AddCounter : Window, INotifyPropertyChanged
    {
        public int _start { get; set; }
        public int _step { get; set; }
        public int _numD { get; set; }
        public string _status1 { get; set; }
        public string _status2 { get; set; }
        public string _status3 { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCounter(int start, int step, int numD)
        {
            InitializeComponent();

            List<int> _numDigit = new List<int>()
            {
                1, 2, 3, 4, 5, 6, 7, 8
            };

            _status1 = start.ToString();
            _status2 = step.ToString();

            startVal.Text = _status1;
            stepVal.Text = _status2;

            numDigit.ItemsSource = _numDigit;
            numDigit.SelectedItem = numD;

            _start = start;
            _step = step;
            _numD = numD;

            _status1 = "";
            _status2 = "";
            _status3 = "";

            DataContext = this;
        }

        private void startVal_TextChanged(object sender, TextChangedEventArgs e)
        {
            string start = startVal.Text;
            if (start.Length > 0)
            {
                if (!Regex.IsMatch(start, @"^\d+$"))
                {
                    _status1 = "Input Only Number";
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

        private void stepVal_TextChanged(object sender, TextChangedEventArgs e)
        {
            string step = stepVal.Text;
            if (step.Length > 0)
            {
                if (!Regex.IsMatch(step, @"^\d+$"))
                {
                    _status2 = "Input Only Number";
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

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            _start = Int32.Parse(startVal.Text);
            _step = Int32.Parse(stepVal.Text);
            _numD = Int32.Parse(numDigit.SelectedItem.ToString());
            if (startVal.Text.Length > _numD || stepVal.Text.Length > _numD)
            {
                _status3 = "Please check your Input!!!";
            }
            else
            {
                DialogResult = true;
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
