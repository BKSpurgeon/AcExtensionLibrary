using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;

[assembly: CommandClass(typeof(Samplescsharp.AcDbMgdExtensions.DatabaseServices.DatabaseExtensionsCommands))]
namespace Samplescsharp.AcDbMgdExtensions.DatabaseServices
{
   
    public class DatabaseExtensionsCommands : CommandClass
    {

        #region BlockTable
        [CommandMethod("BlockTable")]
        public void BlockTable()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTable bt = Db.BlockTable();
                Ed.WriteLine(bt.ObjectId);
            }
        }
        #endregion

        #region BlockTableTrx
        [CommandMethod("BlockTableTrx")]
        public void BlockTableTrx()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTable bt = Db.BlockTable(trx);
                Ed.WriteLine(bt.ObjectId);
            }
        }
        #endregion


        #region DimStyleTable
        [CommandMethod("DimStyleTable")]
        public void DimStyleTable()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                DimStyleTable dt = Db.DimStyleTable();
                Ed.WriteLine(dt.ObjectId);
            }
        }
        #endregion

        #region DimStyleTableTrx
        [CommandMethod("DimStyleTableTrx")]
        public void DimStyleTableTrx()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                DimStyleTable dt = Db.DimStyleTable(trx);
                Ed.WriteLine(dt.ObjectId);
            }
        }
        #endregion


        #region LayerTable
        [CommandMethod("LayerTable")]
        public void LayerTable()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                LayerTable dt = Db.LayerTable();
                Ed.WriteLine(dt.ObjectId);
            }
        }
        #endregion

        #region LayerTableTrx
        [CommandMethod("LayerTableTrx")]
        public void LayerTableTrx()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                LayerTable lt = Db.LayerTable(trx);
                Ed.WriteLine(lt.ObjectId);
            }
        }
        #endregion
    }
}
