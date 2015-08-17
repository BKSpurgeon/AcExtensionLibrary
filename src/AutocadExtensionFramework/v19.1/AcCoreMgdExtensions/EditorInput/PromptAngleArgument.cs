using System;
using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.EditorInput
{
    public class PromptAngleArgument : PromptArgument<PromptAngleOptions, PromptDoubleResult>
    {
        public PromptAngleArgument(PromptAngleOptions options) : base(options)
        {
        }

        public override TypedValue TypedValue
        {
            get { throw new System.NotImplementedException(); }
        }



        public override Func<PromptAngleOptions, PromptDoubleResult> PromptForArgument(Editor ed)
        {
            return ed.GetAngle;
        }
    }

    //public class PromptAngleArgument : PromptArgument<PromptAngleOptions, PromptDoubleResult>
    //{
    //    public PromptAngleArgument(PromptAngleOptions options) : base(options)
    //    {
    //    }

    //    public override PromptDoubleResult Value
    //    {
    //        get { throw new System.NotImplementedException(); }
    //    }



    //    protected override PromptStatus GetResult(Editor ed)
    //    {
    //        ResultBuffer rb = AcedCmdResultBuffer.CreateBuffer(Value.Value);
    //        return AcedCmd.SendBuffer(ed, rb);
    //    }

    //    protected override PromptDoubleResult GetValue(Editor ed)
    //    {
    //        return ed.GetAngle(Options);
    //    }
    //}
}
