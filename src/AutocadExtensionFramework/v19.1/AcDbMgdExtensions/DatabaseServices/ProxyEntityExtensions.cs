using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class ProxyEntityExtensions
    {
        public static bool IsErasable(this ProxyEntity proxy)
       {
           return (proxy.ProxyFlags & 1) == 1;
       }
    }
}
