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
using WpfTaskApp.Services;

namespace WpfTaskApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FileSystemVisitor _fileSystemVisitor;
        public List<string> directories = new List<string>();
        public List<string> files = new List<string>();
        private string path;

        public MainWindow()
        {
            InitializeComponent();
            _fileSystemVisitor = new FileSystemVisitor();
            setEvent();
            _fileSystemVisitor.RaiseEvent("Application Started");


        }

        private void setEvent()
        {
            _fileSystemVisitor.NotificationEvent += (s, e) =>
            {
                notificationsList.Items.Add(e);
            };
        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            _fileSystemVisitor.RaiseEvent("Looking for Files and Directories");
            path = Path.Text;
            fillLists(path);
            displayDirectoryAndFileList();
        }

        private void fillLists(string path)
        {
            directories.Clear();
            files.Clear();
            foreach (string directory in _fileSystemVisitor.FindFolders(path))
            {
                directories.Add(directory);
            }

            foreach (string file in _fileSystemVisitor.FindFiles(path))
            {
                files.Add(file);
            }

        }

        private void displayDirectoryAndFileList()
        {
            listofDirectories.Items.Clear();
            listofFiles.Items.Clear();
            if(directories.Count > 0)
            {
                _fileSystemVisitor.RaiseEvent("Directories Found");
                foreach (string directory in directories)
                {
                    listofDirectories.Items.Add(directory);
                }

            }
            else
            {
                _fileSystemVisitor.RaiseEvent("There is no such Directory");
            }
            if (files.Count > 0)
            {
                _fileSystemVisitor.RaiseEvent("Files Found");
                foreach (string file in files)
                {
                    listofFiles.Items.Add(file);
                }

            }
            else
            {
                _fileSystemVisitor.RaiseEvent("There is no such File");
            }




          
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            _fileSystemVisitor = new FileSystemVisitor(search_directory.Text, search_file.Text);
            setEvent();
            path = Path.Text;
            fillLists(path);

            if (search_directory.Text != "Directory Name" && search_directory.Text != "")
            {          

                _fileSystemVisitor.RaiseEvent($"Searching {search_directory.Text} directory");
                directories = _fileSystemVisitor.SearchDirectory(directories);
                _fileSystemVisitor.RaiseEvent("Search End");
                
            }else
            {
                directories.Clear();
                _fileSystemVisitor.RaiseEvent("Write Directory Name");
            }           

            if (search_file.Text != "File Name" && search_file.Text != "")
            {
                _fileSystemVisitor.RaiseEvent($"Searching {search_file.Text} file");
                files = _fileSystemVisitor.SearchFiles(files);
                _fileSystemVisitor.RaiseEvent("Search End");
            }
            else
            {
                files.Clear();
                _fileSystemVisitor.RaiseEvent("Write File Name");
            }



            displayDirectoryAndFileList();


        }

        private void search_directory_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search_directory.Text == "Directory Name")
            {
                search_directory.Text = "";
            }
        }

        private void search_directory_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(search_directory.Text))
            {
                search_directory.Text = "Directory Name";
            }
        }

        private void search_file_GotFocus(object sender, RoutedEventArgs e)
        {
            if (search_file.Text == "File Name")
            {
                search_file.Text = "";
            }
        }

        private void search_file_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(search_file.Text))
            {
                search_file.Text = "File Name";
            }
        }
    }
}
