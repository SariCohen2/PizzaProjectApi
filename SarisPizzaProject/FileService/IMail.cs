using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileService;
public interface IMail
{
  void WriteMessage<T>(T message);

}
