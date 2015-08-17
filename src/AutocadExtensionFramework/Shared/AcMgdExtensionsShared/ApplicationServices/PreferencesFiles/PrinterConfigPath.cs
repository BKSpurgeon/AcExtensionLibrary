namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    public class PrinterConfigPath : SupportPath
    {
        public PrinterConfigPath(object acadPreferences)
            : base(acadPreferences)
        {
        }
        protected override dynamic PreferencesFile
        {
            get { return Preferences.Files.PrinterConfigPath; }
            set { Preferences.Files.PrinterConfigPath = value; }
        }
    }
}
