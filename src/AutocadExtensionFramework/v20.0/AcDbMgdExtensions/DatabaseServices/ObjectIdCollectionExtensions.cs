using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class ObjectIdCollectionExtensions
    {
        
        public static void Add(this ObjectIdCollection thisIds, ObjectIdCollection ids)
        {
            foreach (ObjectId id in ids)
            {
                thisIds.Add(id);
            }
        }

        public static void Add(this ObjectIdCollection thisIds, IEnumerable<ObjectId> ids)
        {
            foreach (ObjectId id in ids)
            {
                thisIds.Add(id);
            }
        }



        public static ObjectId[] ToArray(this ObjectIdCollection ids)
        {
            ObjectId[] idsArray = new ObjectId[ids.Count];
            ids.CopyTo(idsArray, 0);
            return idsArray;
        }

        //public static ObjectId[] ToArray(this IEnumerable<ObjectId> ids)
        //{
        //    return ids.ToArray();
        //}

        public static IEnumerable<ObjectId> Where<T>(this ObjectIdCollection source, Transaction trx, Func<T, bool> predicate) where T : DBObject
        {
            if (source.IsNull())
            {
                throw new ArgumentNullException("source");
            }
            if (predicate.IsNull())
            {
                throw new ArgumentNullException("predicate");
            }
            return WhereImpl<T>(source, trx, predicate);
        }

        public static IEnumerable<ObjectId> Where<T>(this ObjectIdCollection source, Func<T, bool> predicate) where T : DBObject
        {

            return Where<T>(source, HostApplicationServices.WorkingDatabase.TransactionManager.TopTransaction,  predicate);
        }

        private static IEnumerable<ObjectId> WhereImpl<T>(this ObjectIdCollection source, Transaction trx, Func<T, bool> predicate) where T : DBObject
        {
            
            foreach (ObjectId item in source)
            {
                T dbo = (T)trx.GetObject(item, OpenMode.ForRead, false, false);
                if (predicate(dbo))
                {
                    yield return item;
                }

            }
        }
        public static ObjectIdCollection ToObjectIdCollection(this IEnumerable<ObjectId> source)
        {

            return new ObjectIdCollection(source.ToArray());
        }

        public static ObjectIdCollection ToObjectIdCollection(this IEnumerable<DBObject> source)
        {
            ObjectIdCollection ids = new ObjectIdCollection();
            foreach (var dbObject in source)
            {
                ids.Add(dbObject.ObjectId);
            }
            return ids;
        }


    }
}
        //public static IEnumerable<ObjectId> WhereOwnedBy(this ObjectIdCollection source, ObjectId ownerId)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    if (ownerId.IsNull)
        //    {
        //        throw new ArgumentNullException("ownerId");
        //    }
        //    return WhereOwnedByImpl(source, ownerId);
        //}
        //private static IEnumerable<ObjectId> WhereOwnedByImpl(this ObjectIdCollection source, ObjectId ownerId)
        //{
        //    TransactionManager tm = source[0].Database.TransactionManager;
        //    foreach (ObjectId item in source)
        //    {
        //        DBObject dbo = tm.GetObject(item, OpenMode.ForRead, false, false);
        //        if (dbo.OwnerId == ownerId)
        //        {
        //            yield return item;
        //        }

        //    }
        //}

        //public static IEnumerable<ObjectId> WhereOwnedBy(this IEnumerable<ObjectId> source, ObjectId ownerId)
        //{
        //    if (source == null)
        //    {
        //        throw new ArgumentNullException("source");
        //    }
        //    if (ownerId.IsNull)
        //    {
        //        throw new ArgumentNullException("ownerId");
        //    }
        //    return WhereOwnedByImpl(source, ownerId);
        //}


        //private static IEnumerable<ObjectId> WhereOwnedByImpl(this IEnumerable<ObjectId> source, ObjectId ownerId)
        //{
        //    TransactionManager tm = source.First().Database.TransactionManager;
        //    foreach (ObjectId item in source)
        //    {
        //        DBObject dbo = tm.GetObject(item, OpenMode.ForRead, false, false);
        //        if (dbo.OwnerId == ownerId)
        //        {
        //            yield return item;
        //        }

        //    }
        //}