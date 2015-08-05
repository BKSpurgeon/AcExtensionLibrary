using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public abstract class DrawableOverrule<T> : DrawableOverrule where T : Entity
    {
        private readonly RXClass _targetClass = RXObject.GetClass(typeof(T));
        OverruleStatus _status = OverruleStatus.Off;

        public OverruleStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value == OverruleStatus.On && _status == OverruleStatus.Off)
                {
                    AddOverrule(_targetClass, this, true);
                    _status = OverruleStatus.On;
                }
                else if (value == OverruleStatus.Off && _status == OverruleStatus.On)
                {
                    RemoveOverrule(_targetClass, this);
                    _status = OverruleStatus.Off;
                }
            }
        }

        protected DrawableOverrule(OverruleStatus status = OverruleStatus.On)
        {
            Status = status;
        }

    }
}