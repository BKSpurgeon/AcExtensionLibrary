using Autodesk.AutoCAD.Runtime;
using System;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace Autodesk.AutoCAD.DatabaseServices
{
    /// <summary>
    /// Extension class for Database object
    /// </summary>

    public static class DatabaseExtensions
    {
        /// <summary>
        /// The standard
        /// </summary>
        private static string standard = "Standard";

        /// <summary>
        /// Opens the BlockTable
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <code></code>
        public static BlockTable BlockTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (BlockTable)trx.GetObject(db.BlockTableId, mode, false, false);
        }

        /// <summary>
        /// Blocks the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static BlockTable BlockTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.BlockTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Dims the style table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DimStyleTable DimStyleTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DimStyleTable)trx.GetObject(db.DimStyleTableId, mode, false, false);
        }

        /// <summary>
        /// Dims the style table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DimStyleTable DimStyleTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.DimStyleTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Layers the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static LayerTable LayerTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (LayerTable)trx.GetObject(db.LayerTableId, mode, false, false);
        }

        /// <summary>
        /// Layers the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static LayerTable LayerTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.LayerTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Linetypes the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static LinetypeTable LinetypeTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (LinetypeTable)trx.GetObject(db.LinetypeTableId, mode, false, false);
        }

        /// <summary>
        /// Linetypes the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static LinetypeTable LinetypeTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.LinetypeTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Regs the application table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static RegAppTable RegAppTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (RegAppTable)trx.GetObject(db.RegAppTableId, mode, false, false);
        }

        /// <summary>
        /// Regs the application table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static RegAppTable RegAppTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.RegAppTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Texts the style table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static TextStyleTable TextStyleTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (TextStyleTable)trx.GetObject(db.TextStyleTableId, mode, false, false);
        }

        /// <summary>
        /// Texts the style table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static TextStyleTable TextStyleTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.TextStyleTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Standards the text style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        public static ObjectId StandardTextStyle(this Database db)
        {
            return SymbolUtilityServices.GetTextStyleStandardId(db);
        }

        /// <summary>
        /// Continuouses the linetype identifier.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        public static ObjectId ContinuousLinetypeId(this Database db)
        {
            return SymbolUtilityServices.GetLinetypeContinuousId(db);
        }

        /// <summary>
        /// Standards the dim style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <returns></returns>
        public static ObjectId StandardDimStyle(this Database db, Transaction trx)
        {
            var dimtbl = db.DimStyleTable(trx);
            return dimtbl.Has(standard) ? dimtbl[standard] : db.Dimstyle;
        }

        /// <summary>
        /// Standards the dim style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        public static ObjectId StandardDimStyle(this Database db)
        {
            return db.StandardDimStyle(db.TransactionManager.TopTransaction);
        }

        /// <summary>
        /// Ucses the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static UcsTable UcsTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (UcsTable)trx.GetObject(db.UcsTableId, mode, false, false);
        }

        /// <summary>
        /// Ucses the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static UcsTable UcsTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.UcsTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Viewports the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ViewportTable ViewportTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (ViewportTable)trx.GetObject(db.ViewportTableId, mode, false, false);
        }

        /// <summary>
        /// Viewports the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static ViewportTable ViewportTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.ViewportTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Views the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static ViewTable ViewTable(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (ViewTable)trx.GetObject(db.ViewTableId, mode, false, false);
        }

        /// <summary>
        /// Views the table.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static ViewTable ViewTable(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.ViewTable(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static BlockTableRecord ModelSpace(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (BlockTableRecord)trx.GetObject(SymbolUtilityServices.GetBlockModelSpaceId(db), mode, false, false);
        }

        /// <summary>
        /// Models the space.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static BlockTableRecord ModelSpace(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.ModelSpace(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=41311.msg464457#msg464457
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static BlockTableRecord CurrentSpace(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (BlockTableRecord)trx.GetObject(db.CurrentSpaceId, mode, false, false);
        }

        /// <summary>
        /// Currents the space.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static BlockTableRecord CurrentSpace(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.CurrentSpace(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Nameds the object database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary NamedObjectDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.NamedObjectsDictionaryId, mode, false, false);
        }

        /// <summary>
        /// Nameds the object database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary NamedObjectDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.NamedObjectDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Groups the database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary GroupDBDictionary(this Database db, Transaction trx, OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.GroupDictionaryId, mode, false, false);
        }

        /// <summary>
        /// Groups the database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary GroupDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.GroupDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Mls the style database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary MLStyleDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.MLStyleDictionaryId, mode, false, false);
        }

        /// <summary>
        /// Mls the style database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary MLStyleDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.MLStyleDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Standards the ml style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        public static ObjectId StandardMLStyle(this Database db)
        {
            return db.StandardMLStyle(db.TransactionManager.TopTransaction);
        }

        /// <summary>
        /// Standards the ml style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <returns></returns>
        public static ObjectId StandardMLStyle(this Database db, Transaction trx)
        {
            var mlDic = db.MLStyleDBDictionary(trx);
            return mlDic.Contains(standard) ? mlDic.GetAt(standard) : db.CmlstyleID;
        }

        /// <summary>
        /// Layouts the database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary LayoutDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.LayoutDictionaryId, mode, false, false);
        }

        /// <summary>
        /// Layouts the database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary LayoutDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.LayoutDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Plots the settings database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary PlotSettingsDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.PlotSettingsDictionaryId, mode, false, false);
        }

        /// <summary>
        /// Plots the settings database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary PlotSettingsDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.PlotSettingsDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Tables the style database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary TableStyleDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.TableStyleDictionaryId, mode, false, false);
        }

        /// <summary>
        /// Tables the style database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary TableStyleDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.TableStyleDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// ms the leader style database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static DBDictionary MLeaderStyleDBDictionary(this Database db, Transaction trx,
            OpenMode mode = OpenMode.ForRead)
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            return (DBDictionary)trx.GetObject(db.MLeaderStyleDictionaryId, mode, false, false);
        }

        /// <summary>
        /// ms the leader style database dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <returns></returns>
        public static DBDictionary MLeaderStyleDBDictionary(this Database db, OpenMode mode = OpenMode.ForRead)
        {
            return db.MLeaderStyleDBDictionary(db.TransactionManager.TopTransaction, mode);
        }

        /// <summary>
        /// Standards the m leader style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        public static ObjectId StandardMLeaderStyle(this Database db)
        {
            return db.StandardMLeaderStyle(db.TransactionManager.TopTransaction);
        }

        /// <summary>
        /// Standards the m leader style.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <returns></returns>
        public static ObjectId StandardMLeaderStyle(this Database db, Transaction trx)
        {
            var mlDic = db.MLeaderStyleDBDictionary(trx);
            return mlDic.Contains(standard) ? mlDic.GetAt(standard) : db.MLeaderstyle;
        }

        /// <summary>
        /// Groups the dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="includingErased">if set to <c>true</c> [including erased].</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Groups the dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="includingErased">if set to <c>true</c> [including erased].</param>
        /// <returns></returns>
        public static GroupDictionary GroupDictionary(this Database db, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false)
        {
            return db.GroupDictionary(db.TransactionManager.TopTransaction, mode, includingErased);
        }

        /// <summary>
        /// Mls the style dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="includingErased">if set to <c>true</c> [including erased].</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Mls the style dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="includingErased">if set to <c>true</c> [including erased].</param>
        /// <returns></returns>
        public static MLStyleDictionary MLStyleDictionary(this Database db, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false)
        {
            return db.MLStyleDictionary(db.TransactionManager.TopTransaction, mode, includingErased);
        }

        /// <summary>
        /// Layouts the dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="trx">The TRX.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="includingErased">if set to <c>true</c> [including erased].</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Layouts the dictionary.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="includingErased">if set to <c>true</c> [including erased].</param>
        /// <returns></returns>
        public static LayoutDictionary LayoutDictionary(this Database db, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false)
        {
            return db.LayoutDictionary(db.TransactionManager.TopTransaction, mode, includingErased);
        }

        /// <summary>
        /// Revisions the number.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Increments the revision number.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <returns></returns>
        public static int IncrementRevisionNumber(this Database db)
        {
            return db.AddToRevisionNumber(1);
        }

        /// <summary>
        /// Adds to revision number.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="number">The number.</param>
        /// <returns></returns>
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