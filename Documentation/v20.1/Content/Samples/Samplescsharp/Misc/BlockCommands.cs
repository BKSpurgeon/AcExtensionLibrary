using System;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Samplescsharp.Misc;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;


[assembly: CommandClass(typeof (BlockCommands))]

namespace Samplescsharp.Misc
{
    public class BlockCommands : CommandClass
    {
        public BlockCommands()
        {
            PerDocData.Create(Doc);
        }


        private string _blockName = string.Empty;


        [CommandMethod("-Inoutblk")]
        public async void _INOUTBLK()
        {
            Settings.Variables.ATTDIA = false;
            PromptStringOptions pso = new PromptStringOptions("\nEnter BlockName")
            {
                AllowSpaces = false,
                UseDefaultValue = true,
                DefaultValue = _blockName
            };
            var pr = Ed.GetString(pso);
            if (pr.Status != PromptStatus.OK) return;
            _blockName = pr.StringResult.ToUpper();

            try
            {
                await InsertBlock(_blockName);
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                if (ex.ErrorStatus != ErrorStatus.UserBreak)
                {
                    throw;
                }
            }
        }
        [CommandMethod("Inoutblk")]
        public async void Inoutblk()
        {
            var pso = new PromptStringOptions("\nEnter BlockName")
            {
                AllowSpaces = false,
                UseDefaultValue = true,
                DefaultValue = _blockName
            };
            var pr = Ed.GetString(pso);
            if (pr.Status != PromptStatus.OK) return;
            _blockName = pr.StringResult.ToUpper();
            {
                try
                {
                    bool promptOk = true;

                    while (promptOk)
                    {
                        promptOk = await InsertBlock(_blockName);
                    }
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    if (ex.ErrorStatus != ErrorStatus.UserBreak)
                    {
                        throw;
                    }
                }
            }
        }
        [CommandMethod("InoutblKx")]
        public void InoutblKx()
        {
            var pso = new PromptStringOptions("\nEnter BlockName")
            {
                AllowSpaces = false,
                UseDefaultValue = true,
                DefaultValue = _blockName
            };
            var pr = Ed.GetString(pso);
            if (pr.Status != PromptStatus.OK) return;
            _blockName = pr.StringResult.ToUpper();

            try
            {
                InoutblKxAsync(_blockName);
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                if (ex.ErrorStatus != ErrorStatus.UserBreak)
                {
                    throw;
                }
            }
        }


        private async void InoutblKxAsync(string name)
        {
            try
            {
                InsertBlockX(name);
                var psr = Ed.SelectLast();
                if (psr.Status != PromptStatus.OK) return;
                await Ed.CommandAsync("_.EXPLODE", psr.Value);
            }
            catch (Autodesk.AutoCAD.Runtime.Exception ex)
            {
                if (ex.ErrorStatus != ErrorStatus.UserBreak)
                {
                    throw;
                }
            }
        }
        private async Task<bool> InsertBlock(string name)
        {
            using (var tsv = new TemporarySystemVariables() { })
            {
                tsv.TEXTEVAL = true;

                try
                {
                    Ed.InitCommandVersion(2);
                    Application.PreTranslateMessage += Application_PreTranslateMessage;
                    await Ed.CommandAsync("_.-INSERT", name, Editor.PauseToken);
                    Application.PreTranslateMessage -= Application_PreTranslateMessage;
                    await Ed.CommandAsync(1);
                    while (Ed.IsDragging ||Settings.Variables.CMDNAMES.ToUpper().IndexOf("INSERT", StringComparison.Ordinal) >= 0)
                    {
                        await Ed.CommandAsync(Editor.PauseToken);
                    }
                }
                catch (Autodesk.AutoCAD.Runtime.Exception ex)
                {
                    if (ex.ErrorStatus != ErrorStatus.UserBreak)
                    {
                        throw;
                    }
                    Application.PreTranslateMessage -= Application_PreTranslateMessage;
                    return false;
                }
            }
            return true;
        }


        private void InsertBlockX(string name)
        {
          using (var tsv = new TemporarySystemVariables() { })
            {
                Ed.InitCommandVersion(2);
                Ed.Command("_.-INSERT", name, Editor.PauseToken, 1);
            }
        }

        private static int MkShift { get; } = 4;
        private static int WmRbuttonup { get; } = 517;
        private static int WmLbuttonup { get; } = 514;
        private static int WmLbuttondown { get; } = 513;
        private static int WmRbuttondown { get; } = 516;
        private static int VkReturn { get; } = 13;
        private static int WmKeydown { get; } = 256;


        private static void Application_PreTranslateMessage(object sender, PreTranslateMessageEventArgs e)
        {
            var wp = e.Message.wParam.ToInt64();
            //if (wp != 0 && wp != 2 && wp != 47806 && wp != 16385 && wp != 1)
            //{
            //    Application.DocumentManager.MdiActiveDocument.Editor.WriteLine(wp);
            //}

            if (e.Message.message == WmRbuttondown && (wp != 6 && wp != MkShift))
            {
                e.Handled = true;
            }
            if (e.Message.message == WmRbuttonup && wp != MkShift)
            {
                Application.PreTranslateMessage -= Application_PreTranslateMessage;
                e.Handled = true;
                Application.DocumentManager.MdiActiveDocument.SendCancel();
            }

            if (e.Message.message == WmKeydown && wp == VkReturn)
            {
                Application.PreTranslateMessage -= Application_PreTranslateMessage;
                e.Handled = true;
                Application.DocumentManager.MdiActiveDocument.SendCancel();
            }
        }



    }
}