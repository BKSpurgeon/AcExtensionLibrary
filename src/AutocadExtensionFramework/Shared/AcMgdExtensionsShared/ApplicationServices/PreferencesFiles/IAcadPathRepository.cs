using System.Collections.Generic;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    interface IAcadPathRepository
    {
        IEnumerable<string> GetPaths();
        void Add(string path);
        void Insert(int index, string path);
        bool Remove(string path);
        void SaveChanges();
        bool Contains(string path);
    }
}