namespace Autodesk.AutoCAD.EditorInput
{
    public interface IAcedCmd
    {
        PromptStatus Execute(Editor ed);
    }
}