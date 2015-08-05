namespace Autodesk.AutoCAD.ApplicationServices
{
    public class ToolPalettePath : SupportPath
    {
        public ToolPalettePath(object acadPreferences) : base(acadPreferences)
        {
        }
        protected override dynamic PreferencesFile
        {
            get { return Preferences.Files.ToolPalettePath; }
            set { Preferences.Files.ToolPalettePath = value; }
        }
    }
}
