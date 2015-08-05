using System;
using System.Collections.Generic;
using System.Linq;

namespace Autodesk.AutoCAD.ApplicationServices
{
    public class SupportPath : IAcadPathRepository
    {
        private static char[] seperator = new char[] { ';' };
        private List<string> paths = new List<string>();


        protected dynamic Preferences { get; set; }
        protected virtual dynamic PreferencesFile
        {
            get { return Preferences.Files.SupportPath; }
            set { Preferences.Files.SupportPath = value; }
        }

        public SupportPath(object acadPreferences)
        {
            Preferences = acadPreferences;
            paths = CreatepathList(PreferencesFile);
        }


        public IEnumerable<string> GetPaths()
        {
            return paths.AsReadOnly();
        }

        public void Add(string path)
        {
            path = Expand(path);
            paths.Add(path);
           
            
        }

        public void Insert(int index, string path)
        {
            path = Expand(path);
            paths.Insert(index, path);
        }

        public bool Remove(string path)
        {
            path = Expand(path);
            return paths.Remove(path);
        }

        public void RemoveAt(int index)
        {
            paths.RemoveAt(index);
        }
        public int RemoveAll(Predicate<string> match )
        {
          return paths.RemoveAll(match);
        }

        public void RemoveRange(int index, int count)
        {
            paths.RemoveRange(index, count);
        }

        public void Clear()
        {
            paths.Clear();
        }
        
        public bool Contains(string path)
        {
            return paths.Contains(Expand(path), StringComparer.OrdinalIgnoreCase);
        }


        public void SaveChanges()
        {

            this.PreferencesFile = CreatePathsString(paths);
            paths = CreatepathList(PreferencesFile);
           
        }

        
        private static List<string> CreatepathList(string pathString)
        {

            return pathString.Split(seperator).ToList();
        }
        private static string CreatePathsString(IEnumerable<string> pathList)
        {
            return String.Join(";", pathList);
        }

        private static string Expand(string path)
        {
           return path.StartsWith("%") ? Environment.ExpandEnvironmentVariables(path) : path;
        }

    }
}