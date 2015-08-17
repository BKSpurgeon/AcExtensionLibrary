using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptSelectionArgument : AcedCmdArg<SelectionSet>
    {
        private PromptSelectionOptions _promptOptions;

        public PromptSelectionArgument(PromptSelectionOptions promptOptions)
        {

            _promptOptions = promptOptions;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptSelectionResult pr = ed.GetSelection(_promptOptions);
            if (pr.Status != PromptStatus.OK)
            {
                return pr.Status;
            }
            argumentValue = pr.Value;
            return base.Execute(ed);


        }
    }
}
