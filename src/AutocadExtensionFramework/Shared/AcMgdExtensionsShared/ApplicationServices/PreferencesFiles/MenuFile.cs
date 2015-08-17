using System;
using System.IO;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    public class MenuFile
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceFile
        {
            get { return Preferences.Files.MenuFile; }
            set { Preferences.Files.MenuFile = value; }
        }

        public MenuFile(object acadPreferences)
        {
            Preferences = acadPreferences;

        }

        public string Path
        {
            get { return PreferenceFile; }
            set
            {
                if (File.Exists(value) && System.IO.Path.GetExtension(value).Equals(".cuix", StringComparison.OrdinalIgnoreCase))
                {
                    PreferenceFile = value;
                }
                else
                {
                    PreferenceFile = Environment.ExpandEnvironmentVariables(@"%appdata%\Autodesk\AutoCAD 2016\R20.1\enu\support\acad");

                }
            }
        }

    }
}