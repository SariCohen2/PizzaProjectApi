using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
// using modelsLib;
// using FileService;

namespace FileService;

    public class myWorker:IWorker
    {
        public string FilePath { get ; set ; }
        public myWorker()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "files", "worker.json");
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

