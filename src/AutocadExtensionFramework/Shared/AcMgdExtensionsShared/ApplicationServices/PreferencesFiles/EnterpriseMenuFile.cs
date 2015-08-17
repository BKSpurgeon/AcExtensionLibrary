using System;
using System.IO;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    public class EnterpriseMenuFile
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceFile
        {
            get { return Preferences.Files.EnterpriseMenuFile; }
            set { Preferences.Files.EnterpriseMenuFile = value; }
        }

        public EnterpriseMenuFile(object acadPreferences)
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
                    PreferenceFile = ".";
                }
            }
        }
        
    }
}