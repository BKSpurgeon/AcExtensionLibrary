//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Autodesk.AutoCAD.DatabaseServices;

//namespace Autodesk.AutoCAD.ApplicationServices.Core
//{
//    public interface ITransactionManager
//    {
//        ITransaction CreateTransaction();
//    }
//    public interface IReadOnlyTransaction : ITransaction
//    {
//        T GetDBObject<T>(ObjectId objid, bool openErased) where T : DBObject;
//        T GetEntity<T>(ObjectId objid, bool openErased) where T : Entity;
//    }
//    public interface IWriteableTransaction : ITransaction
//    {
//        void AddNewlyCreatedDBObject(DBObject obj);
//        T GetDBObject<T>(ObjectId id, OpenMode mode, bool openErased) where T : DBObject;
//        T GetEntity<T>(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer) where T : Entity;
//    }
//    public interface ITransaction : IDisposable
//    {
//        void Commit();
//        void Abort();
       
//    }
//    public interface ICurrentTransaction
//    {
        
//    }


//}
