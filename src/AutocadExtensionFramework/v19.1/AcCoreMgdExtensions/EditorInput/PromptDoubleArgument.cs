namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptDoubleArgument : AcedCmdArg<double>
    {
        private readonly PromptDoubleOptions _options;
        public PromptDoubleArgument(PromptDoubleOptions options)
        {
            _options = options;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptDoubleResult pdr = ed.GetDouble(_options);
            if (pdr.Status != PromptStatus.OK)
            {
                return pdr.Status;
            }
            argumentValue = pdr.Value;
            return base.Execute(ed);
        }
    }
}
