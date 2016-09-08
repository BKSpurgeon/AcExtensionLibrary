using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using System;
using System.Runtime.CompilerServices;
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
        private static readonly SystemVariables _variables = new SystemVariables();

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
            private T GetSystemVariable<T>([CallerMemberName] string name = "")
            {
                return (T)this[name];
            }

            /// <summary>
            /// Sets the system variable.
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="value">The value.</param>
            /// <param name="name">The name.</param>
            private void SetSystemVariable<T>(T value, [CallerMemberName] string name = "")
            {
                this[name] = value;
            }

            /// <summary>
            /// Gets the bool system variable.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns></returns>
            private bool GetBoolSystemVariable([CallerMemberName] string name = "")
            {
                var val = (short)this[name];
                return val == 1;
            }

            /// <summary>
            /// Sets the bool system variable.
            /// </summary>
            /// <param name="value">if set to <c>true</c> [value].</param>
            /// <param name="name">The name.</param>
            private void SetBoolSystemVariable(bool value, [CallerMemberName] string name = "")
            {
                if (value)
                {
                    this[name] = 1;
                }
                else
                {
                    this[name] = 0;
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
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the cmleaderstyle.
            /// </summary>
            /// <value>
            /// The cmleaderstyle.
            /// </value>
            public string CMLEADERSTYLE
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the textstyle.
            /// </summary>
            /// <value>
            /// The textstyle.
            /// </value>
            public string TEXTSTYLE
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the dctcust.
            /// </summary>
            /// <value>
            /// The dctcust.
            /// </value>
            public string DCTCUST
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the clayer.
            /// </summary>
            /// <value>
            /// The clayer.
            /// </value>
            public string CLAYER
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
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
            /// Gets or sets the savetime.
            /// </summary>
            /// <value>
            /// The savetime.
            /// </value>
            public short SAVETIME
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the cvport.
            /// </summary>
            /// <value>
            /// The cvport.
            /// </value>
            public short CVPORT
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the startup.
            /// </summary>
            /// <value>
            /// The startup.
            /// </value>
            public short STARTUP
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is startmode.
            /// </summary>
            /// <value>
            ///   <c>true</c> if startmode; otherwise, <c>false</c>.
            /// </value>
            public bool STARTMODE
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is textallcaps.
            /// </summary>
            /// <value>
            ///   <c>true</c> if textallcaps; otherwise, <c>false</c>.
            /// </value>
            public bool TEXTALLCAPS
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the lwunits.
            /// </summary>
            /// <value>
            /// The lwunits.
            /// </value>
            public short LWUNITS
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the shortcutmenu.
            /// </summary>
            /// <value>
            /// The shortcutmenu.
            /// </value>
            public short SHORTCUTMENU
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the cursorsize.
            /// </summary>
            /// <value>
            /// The cursorsize.
            /// </value>
            public short CURSORSIZE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the aperture.
            /// </summary>
            /// <value>
            /// The aperture.
            /// </value>
            public short APERTURE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="SystemVariables"/> is dwgtitled.
            /// </summary>
            /// <value>
            ///   <c>true</c> if dwgtitled; otherwise, <c>false</c>.
            /// </value>
            public bool DWGTITLED
            {
                get { return GetBoolSystemVariable(); }
            }

            /// <summary>
            /// Gets a value indicating whether this <see cref="SystemVariables"/> is blockeditor.
            /// </summary>
            /// <value>
            ///   <c>true</c> if blockeditor; otherwise, <c>false</c>.
            /// </value>
            public bool BLOCKEDITOR
            {
                get { return GetBoolSystemVariable(); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is ucsfollow.
            /// </summary>
            /// <value>
            ///   <c>true</c> if ucsfollow; otherwise, <c>false</c>.
            /// </value>
            public bool UCSFOLLOW
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is nextfiberworld.
            /// </summary>
            /// <value>
            ///   <c>true</c> if nextfiberworld; otherwise, <c>false</c>.
            /// </value>
            public bool NEXTFIBERWORLD
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is filedia.
            /// </summary>
            /// <value>
            ///   <c>true</c> if filedia; otherwise, <c>false</c>.
            /// </value>
            public bool FILEDIA
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets the cmdnames.
            /// </summary>
            /// <value>
            /// The cmdnames.
            /// </value>
            public string CMDNAMES
            {
                get { return GetSystemVariable<string>(); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is attdia.
            /// </summary>
            /// <value>
            ///   <c>true</c> if attdia; otherwise, <c>false</c>.
            /// </value>
            public bool ATTDIA
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is attreq.
            /// </summary>
            /// <value>
            ///   <c>true</c> if attreq; otherwise, <c>false</c>.
            /// </value>
            public bool ATTREQ
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is wsautosave.
            /// </summary>
            /// <value>
            ///   <c>true</c> if wsautosave; otherwise, <c>false</c>.
            /// </value>
            public bool WSAUTOSAVE
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the ctab.
            /// </summary>
            /// <value>
            /// The ctab.
            /// </value>
            public string CTAB
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the mleaderscale.
            /// </summary>
            /// <value>
            /// The mleaderscale.
            /// </value>
            public double MLEADERSCALE
            {
                get { return GetSystemVariable<double>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the textsize.
            /// </summary>
            /// <value>
            /// The textsize.
            /// </value>
            public double TEXTSIZE
            {
                get { return GetSystemVariable<double>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the osmode.
            /// </summary>
            /// <value>
            /// The osmode.
            /// </value>
            public OsnapMode OSMODE
            {
                get { return GetSystemVariable<OsnapMode>(); }
                set { SetSystemVariable<short>((short)value); }
            }

            /// <summary>
            /// Gets or sets the insunits.
            /// </summary>
            /// <value>
            /// The insunits.
            /// </value>
            public UnitsValue INSUNITS
            {
                get { return GetSystemVariable<UnitsValue>(); }
                set { SetSystemVariable<short>((short)value); }
            }

            /// <summary>
            /// Gets the dwgname.
            /// </summary>
            /// <value>
            /// The dwgname.
            /// </value>
            public string DWGNAME
            {
                get { return GetSystemVariable<string>(); }
            }

            /// <summary>
            /// Gets the dwgprefix.
            /// </summary>
            /// <value>
            /// The dwgprefix.
            /// </value>
            public string DWGPREFIX
            {
                get { return GetSystemVariable<string>(); }
            }

            /// <summary>
            /// Gets the menuname.
            /// </summary>
            /// <value>
            /// The menuname.
            /// </value>
            public string MENUNAME
            {
                get { return GetSystemVariable<string>(); }
            }
            /// <summary>
            /// Gets or sets the LUPREC.
            /// </summary>
            /// <value>
            /// The LUPREC.
            /// </value>
            public short LUPREC
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            /// <summary>
            /// Gets or sets a value indicating whether this <see cref="SystemVariables"/> is cmdecho.
            /// </summary>
            /// <value>
            ///   <c>true</c> if cmdecho; otherwise, <c>false</c>.
            /// </value>
            public bool CMDECHO
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the pickstyle.
            /// </summary>
            /// <value>
            /// The pickstyle.
            /// </value>
            public short PICKSTYLE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            /// <summary>
            /// Gets or sets the groupdisplaymode.
            /// </summary>
            /// <value>
            /// The groupdisplaymode.
            /// </value>
            public short GROUPDISPLAYMODE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
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