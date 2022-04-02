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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace TextFileParser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FilePath { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            FilePath = string.Empty;
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var extension = System.IO.Path.GetExtension(openFileDialog.FileName);
                if (extension != ".txt")
                {
                    MessageBox.Show("Not a text file!");
                    return;
                }
                FilePath = openFileDialog.FileName;
                PathText.Text = openFileDialog.FileName;
            }
        }

        private void Button_Summarize_Click(object sender, RoutedEventArgs e)
        {
            if (FilePath == string.Empty)
            {
                MessageBox.Show("File path empty!");
                return;
            }
            TextFileProcessor textFile = new TextFileProcessor(FilePath);
            SummaryText.Text = textFile.GetSummary();
        }
    }
}
