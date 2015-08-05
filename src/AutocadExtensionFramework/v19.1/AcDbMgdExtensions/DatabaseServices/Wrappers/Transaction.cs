//using System.Runtime.InteropServices;
//using Autodesk.AutoCAD.DatabaseServices;

//using Autodesk.AutoCAD.Runtime;
//using System;
//namespace Autodesk.AutoCAD.DatabaseServices.Wrappers
//{
//    interface IReadTransaction : IDisposable
//    {
//        DBObject GetDBObject(ObjectId objid, bool openErased);

//    }

//    interface ITransaction : IReadTransaction
//    {
//        DBObject GetDBObject(ObjectId objid, bool openErased, bool forceOpenOnLockedLayer);
//        void Abort();
//        void Add(DBObject obj);
//        void Commit();
//    }


//    public sealed class ReadOnlyTransaction : ITransaction
//    {

//        public DBObject GetDBObject(ObjectId objid, bool openErased, bool forceOpenOnLockedLayer)
//        {
//            throw new NotImplementedException();
//        }

//        public DBObject GetDBObject(ObjectId objid, bool openErased)
//        {
//            throw new NotImplementedException();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }


//        public void Abort()
//        {
//            throw new NotImplementedException();
//        }

//        public void Add(DBObject obj)
//        {
//            throw new NotImplementedException();
//        }

//        public void Commit()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}


////public sealed class ReadOnlyTransaction : ITransaction
////{
////    private Autodesk.AutoCAD.DatabaseServices.Transaction m_trans;

////    public ReadOnlyTransaction()
////    {
////    }

////    public ReadOnlyTransaction(Database db)
////    {
////        this.Init(db);
////    }

////    private void Commit()
////    {
////        if (m_trans != null)
////        {
////            this.m_trans.Commit();
////            this.m_trans.Dispose();
////            this.m_trans = null;
////        }
////    }

////    public void Dispose()
////    {
////        this.Commit();
////    }

////    public DBObject GetObject(ObjectId objid)
////    {
////        return this.GetObject(objid, false);
////    }

////    public DBObject GetObject(ObjectId objid, bool openErased)
////    {
////        DebugUtil.Assert(this.m_trans != null);
////        DBObject obj2 = null;
////        try
////        {
////            obj2 = this.m_trans.GetObject(objid, OpenMode.ForRead, openErased);
////        }
////        catch (Autodesk.AutoCAD.Runtime.Exception exception)
////        {
////            if (exception.ErrorStatus != ErrorStatus.WasErased)
////            {
////                throw exception;
////            }
////        }
////        return obj2;
////    }

////    private bool Init(Database db)
////    {
////        Commit();
////        DebugUtil.Assert(db != null, "null db parameter in readonly transaction Init");
////        m_trans = db.TransactionManager.StartTransaction();
////        DebugUtil.Assert(this.m_trans != null, "failed to initialize readonly transaction");
////        return (this.m_trans != null);
////    }

////    public Transaction Transaction
////    {
////        get
////        {
////            return m_trans;
////        }
////    }
////}