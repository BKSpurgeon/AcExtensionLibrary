namespace Autodesk.AutoCAD.ApplicationServices
{
    public static class StringExtensions
    {
        public static bool Matches(this string str, string pattern, bool ignoreCase = true)
        {
            return Autodesk.AutoCAD.Internal.Utils.WcMatchEx(str, pattern, ignoreCase);
        }
    }
}
