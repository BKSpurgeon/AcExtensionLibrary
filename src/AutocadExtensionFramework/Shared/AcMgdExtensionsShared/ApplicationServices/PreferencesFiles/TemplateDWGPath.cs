namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    public class TemplateDWGPath 
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceFile
        {
            get { return Preferences.Files.TemplateDWGPath; }
            set { Preferences.Files.TemplateDWGPath = value; }
        }

        public TemplateDWGPath(object acadPreferences)
        {
            Preferences = acadPreferences;
        
        }

        public string Path
        {
            get { return PreferenceFile; }
            set { PreferenceFile = value; }
        }
 
    }

    //%appdata%\Autodesk\AutoCAD 2016\R20.1\enu\support\acad

    //%appdata%\Autodesk\AutoCAD 2016\R20.1\enu\support\acad
}

