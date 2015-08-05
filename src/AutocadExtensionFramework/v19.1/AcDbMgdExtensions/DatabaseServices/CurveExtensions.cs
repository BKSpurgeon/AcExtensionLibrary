using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class CurveExtensions
    {
        //Slighty modified from original author Tony Tanzillo
        public static double GetLength(this Curve curve)
        {
            if (curve == null)
            {
                throw new ArgumentNullException("Curve was Null");
            }

            if (curve is Xline || curve is Ray)
            {
                return Double.PositiveInfinity;
            }

            return Math.Abs(curve.GetDistanceAtParameter(curve.EndParam) - curve.GetDistanceAtParameter(curve.StartParam));

        }
    }
}
