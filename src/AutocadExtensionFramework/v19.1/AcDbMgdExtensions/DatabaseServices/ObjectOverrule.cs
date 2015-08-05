using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.Runtime;

namespace Autodesk.AutoCAD.DatabaseServices
{
    //public abstract class ObjectOverrule<T> : ObjectOverrule
    //where T : DBObject
    //{
    //    bool _enabled = false;
    //    RXClass rxclass = RXObject.GetClass(typeof(T));

    //    protected ObjectOverrule(bool enabled = true)
    //    {
    //        Enabled = enabled;
    //    }

    //    public virtual bool Enabled
    //    {
    //        get
    //        {
    //            return this._enabled;
    //        }
    //        set
    //        {
    //            if (this._enabled ^ val)
    //            {
    //                this._enabled = val;
    //                if (val)
    //                    Overrule.AddOverrule(rxclass, this, true);
    //                else
    //                    Overrule.RemoveOverrule(rxclass, this);
    //                OnEnabledChanged(this._enabled);
    //            }
    //        }
    //    }

    //    protected virtual void OnEnabledChanged(bool enabled)
    //    {
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing && !base.IsDisposed)
    //            Enabled = false;
    //        base.Dispose(disposing);
    //    }

    //    public bool IsRegistered()
    //    {
    //        try
    //        {
    //            //The Overrule.HasOverrule() method only works with a particular RXObject instance!
    //            //Overrule.HasOverrule(RXObject object, RXClass class);

    //            //So we have to work around the issue using the AddOverrule and RemoveOverrule call!
    //            //It is not perfect, but it works!
    //            Overrule.AddOverrule(rxclass, this, true);
    //            Overrule.RemoveOverrule(rxclass, this);

    //            return false;
    //        }
    //        catch (System.Exception ex)
    //        {
    //            if (ex is Autodesk.AutoCAD.Runtime.Exception && (ex as Autodesk.AutoCAD.Runtime.Exception).ErrorStatus == ErrorStatus.DuplicateKey)
    //                return true;
    //            else
    //                throw ex;
    //        }
    //    }
    //}

    public abstract class ObjectOverrule<T> : ObjectOverrule where T : DBObject
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

        protected ObjectOverrule(OverruleStatus status = OverruleStatus.On)
        {
            Status = status;
        }

    }
}
