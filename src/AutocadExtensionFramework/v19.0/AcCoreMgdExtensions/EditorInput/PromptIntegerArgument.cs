namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptIntegerArgument : AcedCmdArg<int>
    {
        private PromptIntegerOptions _promptOptions;

        public PromptIntegerArgument(PromptIntegerOptions promptOptions)
        {

            _promptOptions = promptOptions;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptIntegerResult pr = ed.GetInteger(_promptOptions);
            if (pr.Status != PromptStatus.OK)
            {
                return pr.Status;
            }
            argumentValue = pr.Value;
            return base.Execute(ed);


        }
    }
}
