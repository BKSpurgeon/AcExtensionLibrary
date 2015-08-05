using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
namespace Autodesk.AutoCAD.Runtime
{
    public interface ICommandClass 
    {
        Document Doc { get; }
        Database Db { get; }
        Editor Ed { get; }
    }
}
