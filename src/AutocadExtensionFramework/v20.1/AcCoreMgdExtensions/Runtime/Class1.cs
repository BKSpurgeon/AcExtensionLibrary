using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;

namespace Autodesk.AutoCAD.Runtime
{
    public class TransActionExtension : Transaction
    {
        public TemporarySystemVariables TransactedVariables { get; }

        public TransActionExtension(Transaction trx) : base(trx.UnmanagedObject, trx.AutoDelete)
        {
            Interop.DetachUnmanagedObject(trx);
            GC.SuppressFinalize(trx);
            TransactedVariables = new TemporarySystemVariables();
        }

        public TransActionExtension(Database db) : this(db.TransactionManager.StartTransaction())
        {

        }
        public TransActionExtension(Document doc) : this(doc.TransactionManager.StartTransaction())
        {

        }
        protected override void Dispose(bool A_1)
        {

            base.Dispose(A_1);
            if (A_1)
            {
                TransactedVariables.Dispose();
            }
        }


    }
}
