using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileService;
public interface Ilog
{
 string FilePath{get;set;}
 void WriteMessageToLog<T>(T message);
}




