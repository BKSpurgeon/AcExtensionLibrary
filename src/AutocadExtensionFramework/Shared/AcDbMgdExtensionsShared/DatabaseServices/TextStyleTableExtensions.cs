using System.Collections.Generic;
using System.Linq;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class TextStyleTableExtensions
    {
        public static IEnumerable<TextStyleTableRecord> GetAllTextStyleTableRecords(this TextStyleTable symbolTbl,
            Transaction trx, OpenMode mode = OpenMode.ForRead,
            SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<TextStyleTableRecord>(trx, mode, filter, true);
        }

        public static IEnumerable<TextStyleTableRecord> GetAllTextStyleTableRecords(this TextStyleTable symbolTbl,
            OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return
                symbolTbl.GetSymbolTableRecords<TextStyleTableRecord>(
                    symbolTbl.Database.TransactionManager.TopTransaction, mode, filter, true);
        }

        public static IEnumerable<TextStyleTableRecord> GetTextStyleTableRecords(this TextStyleTable symbolTbl,
            Transaction trx, OpenMode mode = OpenMode.ForRead,
            SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return
                symbolTbl.GetSymbolTableRecords<TextStyleTableRecord>(trx, mode, filter, true)
                    .Where(txt => !txt.IsShapeFile);
        }

        public static IEnumerable<TextStyleTableRecord> GetTextStyleTableRecords(this TextStyleTable symbolTbl,
            OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetTextStyleTableRecords(symbolTbl.Database.TransactionManager.TopTransaction, mode, filter);
        }

        public static IEnumerable<TextStyleTableRecord> GetShapeFileTableRecords(this TextStyleTable symbolTbl,
            Transaction trx, OpenMode mode = OpenMode.ForRead,
            SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return
                symbolTbl.GetSymbolTableRecords<TextStyleTableRecord>(trx, mode, filter, true)
                    .Where(txt => txt.IsShapeFile);
        }

        public static IEnumerable<TextStyleTableRecord> GetShapeFileTableRecords(this TextStyleTable symbolTbl,
            OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetShapeFileTableRecords(symbolTbl.Database.TransactionManager.TopTransaction, mode, filter);
        }
    }
}
