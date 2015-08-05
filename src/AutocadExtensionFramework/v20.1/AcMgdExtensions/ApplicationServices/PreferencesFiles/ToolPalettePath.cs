using System;
using Autodesk.AutoCAD.ApplicationServices.PreferencesFiles;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
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

        private static string _defaultPath =
            Environment.ExpandEnvironmentVariables(@"%AppData%\Autodesk\AutoCAD 2016\R20.1\enu\Support\ToolPalette");
        public static string DefaultPath { get { return _defaultPath; } }
        //
    }
}
