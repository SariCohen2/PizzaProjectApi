using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
// using modelsLib;
// using FileService;

namespace FileService;

    public class myFile:Ifile
    {
        public string FilePath { get ; set ; }
        public myFile()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "files", "myFile.json");
        }
        public void WriteMessage(string message)
        {  
            if (File.Exists(FilePath))
            {
                File.WriteAllText(FilePath, $" {message}");// {DateTime.Now}
            }
        }

        public List<T> ReadFromFile<T>()
        {
            string json = File.ReadAllText(FilePath);
            var TList = JsonSerializer.Deserialize<List<T>>(json);
            if (TList != null)
                return TList;
            return default(List<T>);
        }
       }

