namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    public class PrinterDescPath : SupportPath
    {
        public PrinterDescPath(object acadPreferences)
            : base(acadPreferences)
        {
        }
        protected override dynamic PreferencesFile
        {
            get { return Preferences.Files.PrinterDescPath; }
            set { Preferences.Files.PrinterDescPath = value; }
        }
    }
}
