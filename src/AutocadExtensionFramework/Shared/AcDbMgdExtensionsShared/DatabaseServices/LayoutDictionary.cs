using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.DatabaseServices.Wrapper;

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
