using System;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.Geometry;

namespace Autodesk.AutoCAD.EditorInput
{
   public class AcedCmdArg<T> : IAcedCmdArg
    {
       protected T argumentValue;
       public T Value
        {
            get { return argumentValue; }
        }

       private TypedValue typedValue;
       public TypedValue TypedValue
       {
           get { return typedValue; }
       }

       private string message;
       public string Message
       {
           get { return message; }
       }

       public AcedCmdArg(T value, string message = "")
       {
           this.argumentValue = value;
           this.message = message;
       }

       public AcedCmdArg(TypedValue value, string message = "")
       {
           
           this.argumentValue = (T)value.Value;
           this.message = message;
       }

       protected AcedCmdArg()
       {

       }

       public virtual PromptStatus Execute(Editor ed)
        {
            if (message != String.Empty)
            {
                ed.WriteMessage("\n" + message);
            }
           return ed.SendBuffer(TypedValue);
        }





        public TypedValue CreateTypedValue(T value)
        {
            throw new NotImplementedException();
        }
    }
   public class AcedCmdArg : IAcedCmdArg
   {


       private TypedValue typedValue;
       public TypedValue TypedValue
       {
           get { return typedValue; }
       }

       public AcedCmdArg(TypedValue value)
       {
           this.typedValue = value;
       }

       public virtual PromptStatus Execute(Editor ed)
       {
           return ed.SendBuffer(TypedValue);
       }
   }

    public class CommandArgument : AcedCmdArg
    {
        private string message;
        public string Message
        {
            get { return message; }
        }

        public CommandArgument(TypedValue value, string message = "") : base(value)
       {

           this.message = message;
       }

        public override PromptStatus Execute(Editor ed)
        {
            if (message != String.Empty)
            {
                ed.WriteMessage("\n" + message);
            }
            return base.Execute(ed);
        }
    }
    //public class AcedCmdArgString : AcedCmdArg<string>
    //{
    //    public AcedCmdArgString(string value, string message = "") : base(value, message)
    //    {
    //    }
    //    public override TypedValue TypedValue
    //    {
    //        get { return Value.ToTypedValue(); }
    //    }
    //}

    //public class AcedCmdArgShort: AcedCmdArg<short>
    //{
    //    public override TypedValue TypedValue
    //    {
    //        get { return Value.ToTypedValue(); }
    //    }
    //}
}
