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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LogFilter.ViewModel
{
    public partial class MainApplicationWindow 
    {
        List<FileDetails> patternsList;
        string fileName;
        public static string defaultFilePath;
        bool fileNameBool;
        public MainApplicationWindow()
        {
            InitializeComponent();

            fileNameBool = false;
                        
            defaultFilePath = Directory.GetCurrentDirectory();                          //Get the current working directory
            defaultFilePath += "/";

            FileViewModel fileViewModel = new FileViewModel();
            patternsList = fileViewModel.loadPatterns();                               // Load the patterns on to the ListView
            this.DataContext = fileViewModel;                                          //Set the data context for MainApplicationWindow.xaml
        }

        //Click Event Handler for 'Destination Folder' button click
        private void DestinationFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            DialogResult dialogResult =  folderBrowserDialog.ShowDialog();
        }

        //Click Event Handler for 'Save' button click
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (fileNameBool)                 //Check if any file has been selected in the list view
            {                                 //If a file is selected then write the contents of the Rich Text Box to it
                TextRange range;

                FileStream fStream;

                range = new TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd);

                fStream = new FileStream(defaultFilePath + fileName, FileMode.Open);

                range.Save(fStream, System.Windows.DataFormats.Text);

                fStream.Close();
            }
            else                            //When no file has been selected in the List View
            {
                System.Windows.MessageBox.Show("No File Selected");
            }


        }

        //Click event handler for 'Save As' button click
        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.Filter = "Text File|*.txt";
            saveFileDialog.Title = "Save Pattern";
            DialogResult dialogResult = saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "" && dialogResult == System.Windows.Forms.DialogResult.OK) //Check if file name has been entered and Selected Option is OK
            {
                System.Windows.MessageBox.Show("Saving contents of the Rich Text Box to " + saveFileDialog.FileName);

                TextRange range;                                  //Write contents of the Rich Text Box to the input file name

                FileStream fStream;

                range = new TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd);

                fStream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);

                range.Save(fStream, System.Windows.DataFormats.Text);

                fStream.Close();
                                                                   
                FileViewModel fileViewModel = new FileViewModel(); //Refresh the MainWindowApplication to show the added file
                patternsList = fileViewModel.loadPatterns();
                this.DataContext = fileViewModel;
            }
        }

        //Click event handler for 'Exit' button click
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        //Click event handler for 'Remove' button click
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (lvContents.SelectedItems.Count < 1)
                System.Windows.MessageBox.Show("No pattern selected!");
            else
            {
                MessageBoxResult result = System.Windows.MessageBox.Show("Are you sure you want to remove the selected pattern(s)?", " Remove Pattern ", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        int totalItems;
                        totalItems = lvContents.SelectedItems.Count;
                        if (totalItems >= 1)                                //Check if multiple files are selected for deleting 
                        {
                            foreach (FileDetails item in lvContents.SelectedItems)
                            {
                                patternsList.Remove(item);
                                item.FileName = defaultFilePath + item.FileName;
                                if (File.Exists(item.FileName))
                                {
                                    System.Windows.MessageBox.Show("Deleting " + item.FileName);
                                    File.Delete(item.FileName);
                                }
                            }
                            FileViewModel fileViewModel = new FileViewModel(); //Refresh datacontext after deleting 
                            patternsList = fileViewModel.loadPatterns();
                            this.DataContext = fileViewModel;
                        }
                        break;
                    case MessageBoxResult.No:
                    case MessageBoxResult.Cancel:
                        break;
                }
            }
            
        }


        //Click event handler for 'Search' button
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            int selectedIndex;
            if (lvContents.SelectedItems.Count == 1)
            {
                selectedIndex = lvContents.Items.IndexOf(lvContents.SelectedItems[0]);
                MessageBoxResult result = System.Windows.MessageBox.Show("Open log file in a document viewer?", "Search Log File", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:

                        string fileName = patternsList[selectedIndex].FileName;

                        PatternView patternView = new PatternView(fileName);
                        patternView.DisplayFileContents(fileName);
                        patternView.Show();
                        //this.Close();

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
            else if (lvContents.SelectedItems.Count > 1)
                System.Windows.MessageBox.Show("Please Select only one pattern!");
            else
                System.Windows.MessageBox.Show("No pattern selected!");
        }

        
        private void Run_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Logs filtered successfully");
        }

        //Click event handler for when a pattern is selected from the List View
        private void lvContents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int selectedIndex;
            if (lvContents.SelectedItems.Count > 0) //Check if more than one patterns have been selected
            {
                selectedIndex = lvContents.Items.IndexOf(lvContents.SelectedItems[0]);

                fileName = patternsList[selectedIndex].FileName;

                displayFile(fileName);
                //task.Start();


            }
        }

        //Helper function to display the contents of the file to the Rich Text Box once a pattern has been selected from the List View
        void displayFile(string fileName)
        {
            fileNameBool = true;
            TextRange range;
            FileStream fStream;
            string filePath = defaultFilePath;
            filePath += fileName;
            if (File.Exists(filePath))
            {
                range = new TextRange(richTB.Document.ContentStart, richTB.Document.ContentEnd);

                fStream = new FileStream(filePath, FileMode.Open);

                range.Load(fStream, System.Windows.DataFormats.Text);

                fStream.Close();
            }
        }

        //Helper function to get the 'file name' from the entire  'file path' string 
        string ReturnFileName(string fullName)
        {
            int index = fullName.LastIndexOf('\\');
            string name = fullName.Substring(index + 1);
            return name;
        }

        //Click event handler for 'Add Existing Pattern' button
        private void Add_Existing_Pattern_Click(object sender, RoutedEventArgs e)
        {
            string fileName;
            System.Windows.Forms.OpenFileDialog openFileDialogAddPattern = new System.Windows.Forms.OpenFileDialog();
            DialogResult dialogResult = openFileDialogAddPattern.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK)
            {
                System.Windows.MessageBox.Show(openFileDialogAddPattern.FileName);
                string src = openFileDialogAddPattern.FileName;

                int index = src.LastIndexOf('\\');
                src = src.Remove(index);

                string dest = defaultFilePath;
                fileName = ReturnFileName(openFileDialogAddPattern.FileName);
                dest = dest + fileName;
                copyFile(fileName, src, dest);


                FileViewModel fileViewModel = new FileViewModel();
                patternsList = fileViewModel.loadPatterns();
                this.DataContext = fileViewModel;
            }
        }

        //Helper function for AddExisting Pattern to copy the file from source to target directory
        public void copyFile(string fileName, string src, string dest)
        {
            string[] filePaths = Directory.GetFiles(src);
            foreach (string filename in filePaths)
            {
                string target = ReturnFileName(filename);
                if (fileName == target)
                {
                    if (!File.Exists(dest))
                    {
                        File.Copy(filename, dest);
                        break;
                    }
                }
            }
        }

        //Click event handler for 'Create New Pattern' button
        private void Create_New_Pattern_Click(Object sender, RoutedEventArgs e)
        {
            CreatePattern cp = new CreatePattern();
            cp.Show();
            this.Close();
        }
    }

}
