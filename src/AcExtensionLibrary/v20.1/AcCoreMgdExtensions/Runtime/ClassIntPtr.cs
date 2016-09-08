using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.Runtime
{
    public class ClassIntPtr
    {
        public static readonly ClassIntPtr Current = new ClassIntPtr();

        public readonly RXClass BlockReferenceRXClass;
        public readonly IntPtr BlockReferenceIntPtr;
        public bool IsBlockReference(ObjectId id)
        {
            return id.ObjectClass.UnmanagedObject == BlockReferenceIntPtr;
        } 


        public readonly RXClass GroupRXClass;
        public readonly IntPtr GroupIntPtr;
        public bool IsGroup(ObjectId id)
        {
            return id.ObjectClass.UnmanagedObject == GroupIntPtr;
        }


        private ClassIntPtr()
        {
            BlockReferenceRXClass = RXClass.GetClass(typeof(BlockReference));
            BlockReferenceIntPtr = BlockReferenceRXClass.UnmanagedObject;

            GroupRXClass = RXClass.GetClass(typeof(Group));
            GroupIntPtr = GroupRXClass.UnmanagedObject;

        }

    }
}
