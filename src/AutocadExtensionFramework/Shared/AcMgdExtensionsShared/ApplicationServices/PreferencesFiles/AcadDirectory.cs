using System;
using System.IO;

namespace Autodesk.AutoCAD.ApplicationServices.PreferencesFiles
{
    public class AcadDirectory : IEquatable<AcadDirectory>
    {


        private readonly DirectoryInfo _directoryInfo;
        public AcadDirectory(string path)
        {
            _directoryInfo = path.StartsWith("%") ? new DirectoryInfo(Environment.ExpandEnvironmentVariables(path)) : new DirectoryInfo(path);

        }
        public bool Exists { get { return _directoryInfo.Exists; } }
        public string Path { get { return _directoryInfo.FullName; } }
        public string Name { get { return _directoryInfo.Name; } }


        public bool Equals(AcadDirectory other)
        {
            if (other == null)
                return false;

            return this.Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var acadDir = obj as AcadDirectory;
            return acadDir != null && Equals(acadDir); 
        }

        public override int GetHashCode()
        {
            return (String.IsNullOrEmpty(Name) ? Name.GetHashCode() : 0);
        }

        public static bool operator ==(AcadDirectory acadDir1, AcadDirectory acadDir2)
        {
            if ((object)acadDir1 == null || ((object)acadDir2) == null)
                return Equals(acadDir1, acadDir2);

            return acadDir1.Equals(acadDir2);
        }

        public static bool operator !=(AcadDirectory acadDir1, AcadDirectory acadDir2)
        {
            if (acadDir1 == null || acadDir2 == null)
                return !Equals(acadDir1, acadDir2);

            return !(acadDir1.Equals(acadDir2));
        }

    }
}