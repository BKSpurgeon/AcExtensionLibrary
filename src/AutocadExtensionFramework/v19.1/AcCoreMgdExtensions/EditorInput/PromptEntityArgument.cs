using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptEntityArgument : AcedCmdArg<ObjectId>
    {
        private readonly PromptEntityOptions _options;
        public PromptEntityArgument(PromptEntityOptions options)
        {
            _options = options;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptEntityResult per = ed.GetEntity(_options);
            if (per.Status != PromptStatus.OK)
            {
                return per.Status;
            }
            argumentValue = per.ObjectId;
            return base.Execute(ed);
        }
    }
}
