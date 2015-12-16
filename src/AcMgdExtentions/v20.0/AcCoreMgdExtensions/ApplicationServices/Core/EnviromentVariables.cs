using Autodesk.AutoCAD.DatabaseServices;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Autodesk.AutoCAD.ApplicationServices.Core
{
    /// <summary>
    ///
    /// </summary>
    public static class EnviromentVariables
    {
        /// <summary>
        /// Aceds the set env.
        /// </summary>
        /// <param name="var">The variable.</param>
        /// <param name="val">The value.</param>
        /// <returns></returns>
        [DllImport("accore.dll", CallingConvention = CallingConvention.Cdecl,
       CharSet = CharSet.Auto, EntryPoint = "acedSetEnv")]
        extern static private Int32 acedSetEnv(string var, string val);

        /// <summary>
        /// Gets the enviroment variable.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        private static string GetEnviromentVariable([CallerMemberName] string name = "")
        {
            return HostApplicationServices.Current.GetEnvironmentVariable(name);
        }

        /// <summary>
        /// Sets the enviroment variable.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="name">The name.</param>
        private static void SetEnviromentVariable(string value, [CallerMemberName] string name = "")
        {
            acedSetEnv(name, value);
        }

        /// <summary>
        /// Gets or sets the acad.
        /// </summary>
        /// <value>
        /// The acad.
        /// </value>
        public static string ACAD
        {
            get { return GetEnviromentVariable(); }
            set { SetEnviromentVariable(value); }
        }

        /// <summary>
        /// Gets or sets the qnew template.
        /// </summary>
        /// <value>
        /// The qnew template.
        /// </value>
        public static string QnewTemplate
        {
            get { return GetEnviromentVariable(); }
            set { SetEnviromentVariable(value); }
        }
    }
}