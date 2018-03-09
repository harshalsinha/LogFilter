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

namespace LogFilter.ViewModel
{
    /// <summary>
    /// Interaction logic for PatternView.xaml
    /// </summary>
    public partial class PatternView : Window
    {
        public PatternView(string fileName)
        {
            InitializeComponent();
            DisplayFileContents(fileName);
        }
        public void DisplayFileContents(string fileName)
        {
            Paragraph paragraph = new Paragraph();

            fileName = MainApplicationWindow.defaultFilePath + fileName;
            paragraph.Inlines.Add(System.IO.File.ReadAllText(fileName));

            FlowDocument document = new FlowDocument(paragraph);

            FlowDocReader.Document = document;
        }

        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            //MainApplicationWindow mw = new MainApplicationWindow();
            //mw.Show();
            this.Close();
        }
    }
}
