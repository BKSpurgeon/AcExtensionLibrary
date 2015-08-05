using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.DatabaseServices.Contracts;
using System.Diagnostics.Contracts;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class ObjectIdExtensions
    {

        public static T GetDBObject<T>(this ObjectId id, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
        {
            if (id.IsNull)
            {
                throw new ArgumentNullException("id is null");
            }
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }
            return (T)trx.GetObject(id, mode, openErased, false);
        }

        public static T GetDBObject<T>(this ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
        {
            return id.GetDBObject<T>(id.Database.TransactionManager.TopTransaction, mode, openErased);
        }

        public static DBObject GetDBObject(this ObjectId id, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false)
        {
            return id.GetDBObject<DBObject>(trx, mode, openErased);
        }

        public static DBObject GetDBObject(this ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false)
        {
            return id.GetDBObject<DBObject>(id.Database.TransactionManager.TopTransaction, mode, openErased);
        }




        public static T GetEntity<T>(this ObjectId id, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
        {
            if (id.IsNull)
            {
                throw new ArgumentNullException("id is null");
            }
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }
            return (T)trx.GetObject(id, mode, openErased, forceOpenOnLockedLayer);
        }
        

        public static T GetEntity<T>(this ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
        {
            return id.GetEntity<T>(id.Database.TransactionManager.TopTransaction, mode, openErased, forceOpenOnLockedLayer);
        }


        public static Entity GetEntity(this ObjectId id, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false)
        {
            return id.GetEntity<Entity>(trx, mode, openErased, forceOpenOnLockedLayer);
        }

        public static Entity GetEntity(this ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) 
        {
            return id.GetEntity<Entity>(id.Database.TransactionManager.TopTransaction, mode, openErased, forceOpenOnLockedLayer);
        }

        public static IEnumerable<T> GetEntities<T>(this IEnumerable<ObjectId> ids, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids is null");
            }
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }
            foreach (ObjectId id in ids)
            {
               yield return (T)trx.GetObject(id, mode, openErased, forceOpenOnLockedLayer);
            }
            
        }

        public static IEnumerable<T> GetEntities<T>(this IEnumerable<ObjectId> ids, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
        {
            ObjectId id = ids.First();
            if (id == null)
            {
                throw new ArgumentNullException("id is null");
            }
            return ids.GetEntities<T>(id.Database.TransactionManager.TopTransaction, mode, openErased, forceOpenOnLockedLayer);
        }

        public static IEnumerable<Entity> GetEntities(this IEnumerable<ObjectId> ids, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false)
        {
             return ids.GetEntities<Entity>(trx, mode, openErased, forceOpenOnLockedLayer);

        }

        public static IEnumerable<Entity> GetEntities(this IEnumerable<ObjectId> ids, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false)
        {
            ObjectId id = ids.First();
            if (id == null)
            {
                throw new ArgumentNullException("id is null");
            }
            return ids.GetEntities<Entity>(id.Database.TransactionManager.TopTransaction, mode, openErased, forceOpenOnLockedLayer);
        }

        public static IEnumerable<T> GetDBObjects<T>(this IEnumerable<ObjectId> ids, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
        {
            if (ids == null)
            {
                throw new ArgumentNullException("ids is null");
            }
            if (trx == null)
            {
                throw new NoActiveTransactionException("No active Transaction");
            }
            foreach (ObjectId id in ids)
            {
                yield return (T)trx.GetObject(id, mode, openErased, false);
            }

        }

        public static IEnumerable<T> GetDBObjects<T>(this IEnumerable<ObjectId> ids, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
        {
            ObjectId id = ids.First();
            if (id == null)
            {
                throw new ArgumentNullException("id is null");
            }
            return ids.GetDBObjects<T>(id.Database.TransactionManager.TopTransaction, mode, openErased);
        }

        public static IEnumerable<DBObject> GetDBObjects(this IEnumerable<ObjectId> ids, Transaction trx, OpenMode mode = OpenMode.ForRead, bool openErased = false)
        {
            return ids.GetDBObjects<DBObject>(trx, mode, openErased);

        }

        public static IEnumerable<DBObject> GetDBObjects(this IEnumerable<ObjectId> ids, OpenMode mode = OpenMode.ForRead, bool openErased = false)
        {
            ObjectId id = ids.First();
            if (id == null)
            {
                throw new ArgumentNullException("id is null");
            }
            return ids.GetDBObjects<DBObject>(id.Database.TransactionManager.TopTransaction, mode, openErased);
        }
    }
}
