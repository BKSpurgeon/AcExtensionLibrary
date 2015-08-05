using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesUser
{
    public class SCMTimeValue
    {

        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferenceUser
        {
            get { return Preferences.User.SCMTimeValue; }
            set { Preferences.User.SCMTimeValue = value; }
        }

        public SCMTimeValue(object acadPreferences)
        {
            Preferences = acadPreferences;

        }

        public int TimeLength
        {
            get { return PreferenceUser; }
            set
            {
                if (value < 100)
                {
                    PreferenceUser = 100;
                }
                else if (value > 10000)
                {
                    PreferenceUser = 10000;
                }
                else
                {
                    PreferenceUser = value;
                }
               
            }
        }

    }
}
