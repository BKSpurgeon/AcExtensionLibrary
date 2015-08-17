using Autodesk.AutoCAD.Geometry;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class Extents3dExtensions
    {
        public static Point3d CenterPoint(this Extents3d exts)
        {
            return exts.MinPoint + ((exts.MaxPoint - exts.MinPoint)/2);
        }
    }
}
