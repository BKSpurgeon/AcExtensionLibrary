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


        /// <summary>
        /// Method inserting multiple blockreferences until users presses escape
        /// </summary>
        //[CommandMethod("MBI")]
        //public void MBI()
        //{
        //    PromptStringOptions pso = new PromptStringOptions("\nBlockName");
        //    pso.AllowSpaces = true;
        //    PromptResult pr = Ed.GetString(pso);

        //    if (pr.Status != PromptStatus.OK)
        //    {
        //        return;
        //    }

        //    ScriptCommand cmd = new ScriptCommand("_.-INSERT", pr.StringResult);
        //    cmd.WaitForExit = true;

        //    PromptStatus ps = PromptStatus.OK;

        //    while (!HostApplicationServices.SystemVariables.UserBreak() && ps == PromptStatus.OK)
        //    {
        //        ps = cmd.Run();
        //    }
        //}
        [CommandMethod("creatAnonymGroup")]

        public void creatAnonymGroup()
        {
            PromptSelectionResult result = Ed.GetSelection();
            if (result.Status != PromptStatus.OK)
                return;
            
            //using (Transaction Tx =Db.TransactionManager.StartTransaction())
            //{
                GroupDictionary groupDic = Db.GroupDictionary(OpenMode.ForWrite);
                Group anonyGroup = new Group();
                groupDic.SetAt("*", anonyGroup);

                foreach (SelectedObject acSSObj in result.Value)
                {
                    anonyGroup.Append(acSSObj.ObjectId);
                }

                //groupDic

            //    Tx.AddNewlyCreatedDBObject(anonyGroup, true);



            //    Tx.Commit();

            //}

        }
        static LayerTableOverrule lto = new LayerTableOverrule();
        [CommandMethod("LTROverrule")]
        public void layerTableOverrule()
        {
            Overrule.AddOverrule(RXClass.GetClass(typeof(LayerTableRecord)), lto, true);
        }
    }
    public class LayerTableOverrule : ObjectOverrule
    {
        StreamWriter sw;
        public LayerTableOverrule()
        {
            sw = new StreamWriter(@"C:\Users\Will\Desktop\Test.txt", false);
            Application.DocumentManager.DocumentCreated += DocumentManager_DocumentCreated;
        }

        void DocumentManager_DocumentCreated(object sender, DocumentCollectionEventArgs e)
        {
            sw.WriteLine(string.Format("Opening: {0}", e.Document.Name));
        }
        RXClass rxc = RXClass.GetClass(typeof(LayerTableRecord));
        public override void Open(DBObject dbObject, OpenMode mode)
        {
            LayerTableRecord ltr = dbObject as LayerTableRecord;
            if (ltr != null)
            {
                sw.WriteLine(string.Format("Opening {0}", ltr.Name));
            }
            base.Open(dbObject, mode);
        }
    }

}
