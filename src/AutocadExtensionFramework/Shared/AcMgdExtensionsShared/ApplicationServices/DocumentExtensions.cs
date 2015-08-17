using System.Dynamic;
using Autodesk.AutoCAD.DatabaseServices;
namespace Autodesk.AutoCAD.ApplicationServices
{
    public static class DocumentExtensions
    {
        /// <summary>
        /// Author: Tony Tanzillo
        /// Source: http://www.theswamp.org/index.php?topic=42016.msg471429#msg471429
        /// </summary>
        /// <param name="doc"></param>
        public static void Save(this Document doc)
        {
            dynamic acadDoc = doc.GetAcadDocument();
            acadDoc.Save();
        }
        public static void SendCommand(this Document doc, string command)
        {
            dynamic acadDoc = doc.GetAcadDocument();
            acadDoc.SendCommand(command);
        }

        public static void SendCancel(this Document doc)
        {
            doc.SendCommand("\x03\x03");
        }

      

    }
}
