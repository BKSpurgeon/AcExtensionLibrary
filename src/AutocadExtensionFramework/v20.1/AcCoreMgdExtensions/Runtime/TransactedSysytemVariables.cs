using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using System;

namespace Autodesk.AutoCAD.Runtime
{
    /// <summary>
    ///
    /// </summary>
    public class TransactedSysytemVariables : Transaction
    {
        /// <summary>
        /// Gets the transacted variables.
        /// </summary>
        /// <value>
        /// The transacted variables.
        /// </value>
        public TemporarySystemVariables TransactedVariables { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactedSysytemVariables"/> class.
        /// </summary>
        /// <param name="trx">The TRX.</param>
        public TransactedSysytemVariables(Transaction trx) : base(trx.UnmanagedObject, trx.AutoDelete)
        {
            Interop.DetachUnmanagedObject(trx);
            GC.SuppressFinalize(trx);
            TransactedVariables = new TemporarySystemVariables();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactedSysytemVariables"/> class.
        /// </summary>
        /// <param name="db">The database.</param>
        public TransactedSysytemVariables(Database db) : this(db.TransactionManager.StartTransaction())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactedSysytemVariables"/> class.
        /// </summary>
        /// <param name="doc">The document.</param>
        public TransactedSysytemVariables(Document doc) : this(doc.TransactionManager.StartTransaction())
        {
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="A_1"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
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