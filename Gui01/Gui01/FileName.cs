using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gui01
{
    class FileName : INotifyPropertyChanged
    {
        public int id { get; set; }
        public string oldName { get; set; }
        public string filePath { get; set; }
        public string newName { get; set; }
        public string err { get; set; }
        public int type { get; set; }

        public string toStr()
        {
            string result = $"{id}|{oldName}|{filePath}|{newName}|{err}|{type}";
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void updateListviewUI()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("newName"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("filePath"));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("err"));
        }
    }
}
