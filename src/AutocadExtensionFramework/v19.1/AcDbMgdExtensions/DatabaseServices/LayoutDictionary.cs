using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.DatabaseServices.Contracts;
using Autodesk.AutoCAD.DatabaseServices.Wrappers;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public class LayoutDictionary : WrapperDBDictionary<Layout>
    {

        public LayoutDictionary(Transaction trx, DBDictionary dic, bool includingErased)
            : base(trx, dic, includingErased)
        {
            //add methods for dealing with groups
        }


    }
}
