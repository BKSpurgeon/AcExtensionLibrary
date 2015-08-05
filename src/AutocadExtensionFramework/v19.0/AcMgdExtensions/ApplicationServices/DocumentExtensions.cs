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
        //public void ZoomToObject(this Document doc, Entity ent, double zoomFactor)
        //{
        //    if (doc.IsActive)
        //    {
                
        //    }

        //    int CvId = Convert.ToInt32((Autodesk.AutoCAD.ApplicationServices.Application.GetSystemVariable("CVPORT")));
        //    using (Autodesk.AutoCAD.GraphicsSystem.Manager gm = doc.GraphicsManager)
        //    using (Autodesk.AutoCAD.GraphicsSystem.View vw = gm.GetGsView(CvId, true))
        //    {
        //        Extents3d ext = ent.GeometricExtents;
        //        vw.ZoomExtents(ext.MinPoint, ext.MaxPoint);
        //        vw.Zoom(zoomFactor);
        //        gm.SetViewportFromView(CvId, vw, true, true, false);

        //    }
        //}
    }
}
