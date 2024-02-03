using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileService;
public interface Ifile
{
 string FilePath{get;set;}
  void WriteMessage(string message);
// public void AddItem<T>(T item);
 List<T> ReadFromFile<T>();
// public void Update<T>(List<T> list);
}




