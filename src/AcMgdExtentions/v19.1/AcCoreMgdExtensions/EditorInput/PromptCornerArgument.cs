using Autodesk.AutoCAD.Geometry;

namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptCornerArgument : AcedCmdArg<Point3d>
    {
        private PromptCornerOptions _promptOptions;

        public PromptCornerArgument(PromptCornerOptions promptOptions)
        {

            _promptOptions = promptOptions;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptPointResult pr = ed.GetCorner(_promptOptions);
            if (pr.Status != PromptStatus.OK)
            {
                return pr.Status;
            }
            argumentValue = pr.Value;
            return base.Execute(ed);


        }
    }
}
