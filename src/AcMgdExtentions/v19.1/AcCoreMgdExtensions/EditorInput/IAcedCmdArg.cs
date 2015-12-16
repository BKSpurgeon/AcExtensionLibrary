using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.EditorInput
{


    public interface IAcedCmdArg : IAcedCmd
    {
        //PromptStatus Send(Editor ed);
        //string Message { get; }
        TypedValue TypedValue { get; }
    }

    public interface IAcedCmdArg<out T> : IAcedCmdArg
    {
        T ResultValue { get; }
    }






}
