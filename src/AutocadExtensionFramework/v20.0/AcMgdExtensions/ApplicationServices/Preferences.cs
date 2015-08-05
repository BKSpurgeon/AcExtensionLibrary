namespace Autodesk.AutoCAD.ApplicationServices
{
    public static class Preferences
    {
        static dynamic AcadPreferences { get { return Application.Preferences; } }

        public static SupportPath SupportPaths { get { return new SupportPath(AcadPreferences); } }
        public static ToolPalettePath ToolPalettePaths { get { return new ToolPalettePath(AcadPreferences); } }
    }
}
