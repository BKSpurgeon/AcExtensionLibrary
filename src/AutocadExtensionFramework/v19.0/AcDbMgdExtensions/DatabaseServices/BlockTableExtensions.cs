using System.Collections.Generic;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class BlockTableExtensions
    {
        public static IEnumerable<BlockTableRecord> GetBlockTableRecords(this BlockTable symbolTbl, Transaction trx, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            if (filter.IsSet(SymbolTableRecordFilter.IncludeDependent))
            {
                return symbolTbl.GetSymbolTableRecords<BlockTableRecord>(trx, mode, filter, true);
            }
            return symbolTbl.GetSymbolTableRecords<BlockTableRecord>(trx, mode, filter, true).NonDependent();
        }

        public static IEnumerable<BlockTableRecord> GetBlockTableRecords(this BlockTable symbolTbl, OpenMode mode = OpenMode.ForRead, SymbolTableRecordFilter filter = SymbolTableRecordFilter.None)
        {
            return symbolTbl.GetBlockTableRecords(symbolTbl.Database.TransactionManager.TopTransaction, mode, filter);
        }


        public static IEnumerable<BlockTableRecord> GetUserDefinedBlockTableRecords(this BlockTable symbolTbl, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {

            return symbolTbl.GetSymbolTableRecords<BlockTableRecord>(trx, mode, SymbolTableRecordFilter.None, true).UserDefinedBlocks();
        }

        public static IEnumerable<BlockTableRecord> GetUserDefinedBlockTableRecords(this BlockTable symbolTbl, OpenMode mode = OpenMode.ForRead)
        {
            return symbolTbl.GetUserDefinedBlockTableRecords(symbolTbl.Database.TransactionManager.TopTransaction, mode);
        }


        public static IEnumerable<BlockTableRecord> GetUserCreatedBlockTableRecords(this BlockTable symbolTbl, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {

            return symbolTbl.GetSymbolTableRecords<BlockTableRecord>(trx, mode, SymbolTableRecordFilter.None, true).UserCreatedBlocks();
        }

        public static IEnumerable<BlockTableRecord> GetUserCreatedBlockTableRecords(this BlockTable symbolTbl, OpenMode mode = OpenMode.ForRead)
        {
            return symbolTbl.GetUserCreatedBlockTableRecords(symbolTbl.Database.TransactionManager.TopTransaction, mode);
        }



        internal static ObjectId GetDatabaseBlockTableId(this BlockTable symbolTbl, Database db)
        {
            return db.BlockTableId;
        }
    }

}