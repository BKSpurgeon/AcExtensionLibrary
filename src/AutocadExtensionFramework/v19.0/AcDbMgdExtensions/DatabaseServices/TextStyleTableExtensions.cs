using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class TextStyleTableExtensions
    {

        public static IEnumerable<TextStyleTableRecord> GetTextStyleTableRecords(this TextStyleTable symbolTbl, Transaction trx, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<TextStyleTableRecord>(trx, mode, filter, true);
        }

        public static IEnumerable<TextStyleTableRecord> GetTextStyleTableRecords(this TextStyleTable symbolTbl, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<TextStyleTableRecord>(symbolTbl.Database.TransactionManager.TopTransaction, mode, filter, true);
        }
    }
}
