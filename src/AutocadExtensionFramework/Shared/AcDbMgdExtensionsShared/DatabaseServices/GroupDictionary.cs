using System;
using System.Collections;
using System.Collections.Generic;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices.Wrapper;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public class GroupDictionary : WrapperDBDictionary<Group>
    {
        public GroupDictionary(Transaction trx, DBDictionary dic, bool includingErased)
            : base(trx, dic, includingErased)
        {
            //add methods for dealing with groups
        }
    }
    
}
