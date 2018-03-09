using LogFilter.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFilter.Model
{
    class FilesDataContext
    {
        //Function to read the files in the current directory and return a List containing the pattern names
        public List<string> GetPatternFiles()
        {
            List<string> list = new List<string>();
            string path = MainApplicationWindow.defaultFilePath ;
            DirectoryInfo directory = new DirectoryInfo(path);
            FileInfo[] files = directory.GetFiles("*.txt");
            foreach (FileInfo f in files)
            {
                list.Add(f.Name);
            }
            return list;
        }
    }
}
