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

        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
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
            foreach (string directory in directories)
            {
                listofDirectories.Items.Add(directory);
            }

            foreach (string file in files)
            {
                listofFiles.Items.Add(file);
            }
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
           
            if (search_directory.Text != "Directory Name" && search_directory.Text != "")
            {          

                directories = _fileSystemVisitor.SearchDirectory(directories, search_directory.Text);
                
            }           

            if (search_file.Text != "File Name" && search_file.Text != "")
            {

                files = _fileSystemVisitor.SearchFiles(files, search_file.Text);
                
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
