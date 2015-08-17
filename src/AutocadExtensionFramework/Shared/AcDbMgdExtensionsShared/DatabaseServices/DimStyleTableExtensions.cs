using System.Collections.Generic;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class DimStyleTableExtensions
    {
        public static IEnumerable<DimStyleTableRecord> GetDimStyleTableRecords(this DimStyleTable symbolTbl,
            Transaction trx, OpenMode mode = OpenMode.ForRead,
            SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<DimStyleTableRecord>(trx, mode, filter, true);
        }

        public static IEnumerable<DimStyleTableRecord> GetDimStyleTableRecords(this DimStyleTable symbolTbl,
            OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return
                symbolTbl.GetSymbolTableRecords<DimStyleTableRecord>(
                    symbolTbl.Database.TransactionManager.TopTransaction, mode, filter, true);
        }
    }
}
