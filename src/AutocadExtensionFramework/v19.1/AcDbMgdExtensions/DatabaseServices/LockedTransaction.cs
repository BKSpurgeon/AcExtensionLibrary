using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;

namespace Autodesk.AutoCAD.DatabaseServices
{
   public class LockedTransaction : Transaction
    {
       DocumentLock docLock;
       public LockedTransaction(Transaction trx, DocumentLock docLock)
           : base(trx.UnmanagedObject, trx.AutoDelete)
       {
           Interop.DetachUnmanagedObject(trx);
           GC.SuppressFinalize(trx);
           this.docLock = docLock;
           
       }

       protected override void Dispose(bool A_1)
       {

           base.Dispose(A_1);
           if (A_1)
           {
               docLock.Dispose();
           }
       }
    }
}
