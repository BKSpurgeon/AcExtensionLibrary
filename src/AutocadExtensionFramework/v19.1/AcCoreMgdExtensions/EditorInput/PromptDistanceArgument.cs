namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptDistanceArgument : AcedCmdArg<double>
    {
        private readonly PromptDistanceOptions _options;
        public PromptDistanceArgument(PromptDistanceOptions options)
        {
            _options = options;
        }

        public override PromptStatus Execute(Editor ed)
        {

            PromptDoubleResult pdr = ed.GetDistance(_options);
            if (pdr.Status != PromptStatus.OK)
            {
                return pdr.Status;
            }
            argumentValue = pdr.Value;
            return base.Execute(ed);
        }
    }
}
