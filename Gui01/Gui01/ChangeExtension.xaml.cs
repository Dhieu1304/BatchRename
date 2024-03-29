﻿using System;
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
    /// Interaction logic for ChangeExtension.xaml
    /// </summary>
    public partial class ChangeExtension : Window, INotifyPropertyChanged
    {
        public string NewExt { get; set; }
        public string _status { get; set; }
        public ChangeExtension(string ext)
        {
            InitializeComponent();
            NewExtension.Text = ext;
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OKBtn_Click(object sender, RoutedEventArgs e)
        {
            NewExt = NewExtension.Text;
            DialogResult = true;
        }

        private void NewExtension_TextChanged(object sender, TextChangedEventArgs e)
        {
            NewExt = NewExtension.Text;
            if (NewExt.Length > 0)
            {
                if (!Regex.IsMatch(NewExt, @"^[\w\-. ]+$"))
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
