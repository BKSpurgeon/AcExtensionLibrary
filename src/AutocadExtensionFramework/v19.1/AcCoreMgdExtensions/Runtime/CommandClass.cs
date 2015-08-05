using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
namespace Autodesk.AutoCAD.Runtime
{
    /// <summary>
    /// Just refactored into own class from
    /// Author: Kerry Brown
    /// Source: http://www.theswamp.org/index.php?topic=37686.msg427172#msg427172
    /// </summary>
    public abstract class CommandClass : ICommandClass
    {
        public Document Doc { get; private set; }
        public Database Db { get; private set; }
        public Editor Ed { get; private set; }

        public CommandClass()
        {
            Doc = Application.DocumentManager.MdiActiveDocument;
            Db = Doc.Database;
            Ed = Doc.Editor;
        }



    }
}
