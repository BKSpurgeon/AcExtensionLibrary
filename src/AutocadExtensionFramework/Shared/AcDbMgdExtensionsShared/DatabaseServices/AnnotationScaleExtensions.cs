namespace Autodesk.AutoCAD.DatabaseServices
{
    /// <summary>
    /// Extension Method class for AnnotationScales
    /// </summary>
    public static class AnnotationScaleExtensions
    {
        /// <summary>
        /// Returns Scale Factor
        /// </summary>
        /// <param name="annoScale"></param>
        /// <returns></returns>
        public static double GetScaleFactor(this AnnotationScale annoScale)
        {
            return (1.0 / annoScale.Scale);
        }
    }
}