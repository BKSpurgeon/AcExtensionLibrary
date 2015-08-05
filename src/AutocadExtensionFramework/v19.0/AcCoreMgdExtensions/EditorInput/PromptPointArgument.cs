using Autodesk.AutoCAD.Geometry;

namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptPointArgument : AcedCmdArg<Point3d>
    {
        private PromptPointOptions _promptOptions;

        public PromptPointArgument(PromptPointOptions promptOptions)
        {

            _promptOptions = promptOptions;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptPointResult pr = ed.GetPoint(_promptOptions);
            if (pr.Status != PromptStatus.OK)
            {
                return pr.Status;
            }
            argumentValue = pr.Value;
            return base.Execute(ed);


        }
    }
}
