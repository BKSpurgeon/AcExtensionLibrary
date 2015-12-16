namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptStringArgument : AcedCmdArg<string>
    {
        private PromptStringOptions _promptOptions;

        public PromptStringArgument(PromptStringOptions promptOptions)
        {
            _promptOptions = promptOptions;
        }


        public override PromptStatus Execute(Editor ed)
        {

            PromptResult pr = ed.GetString(_promptOptions);
            if (pr.Status != PromptStatus.OK)
            {
                return pr.Status;
            }
            argumentValue = pr.StringResult;
            return base.Execute(ed);


        }
    }
}
