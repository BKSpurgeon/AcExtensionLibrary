using System;
using System.Collections.Generic;

namespace Autodesk.AutoCAD.ApplicationServices.Core
{
   public class TemporarySystemVariables : Settings.SystemVariables, IDisposable
    {
       public TemporarySystemVariables()
       {

       }
       private Dictionary<string, object> _variables = new Dictionary<string, object>();
       public override object this[string name]
       {
           get
           {
               return base[name];
           }
           set
           {
               if (base[name] != value)
               {
                   if (!_variables.ContainsKey(name))
                   {
                       _variables.Add(name, base[name]);
                   }
                   base[name] = value;
               }
           }
       }

       public void Dispose()
       {
           foreach (var variable in _variables)
           {
               base[variable.Key] = variable.Value;
           }
           _variables.Clear();
       }
    }
}
