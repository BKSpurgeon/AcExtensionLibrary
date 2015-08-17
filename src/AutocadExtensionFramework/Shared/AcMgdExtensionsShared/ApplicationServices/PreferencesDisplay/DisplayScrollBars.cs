using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesDisplay
{
 
    public class DisplayScrollBars
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceDisplay
        {
            get { return Preferences.Display.DisplayScrollBars; }
            set { Preferences.Display.DisplayScrollBars = value; }
        }

        public DisplayScrollBars(object acadPreferences)
        {
            Preferences = acadPreferences;

        }

        public bool Display
        {
            get { return PreferenceDisplay; }
            set
            {

                PreferenceDisplay = value;
            }
        }

    }
}
