using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{


    public static class LinetypeTableExtensions
    {

        public static IEnumerable<LinetypeTableRecord> GetLinetypeTableRecords(this LinetypeTable symbolTbl, Transaction trx, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<LinetypeTableRecord>(trx, mode, filter, false);
        }

        public static IEnumerable<LinetypeTableRecord> GetLinetypeTableRecords(this LinetypeTable symbolTbl, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<LinetypeTableRecord>(symbolTbl.Database.TransactionManager.TopTransaction, mode, filter, false);
        }

    }
}
