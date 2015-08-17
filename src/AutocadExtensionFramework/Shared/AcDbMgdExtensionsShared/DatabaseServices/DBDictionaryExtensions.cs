using System.Collections.Generic;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class DBDictionaryExtensions
    {
        public static IEnumerable<T> GetEntries<T>(this DBDictionary dic, Transaction trx,
            OpenMode mode = OpenMode.ForRead, bool includingErased = false) where T : DBObject
        {
            if (trx == null)
            {
                throw new Exception(ErrorStatus.NoActiveTransactions);
            }
            foreach (var entry in includingErased ? dic.IncludingErased : dic)
            {
                yield return (T) trx.GetObject(entry.Value, mode, includingErased, false);
            }
        }

        public static IEnumerable<T> GetEntries<T>(this DBDictionary dic, OpenMode mode = OpenMode.ForRead,
            bool includingErased = false) where T : DBObject
        {
            return dic.GetEntries<T>(dic.Database.TransactionManager.TopTransaction, mode, includingErased);
        }
    }
}
