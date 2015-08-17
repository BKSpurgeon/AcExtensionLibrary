using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using System.Linq.Expressions;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace Autodesk.AutoCAD.EditorInput
{
    public static class EditorExtensionsv19_1
    {
        [System.Security.SuppressUnmanagedCodeSecurity]
        [DllImport("accore.dll", EntryPoint = "acedCmd", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        extern static private int acedCmd(IntPtr resbuf);

        public static PromptStatus SendBuffer(this Editor ed, ResultBuffer rb)
        {
            using (rb)
            {
                int status = acedCmd(rb.UnmanagedObject);
                if (status == -5002) return PromptStatus.Cancel;
                return ((status == 5100) ? PromptStatus.OK : PromptStatus.Error);
            }
        }

        public static PromptStatus SendBuffer(this Editor ed, TypedValue typedValue)
        {
            return SendBuffer(ed, new ResultBuffer(typedValue));
        }


        public static PromptStatus AcedCmd(this Editor editor, string commandName, params object[] args)
        {
            AcedCmd cmd = new AcedCmd(commandName, args);
            return cmd.Execute(editor);
        }

        public static PromptStatus AcedCmd(this Editor editor, IAcedCmd command)
        {
            return command.Execute(editor);
        }

   
    }
}
