using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTaskApp.Services
{
    public class FileSystemVisitor
    {
        public string fileName { get; set; }
        public string directoryName { get; set; }



        public FileSystemVisitor()
        {

        }



        public FileSystemVisitor(string directoryName, string fileName)
        {
            this.fileName = fileName;
            this.directoryName = directoryName;

        }

        public List<string> SearchDirectory(List<string> directories)
        {
            List<string> result = directories.Where(x => x.Contains(directoryName)).ToList();
            return result;

        }
        public List<string> SearchFiles(List<string> files)
        {
            List<string> result = files.Where(x => x.Contains(fileName)).ToList();
            return result;

        }

        public IEnumerable<string> FindFiles(string path)
        {
            string[] files = System.IO.Directory.GetFiles(path);
            foreach (string file in files)
            {
                yield return file;
            }
        }

        public IEnumerable<string> FindFolders(string path)
        {
            string[] directories = System.IO.Directory.GetDirectories(path);
            foreach (string directory in directories)
            {
                yield return directory;
            }
        }

        private bool isPartOfName(string s)
        {
            return directoryName.Contains(s);
        }

    }
}
