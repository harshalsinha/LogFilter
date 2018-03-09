using System;
using System.Collections.Generic;
using System.IO;
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

namespace LogFilter.ViewModel
{
    /// <summary>
    /// Interaction logic for CreatePattern.xaml
    /// </summary>
    public partial class CreatePattern : Window
    {
        public CreatePattern()
        {
            InitializeComponent();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            string filePath = MainApplicationWindow.defaultFilePath;
            MessageBox.Show(filePath);
            string fileName = EnteredFileName.Text;
            MessageBox.Show(fileName);
            filePath += fileName;
            filePath += ".txt";

            TextRange range;

            FileStream fStream;

            range = new TextRange(NewPatternRTB.Document.ContentStart, NewPatternRTB.Document.ContentEnd);

            fStream = new FileStream(filePath, FileMode.Create);

            range.Save(fStream, System.Windows.DataFormats.Text);

            fStream.Close();

            MainApplicationWindow mw = new MainApplicationWindow();
            mw.Show();
            this.Close();
        }

        private void SaveContents(string filePath)
        {
            TextRange range;

            FileStream fStream;

            range = new TextRange(NewPatternRTB.Document.ContentStart, NewPatternRTB.Document.ContentEnd);

            fStream = new FileStream(filePath, FileMode.Open);

            range.Save(fStream, System.Windows.DataFormats.Text);

            fStream.Close();


        }
    }
}
