using System.Collections.Generic;
using System.Linq;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class SymbolTableRecordExtensions
    {
        public static IEnumerable<string> Names(this IEnumerable<SymbolTableRecord> source)
        {
            return source.Select(str => str.Name);
        }
    }
}
