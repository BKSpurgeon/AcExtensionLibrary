using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Autodesk.AutoCAD.Runtime
{
    [Serializable]
    public class InvalidContextException : System.Exception
    {
        public InvalidContextException() { }
        public InvalidContextException(string message) : base(message) { }
        public InvalidContextException(string message, System.Exception inner) : base(message, inner) { }
        protected InvalidContextException(
          SerializationInfo info,
          StreamingContext context)
            : base(info, context) { }
    }
}
