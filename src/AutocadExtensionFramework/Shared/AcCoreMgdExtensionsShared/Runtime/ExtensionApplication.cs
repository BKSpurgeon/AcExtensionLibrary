using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.EditorInput;
namespace Autodesk.AutoCAD.Runtime
{
    public abstract class ExtensionApplication : IExtensionApplication
    {
        public abstract void Initialize();
        public abstract void Terminate();

        void IExtensionApplication.Initialize()
        {
            try
            {
                this.Initialize();
            }
            catch (System.Exception ex)
            {
                Console.Beep();
                Application.DocumentManager.MdiActiveDocument.Editor.WriteLine("\nAn error occured while loading {0}:\n\n{1}",
                  this.GetType().Assembly.Location,
                  ex.ToString()
                );
                throw;
            }
        }

        void IExtensionApplication.Terminate()
        {
            this.Terminate();
        }

    }
}
