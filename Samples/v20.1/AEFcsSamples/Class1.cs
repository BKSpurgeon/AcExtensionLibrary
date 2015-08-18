using System.Linq;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;
using System.IO;

namespace AEFcsSamples
{
    public class TestCommands : CommandClass
    {
        /// <summary>
        /// Command for printing layers
        /// </summary>
        [CommandMethod("PrintLayers")]
        public void PrintLayers()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                LayerTable lt = Db.LayerTable();
                var layers = lt.GetLayerTableRecords().Names();
                Ed.WriteLine(layers);
                trx.Commit();
            }
        }
        /// <summary>
        /// Command for printing Blocks
        /// </summary>
        [CommandMethod("PrintBlocks")]
        public void PrintBlocks()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTable bt = Db.BlockTable();
                var blocks = bt.GetBlockTableRecords().Names();
                Ed.WriteLine(blocks);
                trx.Commit();
            }
        }



        /// <summary>
        /// Command for printing Groups and uses a class that wraps a DBDictionary for GroupDictionary
        /// </summary>
        [CommandMethod("PrintGroups")]
        public void PrintGroups()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                GroupDictionary grpDic = Db.GroupDictionary();
                foreach (Group grp in grpDic)
                {
                    Ed.WriteLine(grp.Name);
                }

                trx.Commit();
            }
        }

        /// <summary>
        /// Just uses extension methods unlike above
        /// </summary>
        [CommandMethod("PrintGroups2")]
        public void PrintGroups2()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                DBDictionary grpDic = Db.GroupDBDictionary();

                var groups = grpDic.GetEntries<Group>();
                foreach (Group grp in groups)
                {
                    Ed.WriteLine(grp.Name);
                }

                trx.Commit();
            }
        }

        /// <summary>
        /// Print line length for each line
        /// </summary>
        [CommandMethod("PrintLinesLength")]
        public void PrintLinesLength()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTableRecord model = Db.ModelSpace();
                var lines = model.GetEntities<Line>();
                foreach (Line line in lines)
                {
                    Ed.WriteLine(line.Length);
                }
                trx.Commit();

            }
        }

        /// <summary>
        /// Get total length of all lines in model space
        /// </summary>
        [CommandMethod("PrintTotalLinesLength")]
        public void PrintTotalLinesLength()
        {
            using (Transaction trx = Db.TransactionManager.StartTransaction())
            {
                BlockTableRecord model = Db.ModelSpace();
                var linesLength = model.GetEntities<Line>().Sum(l => l.Length);
                Ed.WriteLine(linesLength);
                trx.Commit();

            }
        }


       
       
    }
   

}
