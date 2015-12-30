using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(Samplescsharp.AcDbMgdExtensions.DatabaseServices.BlockTableExtensionsCommands))]
namespace Samplescsharp.AcDbMgdExtensions.DatabaseServices
{
    public class BlockTableExtensionsCommands : CommandClass
    {
        #region GetBlockTableRecords
        [CommandMethod("GetBlockTableRecords")]
        public void GetBlockTableRecords()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTable bt = Db.BlockTable();
                var blocks = bt.GetBlockTableRecords();
                foreach (var blk in blocks)
                {
                    Ed.WriteLine($"Contains {blk.GetObjectIds().Count()} this many entities in BlockTableRecord");
                }
            }
        }
        #endregion

        #region GetBlockTableRecordsOpenForWrite
        [CommandMethod("GetBlockTableRecordsOpenForWrite")]
        public void GetBlockTableRecordsOpenForWrite()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTable bt = Db.BlockTable();
               var blocks = bt.GetBlockTableRecords(OpenMode.ForWrite);
              

                foreach (var blk in blocks)
                {
                    Ed.WriteLine($"Contains {blk.GetObjectIds().Count()} this many entities in BlockTableRecord");
                }
            }
        }
        #endregion

        #region GetBlockTableRecordsOpenForReadAndXrefBlocks
        [CommandMethod("GetBlockTableRecordsOpenForReadAndXrefBlocks")]
        public void GetBlockTableRecordsOpenForReadAndXrefBlocks()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTable bt = Db.BlockTable();
                var blocks = bt.GetBlockTableRecords(OpenMode.ForRead, SymbolTableRecordFilter.IncludeDependent);

                foreach (var blk in blocks)
                {
                    Ed.WriteLine($"Contains {blk.GetObjectIds().Count()} this many entities in BlockTableRecord");
                }
            }
        }
        #endregion
    }
}
