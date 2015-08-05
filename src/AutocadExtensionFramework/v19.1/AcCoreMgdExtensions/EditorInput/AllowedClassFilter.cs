using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime; 

namespace Autodesk.AutoCAD.EditorInput
{
   public class AllowedClassFilter
   {
       private HashSet<IntPtr> ptrs = new HashSet<IntPtr>();
       internal ICollection<IntPtr> AllowedClassPtrs { get { return ptrs; } }

       public AllowedClassFilter(params Type[] types)
       {
           foreach (Type typ in types)
           {
               AddAllowedClass(typ);
           }
       }

       public void AddAllowedClass(Type type)
       {
           ptrs.Add(RXClass.GetClass(type).UnmanagedObject);
       }
    }
}
