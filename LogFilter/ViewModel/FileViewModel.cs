using LogFilter.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFilter.ViewModel
{
    class FileViewModel:FileDetails
    {
        List<FileDetails> patternsList;

        //Property for setting the data context of the ListView in MainApplicationWindow.xaml
        public List<FileDetails> PatternsList
        {
            get;
            set;
        }

        //Function to create Pattern objects and add to a List of Pattern Objects which will be bound to the ListView
        public List<FileDetails> loadPatterns()
        {
            patternsList = new List<FileDetails>();
            FilesDataContext filesDataContext = new FilesDataContext();
            var items = filesDataContext.GetPatternFiles();
            foreach (string s in items)
            {
                patternsList.Add(new FileDetails { FileName = s });
            }
            PatternsList = patternsList;
            return patternsList;
        }
    }
}
