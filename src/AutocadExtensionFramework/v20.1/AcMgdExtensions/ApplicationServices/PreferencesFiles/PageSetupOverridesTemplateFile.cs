namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    
    public class PageSetupOverridesTemplateFile 
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceFile
        {
            get { return Preferences.Files.PageSetupOverridesTemplateFile; }
            set { Preferences.Files.PageSetupOverridesTemplateFile = value; }
        }

        public PageSetupOverridesTemplateFile(object acadPreferences)
        {
            Preferences = acadPreferences;
        
        }

        public string Path
        {
            get { return PreferenceFile; }
            set { PreferenceFile = value; }
        }
 
    }

       public class QNewTemplateFile 
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceFile
        {
            get { return Preferences.Files.QNewTemplateFile; }
            set { Preferences.Files.QNewTemplateFile = value; }
        }

        public QNewTemplateFile(object acadPreferences)
        {
            Preferences = acadPreferences;
        
        }

        public string Path
        {
            get { return PreferenceFile; }
            set { PreferenceFile = value; }
        }
 
    }
}