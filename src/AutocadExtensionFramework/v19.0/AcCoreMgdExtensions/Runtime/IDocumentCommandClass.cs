using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.Runtime
{
    interface IDocumentCommandClass : ICommandClass
    {

    }

    public abstract class DocumentCommandClass : CommandClass, IDocumentCommandClass
    {


    }
}
