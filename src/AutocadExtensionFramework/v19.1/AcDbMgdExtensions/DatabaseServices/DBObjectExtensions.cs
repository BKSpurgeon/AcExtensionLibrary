using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class DBObjectExtensions
    {
        public static bool HasExtensionDictionary(this DBObject dbObj)
        {
            return !dbObj.ExtensionDictionary.IsNull;
        }


        public static DBDictionary GetExtensionDictionary(this DBObject dbObj)
        {
            if (!HasExtensionDictionary(dbObj))
            {
                if (!dbObj.IsWriteEnabled)
                {
                    dbObj.UpgradeOpen();
                }
                dbObj.CreateExtensionDictionary();
            }
            return dbObj.ExtensionDictionary.GetDBObject<DBDictionary>();
        }

        public static bool TryGetExtensionDictionaryId(this DBObject dbObj, out ObjectId id)
        {
            id = dbObj.ExtensionDictionary;
            return !id.IsNull;
        }

        public static ObjectId GetExtensionDictionaryId(this DBObject dbObj)
        {
            ObjectId id;
            if (!dbObj.TryGetExtensionDictionaryId(out id))
            {
                if (!dbObj.IsWriteEnabled)
                {
                    dbObj.UpgradeOpen();
                }

                dbObj.CreateExtensionDictionary();
                id = dbObj.ExtensionDictionary;
            }
            return id;
        }


        public static bool ExtensionDictionaryContains(this DBObject dbObj, string name)
        {
            if (dbObj.HasExtensionDictionary())
            {
                return dbObj.GetExtensionDictionary().Contains(name);
            }
            return false;
        }
    }
}
