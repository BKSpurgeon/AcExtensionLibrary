using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.Runtime
{
  public class CommandTransaction : IDisposable
    {

      private CommandTransaction()
      {

      }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
