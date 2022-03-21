using System;
using System.Collections.Generic;
using WpfTaskApp.Services;
using Xunit;

namespace Task.xUnitTest
{
    public class FileSystemVisitorTest
    {
        [Fact]
        public void SearchDirectory_WithMatchedDirectoryName_ReturnsMatchedDirectories()
        {
            //arrange
            var fileSystemVisitor = new FileSystemVisitor();

            List<string> directories = ListOfDirectoryNames();

            string directoryName = "Win";

            //Act
            var result = fileSystemVisitor.SearchDirectory(directories, directoryName);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void SearchDirectory_WithNotMatchedDirectoryName_ReturnsEmptyList()
        {
            //arrange
            var fileSystemVisitor = new FileSystemVisitor();

            List<string> directories = ListOfDirectoryNames();

            string directoryName = "WinWWW";

            //Act
            var result = fileSystemVisitor.SearchDirectory(directories, directoryName);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }
        [Fact]
        public void SearchFile_WithNotMatchedFileName_ReturnsEmptyList()
        {
            //arrange
            var fileSystemVisitor = new FileSystemVisitor();

            List<string> files = ListOfFileNames();

            string fileName = "code123";

            //Act
            var result = fileSystemVisitor.SearchFiles(files, fileName);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }
        [Fact]
        public void SearchFile_WithMatchedFileName_ReturnsMatchedFiles()
        {
            //arrange
            var fileSystemVisitor = new FileSystemVisitor();

            List<string> files = ListOfFileNames();

            string fileName = "code";

            //Act
            var result = fileSystemVisitor.SearchFiles(files, fileName);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.True(result[0].Contains(fileName));
        }


        private List<string> ListOfDirectoryNames()
        {
            return new List<string>() {
            "System",
            "Windows",
            "Game",
            "Win32",
            "Win64"
            };
        }
        private List<string> ListOfFileNames()
        {
            return new List<string>() {
            "codeforce.cpp",
            "leetcode.cs",
            "index.html",
            "style.css",
            "hakkerRank.txt"
            };
        }
    }
}
