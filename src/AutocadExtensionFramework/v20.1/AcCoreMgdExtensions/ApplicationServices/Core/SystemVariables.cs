using System;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Runtime;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace Autodesk.AutoCAD.ApplicationServices.Core
{
    public partial class Settings
    {
        private static readonly SystemVariables _variables = new SystemVariables();
        public static SystemVariables Variables { get { return _variables; } }

        public class SystemVariables
        {
            internal SystemVariables()
            {

            }

            private T GetSystemVariable<T>([CallerMemberName] string name = "")
            {
                return (T)this[name];
            }
            private void SetSystemVariable<T>(T value, [CallerMemberName] string name = "")
            {
                this[name] = value;
            }

            private bool GetBoolSystemVariable([CallerMemberName] string name = "")
            {
                var val = (short)this[name];
                return val == 1;
                
            }
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

            public bool TEXTEVAL
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            public string CMLEADERSTYLE
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            public string TEXTSTYLE
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            public string DCTCUST
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }
            public string CLAYER
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }
            public ObjectId CLAYERID
            {
                get { return HostApplicationServices.WorkingDatabase.Clayer; }
                set { HostApplicationServices.WorkingDatabase.Clayer = value; }
            }

            public short SAVETIME
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            public short CVPORT
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            public short STARTUP
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }

            public bool STARTMODE
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
            public bool TEXTALLCAPS
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            public short LWUNITS
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            public short SHORTCUTMENU
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            public short CURSORSIZE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            public short APERTURE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            public bool DWGTITLED
            {
                get { return GetBoolSystemVariable(); }
            }
            
            public bool BLOCKEDITOR
            {
                get { return GetBoolSystemVariable(); }
            }

            public bool UCSFOLLOW
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
            public bool NEXTFIBERWORLD
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
            public bool FILEDIA
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
            public string CMDNAMES
            {
                get { return GetSystemVariable<string>(); }
            }


            public bool ATTDIA
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
        
            
            public bool ATTREQ
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
            public bool WSAUTOSAVE
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }
            public string CTAB
            {
                get { return GetSystemVariable<string>(); }
                set { SetSystemVariable(value); }
            }

            public double MLEADERSCALE
            {
                get { return GetSystemVariable<double>(); }
                set { SetSystemVariable(value); }
            }
            public double TEXTSIZE
            {
                get { return GetSystemVariable<double>(); }
                set { SetSystemVariable(value); }
            }

            public OsnapMode OSMODE
            {
                get { return GetSystemVariable<OsnapMode>(); }
                set { SetSystemVariable<short>((short)value); }
            }
            public UnitsValue INSUNITS 
            {
                get { return GetSystemVariable<UnitsValue>(); }
                set { SetSystemVariable<short>((short)value); }
            }
            public string DWGNAME
            {
                get { return GetSystemVariable<string>(); }
            }
            public string DWGPREFIX
            {
                get { return GetSystemVariable<string>(); }
            }
            public string MENUNAME
            {
                get { return GetSystemVariable<string>(); }
            }
            public bool CMDECHO
            {
                get { return GetBoolSystemVariable(); }
                set { SetBoolSystemVariable(value); }
            }

            public short PICKSTYLE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }
            public short GROUPDISPLAYMODE
            {
                get { return GetSystemVariable<short>(); }
                set { SetSystemVariable(value); }
            }


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
//public class SystemVariables
//{
//    internal SystemVariables()
//    {

//    }
//    /// Would be nice to just let the name of the method be passed, and with .NET 4.5 a easy way
//    /// would be with [CallerMemberName] attribute
//    /// http://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.callermembernameattribute.aspx
//    /// Requires .NET 4.5
//    ////private T GetSystemVariable<T>([CallerMemberName] string name = null)
//    ////{
//    ////    return (T)this[name];
//    ////}

//    private T GetSystemVariable<T>(string name)
//    {
//        return (T)this[name];
//    }
//    private void SetSystemVariable<T>(string name, T value)
//    {
//        this[name] = value;
//    }

//    private bool GetBoolSystemVariable(string name)
//    {
//        short val = GetSystemVariable<short>(name);
//        if (val == 1)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }

//    }
//    private void SetBoolSystemVariable(string name, bool value)
//    {
//        if (value)
//        {
//            SetSystemVariable<short>(name, 1);
//        }
//        else
//        {
//            SetSystemVariable<short>(name, 0);
//        }
//    }

//    public bool TEXTEVAL
//    {
//        get { return GetBoolSystemVariable("TEXTEVAL"); }
//        set { SetBoolSystemVariable("TEXTEVAL", value); }
//    }
//    public string CLAYER
//    {
//        get { return GetSystemVariable<string>("CLAYER"); }
//        set { SetSystemVariable<string>("CLAYER", value); }
//    }
//    public ObjectId CLAYERID
//    {
//        get { return HostApplicationServices.WorkingDatabase.Clayer; }
//        set { HostApplicationServices.WorkingDatabase.Clayer = value; }
//    }
//    public short CVPORT
//    {
//        get { return GetSystemVariable<short>("CVPORT"); }
//        set { SetSystemVariable<short>("CVPORT", value); }
//    }

//    public short APERTURE
//    {
//        get { return GetSystemVariable<short>("APERTURE"); }
//        set { SetSystemVariable<short>("APERTURE", value); }
//    }
//    public bool DWGTITLED
//    {
//        get { return GetBoolSystemVariable("DWGTITLED"); }
//    }

//    public bool BLOCKEDITOR
//    {
//        get { return GetBoolSystemVariable("BLOCKEDITOR"); }
//    }

//    public bool UCSFOLLOW
//    {
//        get { return GetBoolSystemVariable("UCSFOLLOW"); }
//        set { SetBoolSystemVariable("UCSFOLLOW", value); }
//    }
//    public bool NEXTFIBERWORLD
//    {
//        get { return GetBoolSystemVariable("NEXTFIBERWORLD"); }
//        set { SetBoolSystemVariable("NEXTFIBERWORLD", value); }
//    }
//    public bool FILEDIA
//    {
//        get { return GetBoolSystemVariable("FILEDIA"); }
//        set { SetBoolSystemVariable("FILEDIA", value); }
//    }
//    public string CMDNAMES
//    {
//        get { return GetSystemVariable<string>("CMDNAMES"); }
//    }

//    ///////  Think commands can have '(apostrophe) in them and would cause problem
//    //           public ICollection<string> CMDNAMES
//    //           {
//    //               get { return GetSystemVariable<string>("CMDNAMES").Split('\''); }
//    //           }

//    public string CTAB
//    {
//        get { return GetSystemVariable<string>("CTAB"); }
//        set { SetSystemVariable<string>("CTAB", value); }
//    }
//    public OsnapMode OSMODE
//    {
//        get { return GetSystemVariable<OsnapMode>("OSMODE"); }
//        set { SetSystemVariable<short>("OSMODE", (short)value); }
//    }
//    public UnitsValue INSUNITS
//    {
//        get { return GetSystemVariable<UnitsValue>("INSUNITS"); }
//        set { SetSystemVariable<short>("INSUNITS", (short)value); }
//    }
//    public string DWGNAME
//    {
//        get { return GetSystemVariable<string>("DWGNAME"); }
//    }
//    public string DWGPREFIX
//    {
//        get { return GetSystemVariable<string>("DWGPREFIX"); }
//    }
//    public string MENUNAME
//    {
//        get { return GetSystemVariable<string>("MENUNAME"); }
//    }
//    public bool CMDECHO
//    {
//        get { return GetBoolSystemVariable("CMDECHO"); }
//        set { SetBoolSystemVariable("CMDECHO", value); }
//    }

//    public virtual object this[string name]
//    {
//        get
//        {
//            if (name.IsNullOrWhiteSpace())
//            {
//                throw new ArgumentNullException("{0} is Empty or Null", name);
//            }
//            try
//            {
//                return Application.GetSystemVariable(name);
//            }

//            catch (Exception ex)
//            {
//                if (ex.ErrorStatus == ErrorStatus.InvalidInput)
//                {
//                    throw new ArgumentException("InvalidName", name);
//                }
//                else
//                {
//                    throw;
//                }
//            }
//        }

//        set
//        {
//            try
//            {
//                Application.SetSystemVariable(name, value);
//            }

//            catch (Exception ex)
//            {
//                if (ex.ErrorStatus == ErrorStatus.InvalidInput)
//                {
//                    throw new ArgumentException(String.Format("{0}:{1} is Invalid", name, value));
//                }
//                throw;
//            }
//        }
//    }
//}