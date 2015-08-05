using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using System;
namespace Autodesk.AutoCAD.DatabaseServices.Wrappers
{
    interface IReadTransaction : IDisposable
    {
        DBObject GetDBObject(ObjectId objid, bool openErased);

    }

    public interface ITransaction : IDisposable
    {
        void Abort();
        void AddNewlyCreatedDBObject(DBObject obj, bool add);
        void AddNewlyCreatedDBObject(DBObject obj);
        void Commit();
        DBObject GetObject(ObjectId id, OpenMode mode);
        DBObject GetObject(ObjectId id, OpenMode mode, bool openErased);
        DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer);
    }
    public interface ITransactionManaged : ITransaction
    {
       
        TransactionManager TransactionManager { get; }
    }
    interface IAcTransaction
    {
        T GetDBObject<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject;
        T GetEntity<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity;
        //void Abort();
        //void Add(DBObject obj);
        //void Commit();
    }

    //public class poo
    //{
    //    private Stack<ITransaction> transactions = new Stack<ITransaction>();
    //    public ITransaction ActiveTransaction { get; private set; } 
    //    public ITransaction Pop()
    //    {
    //        ITransaction Itrx = transactions.Pop();
    //        if (transactions.Count > 0)
    //        {
    //            ActiveTransaction = transactions.Peek();
    //        }
    //        else
    //        {
    //            ActiveTransaction = null;
    //        }
    //    }
    //}
    //////////////////////////public abstract class BaseTransaction : ITransaction
    //////////////////////////{

    //////////////////////////    private static Stack<ITransaction> transactions = new Stack<ITransaction>();
    //////////////////////////    public static ITransaction ActiveTransaction { get; private set; }

    //////////////////////////    protected Transaction Transaction { get; set; }
        
    //////////////////////////    public BaseTransaction(Transaction trx)
    //////////////////////////    {
    //////////////////////////        Transaction = trx;
    //////////////////////////        //Manager = trx.TransactionManager;
    //////////////////////////    }

    //////////////////////////    public abstract void AddNewlyCreatedDBObject(DBObject obj, bool add);
    //////////////////////////    public virtual void Abort()
    //////////////////////////    {
    //////////////////////////        Commit(false);
    //////////////////////////    }

    //////////////////////////    public virtual void Commit()
    //////////////////////////    {
    //////////////////////////        Commit(true);
    //////////////////////////    }

    //////////////////////////    private bool commited = false;
    //////////////////////////    protected void Commit(bool commit)
    //////////////////////////    {
    //////////////////////////        if (!commited)
    //////////////////////////        {
    //////////////////////////            if (commit)
    //////////////////////////            {
    //////////////////////////                Transaction.Commit();
    //////////////////////////            }
    //////////////////////////            else
    //////////////////////////            {
    //////////////////////////                Transaction.Abort();
    //////////////////////////            }

    //////////////////////////            Dispose();
    //////////////////////////            commited = true;
    //////////////////////////        }
            
    //////////////////////////    }

       
    //////////////////////////    public abstract DBObject GetObject(ObjectId id, OpenMode mode);
    //////////////////////////    public abstract DBObject GetObject(ObjectId id, OpenMode mode, bool openErased);
    //////////////////////////    public abstract DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer);

    //////////////////////////    //private TransactionManager tm;
    //////////////////////////    //public TransactionManager TransactionManager
    //////////////////////////    //{
    //////////////////////////    //    get {return tm; }
    //////////////////////////    //}

 
        
    //////////////////////////    public void Dispose()
    //////////////////////////    {
    //////////////////////////        GC.SuppressFinalize(this);
    //////////////////////////        Dispose(true);
    //////////////////////////    }
    //////////////////////////    private bool _disposed;
    //////////////////////////    protected virtual void Dispose(bool disposing)
    //////////////////////////    {
    //////////////////////////        if (!_disposed)
    //////////////////////////        {
    //////////////////////////            transactions.Pop();
    //////////////////////////            ActiveTransaction = transactions.Count > 0 ? transactions.Peek() : null;

    //////////////////////////            if (disposing)
    //////////////////////////            {
    //////////////////////////                // We were called by the Dispose method.
    //////////////////////////                // Release managed resources (like other IDisposables) here.
    //////////////////////////            }

    //////////////////////////            Transaction.Dispose();
    //////////////////////////            Transaction = null;
    //////////////////////////            _disposed = true;
    //////////////////////////        }

    //////////////////////////        // If there were a base class that’s IDisposable, call that one too.
    //////////////////////////        // base.Dispose(disposing);
    //////////////////////////    }

    //////////////////////////    ~BaseTransaction()
    //////////////////////////    {
            
    //////////////////////////    }
    //////////////////////////    //public T GetDBObject<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
    //////////////////////////    //{
    //////////////////////////    //    throw new NotImplementedException();
    //////////////////////////    //}

    //////////////////////////    //public T GetEntity<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
    //////////////////////////    //{
    //////////////////////////    //    throw new NotImplementedException();
    //////////////////////////    //}
    //////////////////////////}
    public abstract class BaseTransaction : ITransaction
    {

        private static Stack<ITransaction> transactions = new Stack<ITransaction>();
        public static ITransaction ActiveTransaction { get; private set; }

        protected Transaction Transaction { get; set; }

        public BaseTransaction(Transaction trx)
        {
            Transaction = trx;
            //Manager = trx.TransactionManager;
        }

        public void AddNewlyCreatedDBObject(DBObject obj, bool add)
        {
            Transaction.AddNewlyCreatedDBObject(obj, add);
        }
        public void AddNewlyCreatedDBObject(DBObject obj)
        {
            Transaction.AddNewlyCreatedDBObject(obj, true);
        }
        public virtual void Abort()
        {
            Commit(false);
        }

        public virtual void Commit()
        {
            Commit(true);
        }

        private bool commited = false;
        protected void Commit(bool commit)
        {
            if (!commited)
            {
                if (commit)
                {
                    Transaction.Commit();
                }
                else
                {
                    Transaction.Abort();
                }

                Dispose();
                commited = true;
            }

        }


        public abstract DBObject GetObject(ObjectId id, OpenMode mode);
        public abstract DBObject GetObject(ObjectId id, OpenMode mode, bool openErased);
        public abstract DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer);

        //private TransactionManager tm;
        //public TransactionManager TransactionManager
        //{
        //    get {return tm; }
        //}



        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        private bool _disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                transactions.Pop();
                ActiveTransaction = transactions.Count > 0 ? transactions.Peek() : null;

                if (disposing)
                {
                    Transaction.Commit();
                }

                Transaction.Dispose();
                Transaction = null;
                _disposed = true;
            }

            // If there were a base class that’s IDisposable, call that one too.
            //base.Dispose(disposing);
        }

        ~BaseTransaction()
        {

        }
        //public T GetDBObject<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
        //{
        //    throw new NotImplementedException();
        //}

        //public T GetEntity<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
        //{
        //    throw new NotImplementedException();
        //}



    }
    public class DocTransaction 
    {




        public T GetDBObject<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false) where T : DBObject
        {
            throw new NotImplementedException();
        }

        public T GetEntity<T>(ObjectId id, OpenMode mode = OpenMode.ForRead, bool openErased = false, bool forceOpenOnLockedLayer = false) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
    public class Db1Transaction : Transaction
    {
        public static Db1Transaction Start(Database db)
        {
            return Create(db.TransactionManager.StartTransaction());
        }

        public static Db1Transaction Start(Document doc)
        {
            return Create(doc.TransactionManager.StartTransaction());
        }

        public static Db1Transaction StartOpenClose(Database db)
        {
            return Create(db.TransactionManager.StartOpenCloseTransaction());
        }

        private static Db1Transaction Create(Transaction tr)
        {
            Db1Transaction d = new Db1Transaction(tr.UnmanagedObject, tr.AutoDelete, tr);
            Interop.DetachUnmanagedObject(tr);
            GC.SuppressFinalize(tr);
            transactions.Push(d);
            return d;
        }
        private static Stack<Transaction> transactions = new Stack<Transaction>();
        public static Transaction ActiveTransaction { get { return transactions.Peek(); } }

        private TransactionManager tmgr;
        private Transaction trx;
        protected internal Db1Transaction(IntPtr unmanagedPointer, bool autoDelete, Transaction tr)
            : base(unmanagedPointer, autoDelete)
        {
            trx = tr;
            tmgr = tr.TransactionManager;
        }

        public override void Abort()
        {
            trx.Abort();
        }

        public override void AddNewlyCreatedDBObject(DBObject obj, bool add)
        {
            trx.AddNewlyCreatedDBObject(obj, add);
        }

        public override void Commit()
        {
            trx.Commit();
        }

        public override DBObject GetObject(ObjectId id, OpenMode mode)
        {
            return base.GetObject(id, mode);
        }

        public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased)
        {
            return base.GetObject(id, mode, openErased);
        }

        public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer)
        {
            return base.GetObject(id, mode, openErased, forceOpenOnLockedLayer);
        }

        public override TransactionManager TransactionManager
        {
            get { return base.TransactionManager; }
        }
      
        //private bool _disposed;
        //protected override void Dispose(bool A_1)
        //{
        //    if (!_disposed)
        //    {
        //        if (A_1)
        //        {
        //            // We were called by the Dispose method.
        //            // Release managed resources (like other IDisposables) here.
        //        }

        //        // Also null out reference type fields here.
        //        ////////////CloseHandle(_handle);
        //        ////////////_disposed = true;
        //    }

        //    // If there were a base class that’s IDisposable, call that one too.
        //    // base.Dispose(disposing);
        //    base.Dispose(A_1);
        //}
    }
    public class OpenClosTransaction : Transaction
    {
        //private TransactionManager tmgr;
        private Transaction trx;
        protected internal OpenClosTransaction(IntPtr unmanagedPointer, bool autoDelete, Transaction tr)
            : base(unmanagedPointer, autoDelete)
        {
            trx = tr;
            Interop.DetachUnmanagedObject(tr);
            //tmgr = tr.TransactionManager;
        }

        public override void AddNewlyCreatedDBObject(DBObject obj, bool add)
        {
            trx.AddNewlyCreatedDBObject(obj, add);
        }

        public override void Commit()
        {
            trx.Commit();
        }

        public override DBObject GetObject(ObjectId id, OpenMode mode)
        {
            return trx.GetObject(id, mode);
        }

        public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased)
        {
            return trx.GetObject(id, mode, openErased);
        }

        public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer)
        {
            return trx.GetObject(id, mode, openErased, forceOpenOnLockedLayer);
        }

        public override TransactionManager TransactionManager
        {
            get { return base.TransactionManager; }
        }

        public override void Abort()
        {
            trx.Abort();
        }


    }


    //public sealed class ReadOnlyTransaction : ITransaction
    //{

    //    public DBObject GetDBObject(ObjectId objid, bool openErased, bool forceOpenOnLockedLayer)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public DBObject GetDBObject(ObjectId objid, bool openErased)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        throw new NotImplementedException();
    //    }


    //    public void Abort()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Add(DBObject obj)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Commit()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}


//public sealed class ReadOnlyTransaction : ITransaction
//{
//    private Autodesk.AutoCAD.DatabaseServices.Transaction m_trans;

//    public ReadOnlyTransaction()
//    {
//    }

//    public ReadOnlyTransaction(Database db)
//    {
//        this.Init(db);
//    }

//    private void Commit()
//    {
//        if (m_trans != null)
//        {
//            this.m_trans.Commit();
//            this.m_trans.Dispose();
//            this.m_trans = null;
//        }
//    }

//    public void Dispose()
//    {
//        this.Commit();
//    }

//    public DBObject GetObject(ObjectId objid)
//    {
//        return this.GetObject(objid, false);
//    }

//    public DBObject GetObject(ObjectId objid, bool openErased)
//    {
//        DebugUtil.Assert(this.m_trans != null);
//        DBObject obj2 = null;
//        try
//        {
//            obj2 = this.m_trans.GetObject(objid, OpenMode.ForRead, openErased);
//        }
//        catch (Autodesk.AutoCAD.Runtime.Exception exception)
//        {
//            if (exception.ErrorStatus != ErrorStatus.WasErased)
//            {
//                throw exception;
//            }
//        }
//        return obj2;
//    }

//    private bool Init(Database db)
//    {
//        Commit();
//        DebugUtil.Assert(db != null, "null db parameter in readonly transaction Init");
//        m_trans = db.TransactionManager.StartTransaction();
//        DebugUtil.Assert(this.m_trans != null, "failed to initialize readonly transaction");
//        return (this.m_trans != null);
//    }

//    public Transaction Transaction
//    {
//        get
//        {
//            return m_trans;
//        }
//    }
//}