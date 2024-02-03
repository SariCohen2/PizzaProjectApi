using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
// using modelsLib;
// using FileService;
namespace FileService;

    public class myLog:Ilog
    {
        public string FilePath { get ; set ; }
        public myLog()
        {
            this.FilePath = Path.Combine(Environment.CurrentDirectory, "files", "middleware.txt");
        }

        public void WriteMessageToLog<T>(T message)
        {  
            if (File.Exists(FilePath))
            {
                File.AppendAllText(FilePath, $" {message}");
            }
        }

       }