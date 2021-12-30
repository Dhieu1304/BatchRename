using AddPrefixRule;
using AddSuffixRule;
using AllLowerRule;
using AllUpperRule;
using ChangeExtensionRule;
using Contract;
using Entity;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using PascalRule;
using RemoveAllSpacesRule;
using RemoveSpaceSE;
using ReplaceRule;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Gui01
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        IBus _bus = null;
        BindingList<FileName> _fileNames = new BindingList<FileName>(); 
        BindingList<string> _pros = new BindingList<string>();

        public UserControl1(IBus ibus)
        {
            InitializeComponent();
            _bus = ibus;
            Loaded += UserControl1_Load;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (_pros.Count > 0 && _fileNames.Count > 0)
            {
                StreamWriter sw = new StreamWriter("AutoSave.txt");
                sw.WriteLine(_pros.Count);
                for (int i = 0; i < _pros.Count; i++)
                {
                    sw.WriteLine(_pros[i]);
                }
                sw.WriteLine(_fileNames.Count);
                for (int i = 0; i < _fileNames.Count; i++)
                {
                    sw.WriteLine(_fileNames[i].toStr());
                }
                sw.Close();
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            int index = comboBoxToChooseRule.SelectedIndex;
            string s = "";
            switch (index)
            {
                case 0:
                    string PreStr = "";
                    var AddPrefix_Screen = new AddPrefix(PreStr);
                    if (AddPrefix_Screen.ShowDialog() == true)
                    {
                        s += $"AddPrefix \"{AddPrefix_Screen.newStr}\"";
                        _pros.Add(s);
                    }
                    break;
                case 1:
                    string SuStr = "";
                    var AddSuffix_Screen = new AddSuffix(SuStr);
                    if (AddSuffix_Screen.ShowDialog() == true)
                    {
                        s += $"AddSuffix \"{AddSuffix_Screen.newStr}\"";
                        _pros.Add(s);
                    }
                    break;
                case 2:
                    s += "RemoveSpaceSE";
                    _pros.Add(s);
                    break;
                case 3:
                    s += "RemoveAllSpaces";
                    _pros.Add(s);
                    break;
                case 4:
                    string From = "", To = "";
                    var Replace_Screen = new Replace(From, To);
                    if (Replace_Screen.ShowDialog() == true)
                    {
                        s += $"Replace \"{Replace_Screen.ReFrom}\" => \"{Replace_Screen.ReTo}\"";
                        _pros.Add(s);
                    }
                    break;
                case 5:
                    s += "AllLower";
                    _pros.Add(s);
                    break;
                case 6:
                    s += "AllUpper";
                    _pros.Add(s);
                    break;
                case 7:
                    s += "PascalRule";
                    _pros.Add(s);
                    break;
                case 8:
                    var ChangeExt = new ChangeExtension(String.Empty);
                    if (ChangeExt.ShowDialog() == true)
                    {
                        s += $"ChangeExtension \"{ChangeExt.NewExt}\"";
                        _pros.Add(s);
                    }
                    break;
                case 9:

                    break;
                default:
                    break;
            }
        }

        private void SwapListRules(int start, int end)
        {
            var temp = _pros[start];
            _pros[start] = _pros[end];
            _pros[end] = temp;
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            var index = listRules.SelectedIndex;
            if (index > 0 && index < _pros.Count)
            {
                SwapListRules(index - 1, index);
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            var index = listRules.SelectedIndex;
            if (index >= 0 && index < _pros.Count - 1)
            {
                SwapListRules(index, index + 1);
            }
        }

        private void UpMax_Click(object sender, RoutedEventArgs e)
        {
            var index = listRules.SelectedIndex;
            if (index > 0 && index < _pros.Count)
            {
                string temp = _pros[index];

                for (int i = index; i > 0; i--)
                {
                    _pros[i] = _pros[i - 1];
                }

                _pros[0] = temp;
            }
        }

        private void DownMax_Click(object sender, RoutedEventArgs e)
        {
            var index = listRules.SelectedIndex;
            if (index >= 0 && index < _pros.Count - 1)
            {
                string temp = _pros[index];

                for (int i = index; i < _pros.Count - 1; i++)
                {
                    _pros[i] = _pros[i + 1];
                }

                _pros[_pros.Count - 1] = temp;
            }
        }

        private void startBatch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl1_Load(Object sender, EventArgs e)
        {
            Loaded -= UserControl1_Load;

            List<string> _listRule = new List<string>()
            {
                "AddPrefixRule", //rule 1
                "AddSuffixRule", //rule 2
                "RemoveSpacesStartEnd", //rule 3
                "RemoveAllSpaces", //rule 4
                "ReplaceRule", //rule 5
                "AllLowerRule", //rule 6
                "AllUpperRule", //rule 7
                "PascalRule", //rule 8
                "ChangeExtensionRule", //rule 9
                "AddCounter", //rule 10
            };

            comboBoxToChooseRule.ItemsSource = _listRule;
            comboBoxToChooseRule.SelectedIndex = 0;

            listRules.ItemsSource = _pros;
        }

        private void RemoveAll_Click(object sender, RoutedEventArgs e)
        {
            _fileNames.Clear();
        }

        private void LoadFile_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                int tmpID = _fileNames.Count;
                foreach (string filename in openFileDialog.FileNames)
                {
                    var newItem = new FileName()
                    {
                        id = tmpID + 1,
                        filePath = filename,
                        oldName = System.IO.Path.GetFileName(filename),
                        newName = "",
                        err = "",
                        type = 1
                    };

                    if (!checkDuplicated(newItem))
                    {
                        _fileNames.Add(newItem);
                        tmpID++;
                    }
                }
            }

            listviewOfFiles.ItemsSource = _fileNames;
        }

        private void LoadAllFile_Click(object sender, RoutedEventArgs e)
        {
            var screen = new CommonOpenFileDialog();
            screen.IsFolderPicker = true;
            screen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (screen.ShowDialog() == CommonFileDialogResult.Ok)
            {
                int tmpID = _fileNames.Count;

                string[] _tmpFiles = Directory.GetFiles(screen.FileName); //get all folders in directory
                foreach (var newFile in _tmpFiles)  //add to data list
                {
                    var newItem = new FileName()
                    {
                        id = tmpID + 1,
                        filePath = newFile,
                        oldName = System.IO.Path.GetFileName(newFile),
                        newName = "",
                        err = "",
                        type = 1
                    };

                    if (!checkDuplicated(newItem))
                    {
                        _fileNames.Add(newItem);
                        tmpID++;
                    }                    
                }

                listviewOfFiles.ItemsSource = _fileNames; //update to UI of listview
            }
        }

        private void LoadFolder_Click(object sender, RoutedEventArgs e)
        {
            var screen = new CommonOpenFileDialog();
            screen.IsFolderPicker = true;
            screen.Multiselect = true;
            screen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (screen.ShowDialog() == CommonFileDialogResult.Ok)
            {
                int tmpID = _fileNames.Count;
                var _tmpFiles = screen.FileNames;

                foreach (var newFile in _tmpFiles)  //add to data list
                {
                    var newItem = new FileName()
                    {
                        id = tmpID + 1,
                        filePath = newFile,
                        oldName = System.IO.Path.GetFileName(newFile),
                        newName = "",
                        err = "",
                        type = 0
                    };

                    if (!checkDuplicated(newItem))
                    {
                        _fileNames.Add(newItem);
                        tmpID++;
                    }
                }

                listviewOfFiles.ItemsSource = _fileNames; //update to UI of listview
            }
        }

        private void LoadAllFolder_Click(object sender, RoutedEventArgs e)
        {
            var screen = new CommonOpenFileDialog();
            screen.IsFolderPicker = true;
            screen.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (screen.ShowDialog() == CommonFileDialogResult.Ok)
            {
                int tmpID = _fileNames.Count;

                string[] _tmpFolders = Directory.GetDirectories(screen.FileName);
                foreach (var newFolder in _tmpFolders)
                {
                    var newItem = new FileName()
                    {
                        id = tmpID + 1,
                        filePath = newFolder,
                        oldName = System.IO.Path.GetFileName(newFolder),
                        newName = "",
                        err = "",
                        type = 0
                    };

                    if (!checkDuplicated(newItem))
                    {
                        _fileNames.Add(newItem);
                        tmpID++;
                    }
                }

                listviewOfFiles.ItemsSource = _fileNames;
            }
        }

        public class RuleParserFactory
        {
            private Dictionary<string, IRenameRuleParser> _prototypes = null;

            public RuleParserFactory()
            {
                _prototypes = new Dictionary<string, IRenameRuleParser>()
                {
                    {AddSuffixRuleParser.MagicWord, new AddSuffixRuleParser() },
                    {ReplaceRuleParser.MagicWord, new ReplaceRuleParser() },
                    {AllLowerRuleParser.MagicWord, new AllLowerRuleParser() },
                    {RemoveSpaceSEParser.MagicWord, new RemoveSpaceSEParser() },
                    {AddPrefixRuleParser.MagicWord, new AddPrefixRuleParser() },
                    {AllUpperRuleParser.MagicWord, new AllUpperRuleParser() },
                    {RemoveAllSpacesRuleParser.MagicWord, new RemoveAllSpacesRuleParser() },
                    {PascalRuleParser.MagicWord, new PascalRuleParser() },
                    {ChangeExtensionRuleParser.MagicWord, new ChangeExtensionRuleParser() },
                };
            }
            public IRenameRuleParser Create(string choice)
            {
                IRenameRuleParser parser = _prototypes[choice];

                return parser;
            }
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            RuleParserFactory factory = new RuleParserFactory();
            List<IRenameRule> rules = new List<IRenameRule>();

            foreach (var f in _fileNames)
            {
                for (int i = 0; i < _pros.Count; i++)
                {
                    string line = _pros[i];
                    int firstSpaceIndex = line.IndexOf(" ");
                    if (firstSpaceIndex == -1)
                    {
                        firstSpaceIndex = line.Length;
                    }
                    string firstWord = line.Substring(0, firstSpaceIndex);

                    IRenameRuleParser parser = factory.Create(firstWord);
                    IRenameRule rule = parser.Parse(line);
                    rules.Add(rule);
                }

                string newname = f.oldName;

                if (f.type == 1)
                {
                    foreach (var rule in rules)
                    {
                        newname = rule.Rename(newname);
                    }
                }
                else
                {
                    foreach (var rule in rules)
                    {
                        newname = rule.RenameDir(newname);
                    }
                }
                
                f.newName = newname;
                rules.Clear();
                /*f.newName = f.oldName + "_1";
                string temp = f.filePath;
                string newN = temp.Substring(0, temp.LastIndexOf(@"\") + 1) + f.newName;
                if (f.type == 1)
                {
                    //File.Move(f.filePath, newN); //này của phần start batch
                }
                else // type == 0 : Directories
                {
                    //Directory.Move(f.filePath, newN); //này của phần start batch
                }*/
            }
        }

        private Boolean checkDuplicated(FileName f)
        {
            for (int i = 0; i < _fileNames.Count; i++)
            {
                if (string.Equals(f.filePath, _fileNames[i].filePath) && string.Equals(f.oldName, _fileNames[i].oldName))
                {
                    return true;
                }
            }
            return false;
        }

        private void SavePreset_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save an Txt File";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string List2String = "";
                foreach (string s in _pros)
                {
                    List2String += s + "\n";
                }

                File.WriteAllText(saveFileDialog1.FileName, List2String);
            }
        }

        private void LoadPreset_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();
                BindingList<string> listPresetLoaded = new BindingList<string>();
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine();
                        listPresetLoaded.Add(line);
                    }
                }
                _pros = listPresetLoaded;
                listRules.ItemsSource = _pros;
            }
        }

        private void RemovePreset_Click(object sender, RoutedEventArgs e)
        {
            _pros.Clear();
        }

        private void deleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = listRules.SelectedIndex;
            if (index >= 0 && index < _pros.Count)
            {
                _pros.RemoveAt(index);
            }
        }

        private void editMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var index = listRules.SelectedIndex;
            string line = _pros[index];
            int firstSpaceIndex = line.IndexOf(" ");
            if (firstSpaceIndex == -1)
            {
                firstSpaceIndex = line.Length;
            }
            string firstWord = line.Substring(0, firstSpaceIndex);

            string[] tokens;
            string OldStr = "", NewStr = "";
            switch (firstWord)
            {
                case "AddPrefix":
                    tokens = line.Split(new string[] { " " }, StringSplitOptions.None);
                    OldStr = tokens[1].Replace("\"", "");

                    var AddPrefix_Screen = new AddPrefix(OldStr);
                    if (AddPrefix_Screen.ShowDialog() == true)
                    {
                        NewStr += $"AddPrefix \"{AddPrefix_Screen.newStr}\"";
                        _pros[index] = NewStr;
                    }

                    break;
                case "AddSuffix":
                    tokens = line.Split(new string[] { " " }, StringSplitOptions.None);
                    OldStr = tokens[1].Replace("\"", "");

                    var AddSuffix_Screen = new AddSuffix(OldStr);
                    if (AddSuffix_Screen.ShowDialog() == true)
                    {
                        NewStr += $"AddSuffix \"{AddSuffix_Screen.newStr}\"";
                        _pros[index] = NewStr;
                    }

                    break;
                case "Replace":
                    tokens = line.Split(new string[] { " " }, StringSplitOptions.None);
                    string fromStr = tokens[1].Replace("\"", "");
                    string toStr = tokens[3].Replace("\"", "");
                    var Replace_Screen = new Replace(fromStr, toStr);

                    if (Replace_Screen.ShowDialog() == true)
                    {
                        NewStr += $"Replace \"{Replace_Screen.ReFrom}\" => \"{Replace_Screen.ReTo}\"";
                        _pros[index] = NewStr;
                    }

                    break;
                case "AllLower":
                    MessageBox.Show("AllLower can not edit!", "Message");
                    break;
                case "RemoveSpaceSE":
                    MessageBox.Show("RemoveSpaceStartEnd can not edit!", "Message");
                    break;
                case "AllUpper":
                    MessageBox.Show("AllUpper can not edit!", "Message");
                    break;
                case "RemoveAllSpaces":
                    MessageBox.Show("RemoveAllSpaces can not edit!", "Message");
                    break;
                case "PascalRule":
                    MessageBox.Show("PascalRule can not edit!", "Message");
                    break;
                case "ChangeExtension":
                    tokens = line.Split(new string[] { " " }, StringSplitOptions.None);
                    OldStr = tokens[1].Replace("\"", "");

                    var ChangeExt_Screen = new ChangeExtension(OldStr);
                    if (ChangeExt_Screen.ShowDialog() == true)
                    {
                        NewStr += $"ChangeExtension \"{ChangeExt_Screen.NewExt}\"";
                        _pros[index] = NewStr;
                    }

                    break;
                default:
                    break;
            }
        }

        private void deleteFileItem_Click(object sender, RoutedEventArgs e)
        {
            var index = listviewOfFiles.SelectedIndex;
            if (index >= 0 && index < _fileNames.Count)
            {
                _fileNames.RemoveAt(index);
            }

            for (int i = index; i < _fileNames.Count; i++)
            {
                _fileNames[i].id--;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            //save lasted preset
            StreamWriter sw = new StreamWriter("LastedPreset.txt");
            sw.WriteLine(_pros.Count);
            for (int i = 0; i < _pros.Count; i++)
            {
                sw.WriteLine(_pros[i]);
            }
            sw.Close();

            var myWindow = Window.GetWindow(this);
            myWindow.Close();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Project 1: BatchRename - Lập trình Windows\n\nNguyễn Đình Hiệu - 19120512\n\nGVHD: Trần Duy Quang", "BatchRename - About us");
        }

        private void SaveProject_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save an Txt File";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                string List2String = "" + _pros.Count + "\n";
                foreach (string s in _pros)
                {
                    List2String += s + "\n";
                }
                List2String += _fileNames.Count + "\n";
                foreach (FileName f in _fileNames)
                {
                    List2String += f.toStr() + "\n";
                }

                File.WriteAllText(saveFileDialog1.FileName, List2String);
            }
        }

        private void LoadProject_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                var fileStream = openFileDialog.OpenFile();

                _pros.Clear();
                _fileNames.Clear();

                StreamReader sr = new StreamReader(fileStream);
                string num = sr.ReadLine();
                for (int i = 0; i < Int32.Parse(num); i++)
                {
                    string temp = sr.ReadLine();
                    _pros.Add(temp);
                }
                num = sr.ReadLine();
                for (int i = 0; i < Int32.Parse(num); i++)
                {
                    string line = sr.ReadLine();
                    string[] tokens = line.Split(new string[] { "|" }, StringSplitOptions.None);
                    var newItem = new FileName()
                    {
                        id = Int32.Parse(tokens[0]),
                        oldName = tokens[1],
                        filePath = tokens[2],
                        newName = tokens[3],
                        err = tokens[4],
                        type = Int32.Parse(tokens[5])
                    };
                    _fileNames.Add(newItem);
                }
                sr.Close();
                listRules.ItemsSource = _pros;
                listviewOfFiles.ItemsSource = _fileNames;
            }
        }

        private void LoadLasted_Click(object sender, RoutedEventArgs e)
        {
            _pros.Clear();
            _fileNames.Clear();

            StreamReader sr = new StreamReader("AutoSave.txt");
            string num = sr.ReadLine();
            for (int i = 0; i < Int32.Parse(num); i++)
            {
                string temp = sr.ReadLine();
                _pros.Add(temp);
            }
            num = sr.ReadLine();
            for (int i = 0; i < Int32.Parse(num); i++)
            {
                string line = sr.ReadLine();
                string[] tokens = line.Split(new string[] { "|" }, StringSplitOptions.None);
                var newItem = new FileName()
                {
                    id = Int32.Parse(tokens[0]),
                    oldName = tokens[1],
                    filePath = tokens[2],
                    newName = tokens[3],
                    err = tokens[4],
                    type = Int32.Parse(tokens[5])
                };
                _fileNames.Add(newItem);
            }
            sr.Close();
            listRules.ItemsSource = _pros;
            listviewOfFiles.ItemsSource = _fileNames;
        }

        private void LoadLastedPreset_Click(object sender, RoutedEventArgs e)
        {
            _pros.Clear();
            StreamReader sr = new StreamReader("LastedPreset.txt");
            string num = sr.ReadLine();
            for (int i = 0; i < Int32.Parse(num); i++)
            {
                string temp = sr.ReadLine();
                _pros.Add(temp);
            }
            listRules.ItemsSource = _pros;
        }
    }
}
