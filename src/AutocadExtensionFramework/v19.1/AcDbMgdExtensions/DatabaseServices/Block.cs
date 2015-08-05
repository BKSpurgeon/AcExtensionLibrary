using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices.Contracts;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices
{
    /// <summary>
    /// Just quickly adding something to start for wrapping a BlockTableRecord
    /// </summary>
   //public class Block : BlockTableRecord, IEnumerable<Entity>
   // {
   //    private Transaction trans { get; set; }
   //    public Block(BlockTableRecord btr, Transaction trx)
   //        : base(btr.UnmanagedObject, btr.AutoDelete)
   //    {
   //        TransactionContracts.TransactionActive(trx, btr);
   //        if (trx == null)
   //        {
   //            trx = btr.Database.TransactionManager.TopTransaction;
   //        }
   //        trans = trx;
   //        Interop.DetachUnmanagedObject(btr);
   //        GC.SuppressFinalize(btr);
   //    }

   //     public new IEnumerator<Entity> GetEnumerator()
   //     {
   //         using (BlockTableRecordEnumerator enumerator = base.GetEnumerator())
   //         {
   //             if (enumerator.MoveNext())
   //             {

   //                 do
   //                 {
   //                     yield return (Entity)trans.GetObject(enumerator.SystemVariables, OpenMode.ForRead, enumerator.SystemVariables.IsErased, false);

   //                 } while (enumerator.MoveNext());
   //             }
   //         }
   //     }
   // }
}
