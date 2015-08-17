using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;
using Autodesk.AutoCAD.Runtime;
using Exception = Autodesk.AutoCAD.Runtime.Exception;

namespace Autodesk.AutoCAD.EditorInput
{
    public class AcedCmd : IAcedCmd
    {
        private static char[] sPrefixes = { '.', '_' };

        private static readonly string _pause = "\\";
        private static readonly TypedValue _pauseTypedValue = _pause.ToResultTypedValue();
        public static IAcedCmdArg Pause(string message = "")
        {
            return new CommandArgument(_pauseTypedValue, message);
        }
        private static readonly IAcedCmdArg _enter = Argument(String.Empty);
        public static IAcedCmdArg Enter
        {
            get { return _enter; }
        }

        public bool SendPauseForPrompts { get; set; }
        public int InitCommandVersion { get; set; }
        private string FormattedName { get; set; }

        public string Name { get; private set; }
        private List<IAcedCmdArg> _arguments = new List<IAcedCmdArg>();

        public AcedCmd(string commandName, params IAcedCmdArg[] arguments): this(commandName)
        {

            _arguments.AddRange(arguments);
        }
        public AcedCmd(string commandName, params object[] arguments)
            : this(commandName)
        {
            if (arguments.IsNull()) return;
            for (int i = 0; i < arguments.Count(); i++)
            {
                var argument = arguments[i];
                if (argument.IsNull())
                {
                    throw new ArgumentNullException(String.Format("{0} argument is null", (i + 1)));
                }

                var arg = new AcedCmdArg(argument.ToResultTypedValue());
                _arguments.Add(arg);
            }
        }

        public AcedCmd(string commandName)
        {

            if (String.IsNullOrWhiteSpace(commandName))
            {
                throw new ArgumentNullException(commandName);
            }
            FormattedName = commandName;
            Name = commandName.TrimStart(sPrefixes).ToUpper();
            SendPauseForPrompts = true;
        }

        public void AddArgument(IAcedCmdArg argument)
        {
            _arguments.Add(argument);
        }

        private bool IsActive(bool exactcheck = false)
        {

            string cmdNames = Settings.Variables.CMDNAMES;
            bool active = cmdNames.IndexOf(Name, 0, StringComparison.InvariantCultureIgnoreCase) >= 0;
            if (!exactcheck) return active;
            if (Name.Contains("'")) return active;
            var names = cmdNames.Split('\'');
            active = active && names.Contains(Name);
            return active;

        }

        public PromptStatus Execute(Editor ed)
        {
            if (Application.DocumentManager.IsApplicationContext)
            {
                throw new Exception(ErrorStatus.InvalidContext);
            }
            if (!Settings.Variables.NEXTFIBERWORLD)
            {
                Application.ShowAlertDialog("Set NEXTFIBERWORLD = 0 & restart AutoCAD!");
            }
            PromptStatus ps = PromptStatus.None;
            ed.InitCommandVersion(InitCommandVersion);
            IAcedCmdArg name = Argument(FormattedName);
            ps = name.Execute(ed);
           if (!IsActive() || _arguments.Count <= 0) return ps;
            int index = 0;
            while (index < _arguments.Count && ps == PromptStatus.OK && IsActive())
            {
                IAcedCmdArg arg = _arguments[index];
                if (arg == null)
                {
                    int argIndex = index + 1;
                    throw new ArgumentNullException(argIndex.ToString(CultureInfo.InvariantCulture) +
                                                    " argument for command is null");
                }

                ps = arg.Execute(ed);
                index++;
            }
            if (!SendPauseForPrompts) return ps;
            while (IsActive() && ps == PromptStatus.OK)
            {

                ps = Pause().Execute(ed);
            }
            return ps;
            
        }

  
        public static IAcedCmdArg Argument(string value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(short value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(int value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(long value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(double value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(Point2d value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(Point3d value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(ObjectId value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        public static IAcedCmdArg Argument(SelectionSetDelayMarshalled value, string message = "")
        {
            return new CommandArgument(value.ToResultTypedValue(), message);
        }

        //public static IAcedCmdArg Argument(PromptAngleOptions options)
        //{
        //    return new PromptAngleArgument(options);
        //}

        public static IAcedCmdArg Argument(PromptDistanceOptions options)
        {
            return new PromptDistanceArgument(options);
        }
        public static IAcedCmdArg Argument(PromptDoubleOptions options)
        {
            return new PromptDoubleArgument(options);
        }
        public static IAcedCmdArg Argument(PromptPointOptions options)
        {
            return new PromptPointArgument(options);
        }
        public static IAcedCmdArg Argument(PromptCornerOptions options)
        {
            return new PromptCornerArgument(options);
        }
        public static IAcedCmdArg Argument(PromptSelectionOptions options)
        {
            return new PromptSelectionArgument(options);
        }
        public static IAcedCmdArg Argument(PromptStringOptions options)
        {
            return new PromptStringArgument(options);
        }

    }

}