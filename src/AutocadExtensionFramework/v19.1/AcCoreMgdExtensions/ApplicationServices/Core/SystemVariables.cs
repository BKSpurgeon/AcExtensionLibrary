using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace Autodesk.AutoCAD.ApplicationServices.Core
{
    /// <summary>
    ///
    /// </summary>
    public partial class Settings
    {
        /// <summary>
        /// The _variables
        /// </summary>
        private static SystemVariables _variables = new SystemVariables();

        /// <summary>
        /// Gets the variables.
        /// </summary>
        /// <value>
        /// The variables.
        /// </value>
        public static SystemVariables Variables { get { return _variables; } }

        /// <summary>
        ///
        /// </summary>
        public class SystemVariables
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SystemVariables"/> class.
            /// </summary>
            internal SystemVariables()
            {
            }

            /// <summary>
            /// Gets the system variable.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="name">The name.</param>
            /// <returns></returns>
            /// Would be nice to just let the name of the method be passed, and with .NET 4.5 a easy way
            /// would be with [CallerMemberName] attribute
            /// http://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.callermembernameattribute.aspx
            /// Requires .NET 4.5
            ////private T GetSystemVariable<T>([CallerMemberName] string name = null)
            ////{
            ////    return (T)this[name];
            ////}

            private T GetSystemVariable<T>(string name)
            {
                return (T)this[name];
            }

            /// <summary>
            /// Sets the system variable.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="name">The name.</param>
            /// <param name="value">The value.</param>
            private void SetSystemVariable<T>(string name, T value)
            {
                this[name] = value;
            }

            /// <summary>
            /// Gets the bool system variable.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns></returns>
            private bool GetBoolSystemVariable(string name)
            {
                short val = GetSystemVariable<short>(name);
                if (val == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Sets the bool system variable.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <param name="value">if set to <c>true</c> [value].</param>
            private void SetBoolSystemVariable(string name, bool value)
            {
                if (value)
                {
                    SetSystemVariable<short>(name, 1);
                }
                else
                {
                    SetSystemVariable<short>(name, 0);
                }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is texteval.
            /// </summary>
            /// <value>
            ///   <c>true</c> if texteval; otherwise, <c>false</c>.
            /// </value>
            public bool TEXTEVAL
            {
                get { return GetBoolSystemVariable("TEXTEVAL"); }
                set { SetBoolSystemVariable("TEXTEVAL", value); }
            }

            /// <summary>
            /// Gets or sets the clayer.
            /// </summary>
            /// <value>
            /// The clayer.
            /// </value>
            public string CLAYER
            {
                get { return GetSystemVariable<string>("CLAYER"); }
                set { SetSystemVariable<string>("CLAYER", value); }
            }

            /// <summary>
            /// Gets or sets the clayerid.
            /// </summary>
            /// <value>
            /// The clayerid.
            /// </value>
            public ObjectId CLAYERID
            {
                get { return HostApplicationServices.WorkingDatabase.Clayer; }
                set { HostApplicationServices.WorkingDatabase.Clayer = value; }
            }

            /// <summary>
            /// Gets or sets the cvport.
            /// </summary>
            /// <value>
            /// The cvport.
            /// </value>
            public short CVPORT
            {
                get { return GetSystemVariable<short>("CVPORT"); }
                set { SetSystemVariable<short>("CVPORT", value); }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="SystemVariables"/> is dwgtitled.
            /// </summary>
            /// <value>
            ///   <c>true</c> if dwgtitled; otherwise, <c>false</c>.
            /// </value>
            public bool DWGTITLED
            {
                get { return GetBoolSystemVariable("DWGTITLED"); }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="SystemVariables"/> is blockeditor.
            /// </summary>
            /// <value>
            ///   <c>true</c> if blockeditor; otherwise, <c>false</c>.
            /// </value>
            public bool BLOCKEDITOR
            {
                get { return GetBoolSystemVariable("BLOCKEDITOR"); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is ucsfollow.
            /// </summary>
            /// <value>
            ///   <c>true</c> if ucsfollow; otherwise, <c>false</c>.
            /// </value>
            public bool UCSFOLLOW
            {
                get { return GetBoolSystemVariable("UCSFOLLOW"); }
                set { SetBoolSystemVariable("UCSFOLLOW", value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is nextfiberworld.
            /// </summary>
            /// <value>
            ///   <c>true</c> if nextfiberworld; otherwise, <c>false</c>.
            /// </value>
            public bool NEXTFIBERWORLD
            {
                get { return GetBoolSystemVariable("NEXTFIBERWORLD"); }
                set { SetBoolSystemVariable("NEXTFIBERWORLD", value); }
            }

            /// <summary>
            /// Gets the cmdnames.
            /// </summary>
            /// <value>
            /// The cmdnames.
            /// </value>
            public string CMDNAMES
            {
                get { return GetSystemVariable<string>("CMDNAMES"); }
            }

            ///////  Think commands can have '(apostrophe) in them and would cause problem
            //           public ICollection<string> CMDNAMES
            //           {
            //               get { return GetSystemVariable<string>("CMDNAMES").Split('\''); }
            //           }

            /// <summary>
            /// Gets or sets the ctab.
            /// </summary>
            /// <value>
            /// The ctab.
            /// </value>
            public string CTAB
            {
                get { return GetSystemVariable<string>("CTAB"); }
                set { SetSystemVariable<string>("CTAB", value); }
            }

            /// <summary>
            /// Gets or sets the osmode.
            /// </summary>
            /// <value>
            /// The osmode.
            /// </value>
            public OsnapMode OSMODE
            {
                get { return GetSystemVariable<OsnapMode>("OSMODE"); }
                set { SetSystemVariable<short>("OSMODE", (short)value); }
            }

            /// <summary>
            /// Gets the dwgname.
            /// </summary>
            /// <value>
            /// The dwgname.
            /// </value>
            public string DWGNAME
            {
                get { return GetSystemVariable<string>("DWGNAME"); }
            }

            /// <summary>
            /// Gets the dwgprefix.
            /// </summary>
            /// <value>
            /// The dwgprefix.
            /// </value>
            public string DWGPREFIX
            {
                get { return GetSystemVariable<string>("DWGPREFIX"); }
            }

            /// <summary>
            /// Gets the menuname.
            /// </summary>
            /// <value>
            /// The menuname.
            /// </value>
            public string MENUNAME
            {
                get { return GetSystemVariable<string>("MENUNAME"); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is cmdecho.
            /// </summary>
            /// <value>
            ///   <c>true</c> if cmdecho; otherwise, <c>false</c>.
            /// </value>
            public bool CMDECHO
            {
                get { return GetBoolSystemVariable("CMDECHO"); }
                set { SetBoolSystemVariable("CMDECHO", value); }
            }

            /// <summary>
            /// Gets or sets the <see cref="System.Object"/> with the specified name.
            /// </summary>
            /// <value>
            /// The <see cref="System.Object"/>.
            /// </value>
            /// <param name="name">The name.</param>
            /// <returns></returns>
            /// <exception cref="System.ArgumentNullException">{0} is Empty or Null</exception>
            /// <exception cref="System.ArgumentException">
            /// InvalidName
            /// or
            /// </exception>
            public virtual object this[string name]
            {
                get
                {
                    if (name.IsNullOrWhiteSpace())
                    {
                        throw new ArgumentNullException("{0} is Empty or Null", name);
                    }
                    try
                    {
                        return Application.GetSystemVariable(name);
                    }
                    catch (Exception ex)
                    {
                        if (ex.ErrorStatus == ErrorStatus.InvalidInput)
                        {
                            throw new ArgumentException("InvalidName", name);
                        }
                        else
                        {
                            throw;
                        }
                    }
                }

                set
                {
                    try
                    {
                        Application.SetSystemVariable(name, value);
                    }
                    catch (Exception ex)
                    {
                        if (ex.ErrorStatus == ErrorStatus.InvalidInput)
                        {
                            throw new ArgumentException(String.Format("{0}:{1} is Invalid", name, value));
                        }
                        throw;
                    }
                }
            }
        }
    }
}