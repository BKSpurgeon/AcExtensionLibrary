using System.Collections.Generic;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class LayerTableExtensions
    {

        public static IEnumerable<LayerTableRecord> GetLayerTableRecords(this LayerTable symbolTbl, Transaction trx, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<LayerTableRecord>(trx, mode, filter, false);
        }

        public static IEnumerable<LayerTableRecord> GetLayerTableRecords(this LayerTable symbolTbl, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetSymbolTableRecords<LayerTableRecord>(symbolTbl.Database.TransactionManager.TopTransaction, mode, filter, false);
        }

    }


}
