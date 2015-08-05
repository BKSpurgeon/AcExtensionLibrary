using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Autodesk.AutoCAD.Runtime
{
    [Serializable]
    public class NoActiveTransactionException : System.Exception
    {
        public NoActiveTransactionException() { }
        public NoActiveTransactionException(string message) : base(message) { }
        public NoActiveTransactionException(string message, System.Exception inner) : base(message, inner) { }
        protected NoActiveTransactionException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}
