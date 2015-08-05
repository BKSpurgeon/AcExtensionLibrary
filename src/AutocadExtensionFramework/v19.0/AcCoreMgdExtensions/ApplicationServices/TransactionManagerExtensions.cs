using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices.Core;

namespace Autodesk.AutoCAD.ApplicationServices
{
   public static class TransactionManagerExtensions
    {
       public static LockedTransaction StarLockedTransaction(this TransactionManager tm)
       {
           DocumentLock doclock = Application.DocumentManager.MdiActiveDocument.LockDocument();
           return new LockedTransaction(tm.StartTransaction(), doclock);
       }

       public static LockedTransaction StarLockedTransaction(this TransactionManager tm, DocumentLockMode lockMode, string globalCommandName, string localCommandName, bool promptIfFails)
       {
           DocumentLock doclock = Application.DocumentManager.MdiActiveDocument.LockDocument(lockMode, globalCommandName, localCommandName, promptIfFails);
           return new LockedTransaction(tm.StartTransaction(), doclock);
       }
    }
}
