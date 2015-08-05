using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using System.Diagnostics.Contracts;
using Autodesk.AutoCAD.DatabaseServices.Contracts;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class DBDictionaryExtensions
    {
        public static IEnumerable<T> GetEntries<T>(this DBDictionary dic, Transaction trx, OpenMode mode = OpenMode.ForRead, bool includingErased = false) where T : DBObject
        {
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }
            foreach (var entry in includingErased ? dic.IncludingErased : dic)
            {
                yield return (T)trx.GetObject(entry.Value, mode, includingErased, false);
            }
        }

        public static IEnumerable<T> GetEntries<T>(this DBDictionary dic, OpenMode mode = OpenMode.ForRead, bool includingErased = false) where T : DBObject
        {
            return dic.GetEntries<T>(dic.Database.TransactionManager.TopTransaction, mode, includingErased);
        }
    }
}
