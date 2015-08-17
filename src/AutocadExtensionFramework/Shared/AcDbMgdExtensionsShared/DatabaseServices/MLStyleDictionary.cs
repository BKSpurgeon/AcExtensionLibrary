

using Autodesk.AutoCAD.DatabaseServices.Wrapper;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public class MLStyleDictionary : WrapperDBDictionary<MLeaderStyle>
    {
        public MLStyleDictionary(Transaction trx, DBDictionary dic, bool includingErased)
            : base(trx, dic, includingErased)
        {
            //add methods for dealing with Mleaders
        }     
    }
  
}
