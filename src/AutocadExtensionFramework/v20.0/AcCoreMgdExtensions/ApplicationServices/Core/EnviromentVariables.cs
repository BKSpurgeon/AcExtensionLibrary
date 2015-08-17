using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.ApplicationServices.Core
{


   public static class EnviromentVariables
   {
       [DllImport("accore.dll", CallingConvention = CallingConvention.Cdecl,
       CharSet = CharSet.Auto, EntryPoint = "acedSetEnv")]
       extern static private Int32 acedSetEnv(string var, string val);

       private static string GetEnviromentVariable([CallerMemberName] string name = "")
       {
           return HostApplicationServices.Current.GetEnvironmentVariable(name);
       }
       private static void SetEnviromentVariable(string value, [CallerMemberName] string name = "")
        {
            acedSetEnv(name, value);
        }

       public static string ACAD
       {
           get { return GetEnviromentVariable(); }
           set { SetEnviromentVariable(value); }
       }

       public static string QnewTemplate
       {
           get { return GetEnviromentVariable(); }
           set { SetEnviromentVariable(value); }
       }
    }
}
