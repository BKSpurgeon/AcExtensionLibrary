using System.Dynamic;
using Autodesk.AutoCAD.DatabaseServices;
namespace Autodesk.AutoCAD.ApplicationServices
{
    public static class DocumentExtensionsv20_1
    {

        public static void CreatePreviewIcon(this BlockTableRecord btr)
        {
            Application.DocumentManager.MdiActiveDocument.Editor.Command("_.BLOCKICON", btr.Name);

        }
  
    }
}
