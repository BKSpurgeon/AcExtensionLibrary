using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.EditorInput
{

    //public interface IPromptArgument<TOptions, TResult> : IAcedCmdArg<TResult>
    //    where TOptions : PromptEditorOptions
    //    where TResult : PromptResult
    //{
    //    TOptions Options { get; }
    //}

    public interface IAcedCmdPromptArg<out TOptions, TResult, out TResultValue> : IAcedCmdArg
        where TOptions : PromptEditorOptions
        where TResult : PromptResult
    {
        //TResult PromptForResult(Editor ed);
        TResultValue Value { get; }
        TResult PromptForResult(Func<TOptions, TResult> edFunc);

    }
    //public abstract class PromptArgument<TOptions, TResult> : IPromptArgument<TOptions, TResult>
    //    where TOptions : PromptEditorOptions
    //    where TResult : PromptResult
    //{

    //    public PromptArgument(TOptions options)
    //    {
    //        _options = options;
    //    }

    //    private TOptions _options;
    //    public TOptions Options { get { return _options; } }

    //    public abstract TResult Value { get; }
    //    public PromptStatus Send(Editor ed)
    //    {
    //        if (Value.Status != PromptStatus.OK)
    //        {
    //            return Value.Status;
    //        }
    //        return GetResult(ed);
    //    }

    //    protected abstract PromptStatus GetResult(Editor ed);
    //    protected abstract TResult GetValue(Editor ed);
    //}
    public abstract class PromptArgument<TOptions, TResult> : IAcedCmdArg
        where TOptions : PromptEditorOptions
        where TResult : PromptResult
    {
        private TOptions _options;
        public TOptions Options { get { return _options; } }
        public PromptArgument(TOptions options)
        {
            _options = options;
        }
        private TResult _result;
        
        public TResult Result { get { return _result; } }
        
        public abstract TypedValue TypedValue { get; }
        public abstract Func<TOptions, TResult> PromptForArgument(Editor ed);
        public virtual PromptStatus Execute(Editor ed)
        {
            var fun = PromptForArgument(ed);
            _result = fun(Options);
            if (Result.Status != PromptStatus.OK) return Result.Status;
            return ed.SendBuffer(TypedValue);
        }
    }
    delegate string ConvertMethod(string inString);

    public class DelegateExample
    {
        public static void Main()
        {
            // Instantiate delegate to reference UppercaseString method
            ConvertMethod convertMeth = UppercaseString;
            string name = "Dakota";
            // Use delegate instance to call UppercaseString method
            Console.WriteLine(convertMeth(name));
            string poo = convertMeth(name);
        }

        private static string UppercaseString(string inputString)
        {
            return inputString.ToUpper();
        }
    }


    //public class GenericFunc
    //{
    //    public static void Main()
    //    {
    //        // Instantiate delegate to reference UppercaseString method
    //        poo p = new poo();
            
    //        Func<string, string> convertMethod = UppercaseString;
    //        string name = "Dakota";
    //        // Use delegate instance to call UppercaseString method
    //        Console.WriteLine(convertMethod(name));
    //        string poo = convertMethod(name);
    //    }

    //    public static string UppercaseString(string inputString)
    //    {
    //        return inputString.ToUpper();
    //    }

    //    public class poo<TOptions, TResult> 
    //    where TOptions : PromptEditorOptions
    //    where TResult : PromptResult
    //    {
    //       public  Func<TOptions, TResult> convertMethod { get; set; }

    //        public TResult write(TOptions s)
    //        {
    //            return convertMethod(s);
    //        }
    //    }
    //}
}
