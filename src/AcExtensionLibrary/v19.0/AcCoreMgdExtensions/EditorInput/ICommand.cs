using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.EditorInput
{
    public interface ICommand
    {
        PromptStatus Run();
    }
}
