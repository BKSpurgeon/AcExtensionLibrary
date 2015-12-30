using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;

[assembly: CommandClass(typeof(Samplescsharp.AcDbMgdExtensions.DatabaseServices.BlockTableRecordExtensionsCommands))]
namespace Samplescsharp.AcDbMgdExtensions.DatabaseServices
{
    public class BlockTableRecordExtensionsCommands : CommandClass
    {

    }
}
