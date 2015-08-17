namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    
    public class PrinterStyleSheetPath : SupportPath
    {
        public PrinterStyleSheetPath(object acadPreferences)
            : base(acadPreferences)
        {
        }
        protected override dynamic PreferencesFile
        {
            get { return Preferences.Files.PrinterStyleSheetPath; }
            set { Preferences.Files.PrinterStyleSheetPath = value; }
        }
    }
}
