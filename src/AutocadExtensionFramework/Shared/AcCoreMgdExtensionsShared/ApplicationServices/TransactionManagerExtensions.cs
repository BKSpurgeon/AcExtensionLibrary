using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.ApplicationServices
{
   public static class TransactionManagerExtensions
    {
       public static Runtime.LockedTransaction StarLockedTransaction(this TransactionManager tm)
       {
           DocumentLock doclock = Application.DocumentManager.MdiActiveDocument.LockDocument();
           return new Runtime.LockedTransaction(tm.StartTransaction(), doclock);
       }

       public static Runtime.LockedTransaction StarLockedTransaction(this TransactionManager tm, DocumentLockMode lockMode, string globalCommandName, string localCommandName, bool promptIfFails)
       {
           DocumentLock doclock = Application.DocumentManager.MdiActiveDocument.LockDocument(lockMode, globalCommandName, localCommandName, promptIfFails);
           return new Runtime.LockedTransaction(tm.StartTransaction(), doclock);
       }
    }
}
