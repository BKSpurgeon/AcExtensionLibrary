using Autodesk.AutoCAD.Runtime;
using System;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class DatabaseExtensions
    {
        private static string standard = "Standard";

        public static BlockTable BlockTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (BlockTable) trx.GetObject(db.BlockTableId, mode, false, false);
        }


        public static BlockTable BlockTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.BlockTable(db.TransactionManager.TopTransaction, mode);
        }


        public static DimStyleTable DimStyleTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DimStyleTable) trx.GetObject(db.DimStyleTableId, mode, false, false);
        }


        public static DimStyleTable DimStyleTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.DimStyleTable(db.TransactionManager.TopTransaction, mode);
        }


        public static LayerTable LayerTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (LayerTable) trx.GetObject(db.LayerTableId, mode, false, false);
        }


        public static LayerTable LayerTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.LayerTable(db.TransactionManager.TopTransaction, mode);
        }

        public static LinetypeTable LinetypeTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (LinetypeTable) trx.GetObject(db.LinetypeTableId, mode, false, false);
        }


        public static LinetypeTable LinetypeTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.LinetypeTable(db.TransactionManager.TopTransaction, mode);
        }


        public static RegAppTable RegAppTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (RegAppTable) trx.GetObject(db.RegAppTableId, mode, false, false);
        }


        public static RegAppTable RegAppTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.RegAppTable(db.TransactionManager.TopTransaction, mode);
        }


        public static TextStyleTable TextStyleTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (TextStyleTable) trx.GetObject(db.TextStyleTableId, mode, false, false);
        }


        public static TextStyleTable TextStyleTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.TextStyleTable(db.TransactionManager.TopTransaction, mode);
        }

        public static ObjectId StandardTextStyle(this Database db)
        {
            return SymbolUtilityServices.GetTextStyleStandardId(db);
        }


        public static ObjectId ContinuousLinetypeId(this Database db)
        {
            return SymbolUtilityServices.GetLinetypeContinuousId(db);
        }

        public static ObjectId StandardDimStyle(this Database db, Transaction trx)
        {
            var dimtbl = db.DimStyleTable(trx);
            return dimtbl.Has(standard) ? dimtbl[standard] : db.Dimstyle;
        }

        public static ObjectId StandardDimStyle(this Database db)
        {
            return db.StandardDimStyle(db.TransactionManager.TopTransaction);
        }


        public static UcsTable UcsTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (UcsTable) trx.GetObject(db.UcsTableId, mode, false, false);
        }


        public static UcsTable UcsTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.UcsTable(db.TransactionManager.TopTransaction, mode);
        }


        public static ViewportTable ViewportTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (ViewportTable) trx.GetObject(db.ViewportTableId, mode, false, false);
        }


        public static ViewportTable ViewportTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.ViewportTable(db.TransactionManager.TopTransaction, mode);
        }


        public static ViewTable ViewTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (ViewTable) trx.GetObject(db.ViewTableId, mode, false, false);
        }


        public static ViewTable ViewTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.ViewTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <param name="db"></param>
        /// <param name="trx"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static BlockTableRecord ModelSpace(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (BlockTableRecord) trx.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), mode, false, false);
        }


        public static BlockTableRecord ModelSpace(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.ModelSpace(db.TransactionManager.TopTransaction, mode);
        }


        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <param name="db"></param>
        /// <param name="trx"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static BlockTableRecord CurrentSpace(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (BlockTableRecord) trx.GetObject(db.CurrentSpaceId, mode, false, false);
        }


        public static BlockTableRecord CurrentSpace(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.CurrentSpace(db.TransactionManager.TopTransaction, mode);
        }


        public static DBDictionary NamedObjectDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.NamedObjectsDictionaryId, mode, false, false);
        }


        public static DBDictionary NamedObjectDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.NamedObjectDBDictionary(db.TransactionManager.TopTransaction, mode);
        }


        public static DBDictionary GroupDBDictionary(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.GroupDictionaryId, mode, false, false);
        }


        public static DBDictionary GroupDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.GroupDBDictionary(db.TransactionManager.TopTransaction, mode);
        }


        public static DBDictionary MLStyleDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.MLStyleDictionaryId, mode, false, false);
        }


        public static DBDictionary MLStyleDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.MLStyleDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        public static ObjectId StandardMLStyle(this Database db)
        {
            return db.StandardMLStyle(db.TransactionManager.TopTransaction);
        }

        public static ObjectId StandardMLStyle(this Database db, Transaction trx)
        {
            var mlDic = db.MLStyleDBDictionary(trx);
            return mlDic.Contains(standard) ? mlDic.GetAt(standard) : db.CmlstyleID;
        }


        public static DBDictionary LayoutDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.LayoutDictionaryId, mode, false, false);
        }


        public static DBDictionary LayoutDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.LayoutDBDictionary(db.TransactionManager.TopTransaction, mode);
        }


        public static DBDictionary PlotSettingsDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.PlotSettingsDictionaryId, mode, false, false);
        }


        public static DBDictionary PlotSettingsDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.PlotSettingsDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        public static DBDictionary TableStyleDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.TableStyleDictionaryId, mode, false, false);
        }


        public static DBDictionary TableStyleDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.TableStyleDBDictionary(db.TransactionManager.TopTransaction, mode);
        }


        public static DBDictionary MLeaderStyleDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary) trx.GetObject(db.MLeaderStyleDictionaryId, mode, false, false);
        }


        public static DBDictionary MLeaderStyleDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.MLeaderStyleDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        public static ObjectId StandardMLeaderStyle(this Database db)
        {
            return db.StandardMLeaderStyle(db.TransactionManager.TopTransaction);
        }

        public static ObjectId StandardMLeaderStyle(this Database db, Transaction trx)
        {
            var mlDic = db.MLeaderStyleDBDictionary(trx);
            return mlDic.Contains(standard) ? mlDic.GetAt(standard) : db.MLeaderstyle;
        }

        public static GroupDictionary GroupDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead, bool includingErased = false)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            DBDictionary dic = (DBDictionary)trx.GetObject(db.GroupDictionaryId, mode, false, false);
            return includingErased
                ? new GroupDictionary(trx, dic, includingErased)
                : new GroupDictionary(trx, dic.IncludingErased, includingErased);
        }

        public static GroupDictionary GroupDictionary(this Database db, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false)
        {
            return db.GroupDictionary(db.TransactionManager.TopTransaction, mode, includingErased);
        }

        public static MLStyleDictionary MLStyleDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead, bool includingErased = false)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            DBDictionary dic = (DBDictionary)trx.GetObject(db.MLStyleDictionaryId, mode, false, false);
            return includingErased
                ? new MLStyleDictionary(trx, dic, includingErased)
                : new MLStyleDictionary(trx, dic.IncludingErased, includingErased);
        }

        public static MLStyleDictionary MLStyleDictionary(this Database db, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false)
        {
            return db.MLStyleDictionary(db.TransactionManager.TopTransaction, mode, includingErased);
        }

        public static LayoutDictionary LayoutDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead, bool includingErased = false)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            DBDictionary dic = (DBDictionary)trx.GetObject(db.LayoutDictionaryId, mode, false, false);
            return includingErased
                ? new LayoutDictionary(trx, dic, includingErased)
                : new LayoutDictionary(trx, dic.IncludingErased, includingErased);
        }

        public static LayoutDictionary LayoutDictionary(this Database db, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false)
        {
            return db.LayoutDictionary(db.TransactionManager.TopTransaction, mode, includingErased);
        }

        public static int RevisionNumber(this Database db)
        {
            DatabaseSummaryInfo info = db.SummaryInfo;
            string revisionNumberString = info.RevisionNumber;
            int revisionNumber;
            if (!revisionNumberString.IsNullOrEmpty())
            {
                if (Int32.TryParse(revisionNumberString, out revisionNumber))
                {
                    return revisionNumber;
                }
            }
            revisionNumber = 0;
            DatabaseSummaryInfoBuilder infoBuilder = new DatabaseSummaryInfoBuilder(info);
            infoBuilder.RevisionNumber = revisionNumber.ToString();
            db.SummaryInfo = infoBuilder.ToDatabaseSummaryInfo();
            return revisionNumber;
        }

        public static int IncrementRevisionNumber(this Database db)
        {
            return db.AddToRevisionNumber(1);
        }

        public static int AddToRevisionNumber(this Database db, int number)
        {
            DatabaseSummaryInfo info = db.SummaryInfo;
            string revisionNumberString = info.RevisionNumber;
            int revisionNumber;
            if (revisionNumberString.IsNullOrEmpty() || !Int32.TryParse(revisionNumberString, out revisionNumber))
            {
                revisionNumber = 0;
            }

            int newRevisionNum = revisionNumber + number;
            if (newRevisionNum < 0)
            {
                newRevisionNum = 0;
            }
            DatabaseSummaryInfoBuilder infoBuilder = new DatabaseSummaryInfoBuilder(db.SummaryInfo);
            infoBuilder.RevisionNumber = newRevisionNum.ToString();
            db.SummaryInfo = infoBuilder.ToDatabaseSummaryInfo();
            return newRevisionNum;
        }
    }
}
