using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices.Contracts;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices.Wrappers
{
    /// <summary>
    /// A generic wrapper class for wrapping the 9 common dictionaries created by AutoCAD. Group, Layout, etc.......
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class WrapperDBDictionary<T> : DBDictionary, IEnumerable<T> where T : DBObject
    {
        private Transaction trans { get; set; }
        private bool m_includingErased;

        internal WrapperDBDictionary(Transaction trx, DBDictionary dic, bool includingErased)
            : base(dic.UnmanagedObject, dic.AutoDelete)
        {
            trans = trx;
            Interop.DetachUnmanagedObject(dic);
            GC.SuppressFinalize(dic);
            m_includingErased = includingErased;
        }

        public new bool IncludingErased { get { return m_includingErased; } }

        public new IEnumerator<T> GetEnumerator()
        {
            using (DbDictionaryEnumerator enumerator = base.GetEnumerator())
            {
                if (enumerator.MoveNext())
                {

                    do
                    {
                        yield return (T)trans.GetObject(enumerator.Current.Value, OpenMode.ForRead, m_includingErased, false);

                    } while (enumerator.MoveNext());
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
