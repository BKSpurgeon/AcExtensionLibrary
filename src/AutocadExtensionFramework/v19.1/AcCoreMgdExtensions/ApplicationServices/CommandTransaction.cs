//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Autodesk.AutoCAD.ApplicationServices.Core;
//using Autodesk.AutoCAD.DatabaseServices;

//namespace Autodesk.AutoCAD.ApplicationServices
//{
//    public class CommandTransaction : IWriteableTransaction
//    {
//        private Transaction trx;
//        private CommandTransaction()
//        {
            
//        }

//        public static IWriteableTransaction Start()
//        {
            
//        }
//        public void AddNewlyCreatedDBObject(DBObject obj)
//        {
//            throw new NotImplementedException();
//        }

//        public T GetDBObject<T>(ObjectId id, OpenMode mode, bool openErased) where T : DBObject
//        {
//            throw new NotImplementedException();
//        }

//        public T GetEntity<T>(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer) where T : Entity
//        {
//            throw new NotImplementedException();
//        }

//        public void Commit()
//        {
//            throw new NotImplementedException();
//        }

//        public void Abort()
//        {
//            throw new NotImplementedException();
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }


//    }

//    public class Foo
//    {
//        private string name;

//        private Foo()
//        {
            
//        }

//        public class Builder
//        {
//            private Foo foo;

//            public Foo Build()
//            {
//                Foo copy = foo;
//                foo = new Foo();
//                return copy;
//            }
//        }
//    }

//    //interface ICommandTransaction
//    //{
//    //    void Commit();
//    //    void Abort();
//    //    void AddNewlyCreatedDBObject(DBObject obj, bool add);
//    //    DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer);
//    //}
//  //public class CommandTransaction : Transaction
//  //  {
//  //    public override void Abort()
//  //    {
//  //        base.Abort();
//  //    }

//  //    public override void AddNewlyCreatedDBObject(DBObject obj, bool add)
//  //    {
//  //        base.AddNewlyCreatedDBObject(obj, add);
//  //    }

//  //    public override void Commit()
//  //    {
//  //        base.Commit();
//  //    }

//  //    public override DBObject GetObject(ObjectId id, OpenMode mode)
//  //    {
//  //        return base.GetObject(id, mode);
//  //    }

//  //    public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased)
//  //    {
//  //        return base.GetObject(id, mode, openErased);
//  //    }

//  //    public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer)
//  //    {
//  //        return base.GetObject(id, mode, openErased, forceOpenOnLockedLayer);
//  //    }
//  //    public override DatabaseServices.TransactionManager TransactionManager
//  //    {
//  //        get
//  //        {
//  //            return base.TransactionManager;
//  //        }
//  //    }

//  //    protected override void Dispose(bool A_1)
//  //    {
//  //        base.Dispose(A_1);
//  //    }
//  //  }




//  //public class CommandTransactionManager : DatabaseServices.TransactionManager
//  //{
//  //    public override void AddNewlyCreatedDBObject(DBObject obj, bool add)
//  //    {
//  //        base.AddNewlyCreatedDBObject(obj, add);
//  //    }

//  //    public override DBObject GetObject(ObjectId id, OpenMode mode)
//  //    {
//  //        return base.GetObject(id, mode);
//  //    }

//  //    public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased)
//  //    {
//  //        return base.GetObject(id, mode, openErased);
//  //    }

//  //    public override DBObject GetObject(ObjectId id, OpenMode mode, bool openErased, bool forceOpenOnLockedLayer)
//  //    {
//  //        return base.GetObject(id, mode, openErased, forceOpenOnLockedLayer);
//  //    }
//  //    protected override void Dispose(bool A_1)
//  //    {
//  //        base.Dispose(A_1);
//  //    }
//  //  }
//}
