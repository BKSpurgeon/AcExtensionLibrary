//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Text;
//using Autodesk.AutoCAD.ApplicationServices.Core;
//using Autodesk.AutoCAD.ApplicationServices;

//namespace Autodesk.AutoCAD.EditorInput
//{
//   public class EdCmd : ICommand
//    {
//        private static char[] s_prefixes = { '.', '_'};
//        public static string Pause { get { return "\\"; } }
//        public static string Enter { get { return String.Empty; } }
//       public bool SendPauseForPrompts { get; set; }
//        string formattedName { get;  set; }
//        public string Name { get; private set; }
//        private List<object> args = new List<object>();
//        public EdCmd(string commandName, params object[] arguments)
//        {
//            if (String.IsNullOrWhiteSpace(commandName))
//            {
//                throw new ArgumentNullException(commandName);
//            }
//            formattedName = commandName;
//            Name = commandName.TrimStart(s_prefixes).ToUpper();
//            args.AddRange(arguments);
//            SendPauseForPrompts = true;
//        }

//       public void AddArgument(object arg)
//       {
//           args.Add(arg);
//       }

//       bool IsActive(bool exactcheck = false)
//       {

//           string cmdNames = SystemVariables.SystemVariables.CMDNAMES;
//           bool active = cmdNames.IndexOf(Name, 0, StringComparison.InvariantCultureIgnoreCase) >= 0;
//           if (exactcheck)
//           {
//               if (!Name.Contains("'"))
//               {
//                   var names = cmdNames.Split('\'');
//                   active = active && names.Contains(Name);
//               }
//           }
//           return active;

//       }





//       public PromptStatus Run()
//       {
//           //Contract.Requires<InvalidOperationException>(!Application.DocumentManager.IsApplicationContext, "Must be in Document Context");

//           PromptStatus ps = PromptStatus.None;
//           Editor ed = Application.DocumentManager.MdiActiveDocument.Editor;
//           ps = ed.RunCmd(formattedName);
//           //ed.WriteLine("formattedname = {0}", Enum.GetName(typeof(PromptStatus), ps));
//           if (IsActive() && args.Count > 0)
//           {
//               int index = 0;
//               while (index < args.Count && ps == PromptStatus.OK && IsActive())
//               {
//                   object obj = args[index];
//                   if (obj == null)
//                   {
//                      int argIndex = index + 1;
//                       throw new ArgumentNullException(argIndex.ToString(CultureInfo.InvariantCulture) + " argument for command is null");
//                   }

//                   ps = ed.RunCmd(obj);
//                   index++;
//                   //ed.WriteLine("arg#{0}-{1} = {2}", index,obj, Enum.GetName(typeof(PromptStatus), ps));
//               }
//               if (SendPauseForPrompts)
//               {
//                   while (IsActive() && ps == PromptStatus.OK)
//                   {
//                       ps = ed.SendPause();
//                       //ed.WriteLine("IsActive = {0}", Enum.GetName(typeof(PromptStatus), ps));
//                   }
//               }

//           }          
//           return ps;
//       }
//    }
//}
