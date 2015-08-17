using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Geometry;

namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class TypedValueExtensions
    {
        static readonly short RTREAL = 5001; /*Real number */
        static readonly short RTPOINT = 5002; /* 2D point X and Y only */
        static readonly short RTSHORT = 5003; /* Short integer */
        //static readonly short RTANG = 5004; /* Angle */
        static readonly short RTSTR = 5005; /* String */
        static readonly short RTENAME = 5006; /* Entity name */
        static readonly short RTPICKS = 5007; /* Pick set */
        //internal const short RTORINT = 5008; /* Orientation */
        static readonly short RT3DPOINT = 5009; /* 3D point - X, Y, and Z */
        static readonly short RTLONG = 5010; /* Long integer */
        //internal const short RTVOID = 5014; /* Blank symbol */
        //static readonly short RTLB = 5016; /* list begin */
        //static readonly short RTLE = 5017; /* list end */
        //internal const short RTDOTE = 5018; /* dotted pair */
        //internal const short RTNIL = 5019; /* nil */
        //internal const short RTDXF0 = 5020; /* DXF code 0 for ads_buildlist only */
        //internal const short RTT = 5021; /* T atom */
        //static readonly short RTRESBUF = 5023; /* resbuf */
        //internal const short RTMODELESS = 5027; /* interrupted by modeless dialog*/
        //internal const short RTLONG_PTR = 5030; // integer val with pointer precision
        static readonly short RTINT64 = 5031; // integer val with 64-bit precision

        public static TypedValue CreateTypedValue(string value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(short value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(int value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(long value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(double value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(Point2d value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(Point3d value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(ObjectId value)
        {
            return value.ToTypedValue();
        }

        public static TypedValue CreateTypedValue(SelectionSetDelayMarshalled value)
        {
            return value.ToTypedValue();
        }


        public static TypedValue ToTypedValue(this string value)
        {
            return new TypedValue(RTSTR, value);
        }

        public static TypedValue ToTypedValue(this short value)
        {
            return new TypedValue(RTSHORT, value);
        }

        public static TypedValue ToTypedValue(this int value)
        {
            return new TypedValue(RTLONG, value);
        }

        public static TypedValue ToTypedValue(this long value)
        {
            return new TypedValue(RTINT64, value);
        }

        public static TypedValue ToTypedValue(this double value)
        {
            return new TypedValue(RTREAL, value);
        }

        public static TypedValue ToTypedValue(this Point2d value)
        {
            return new TypedValue(RTPOINT, value);
        }

        public static TypedValue ToTypedValue(this Point3d value)
        {
            return new TypedValue(RT3DPOINT, value);
        }

        public static TypedValue ToTypedValue(this ObjectId value)
        {
            return new TypedValue(RTENAME, value);
        }

        public static TypedValue ToTypedValue(this SelectionSetDelayMarshalled value)
        {
            return new TypedValue(RTPICKS, value);
        }

        public static TypedValue ToTypedValue(this object value)
        {
            Type typ = value.GetType();
            System.TypeCode typeCode = Type.GetTypeCode(typ);

            return typeCode == System.TypeCode.Object 
                ? TypedValueFromAcadType(typ, value)
                : TypedValueFromCTS(typ, typeCode, value);
        }

        private static TypedValue TypedValueFromAcadType(Type typ, object obj)
        {
            if (typ == typeof(Point2d))
            {
                return new TypedValue(RTPOINT, obj);
            }
            else if (typ == typeof(Point3d))
            {
                return new TypedValue(RT3DPOINT, obj);
            }
            else if (typ == typeof(ObjectId))
            {
                return new TypedValue(RTENAME, obj);
            }
            else if (typ == typeof(SelectionSetDelayMarshalled))
            {
                return new TypedValue(RTPICKS, obj);
            }
            throw new ArgumentException();
        }

        private static TypedValue TypedValueFromCTS(Type typ, System.TypeCode typeCode, object obj)
        {
            switch (typeCode)
            {
                case System.TypeCode.String:
                    return new TypedValue(RTSTR, obj);
                case System.TypeCode.Int16:
                    return new TypedValue(RTSHORT, obj);
                case System.TypeCode.Int32:
                    return new TypedValue(RTLONG, obj);
                case System.TypeCode.Double:
                    return new TypedValue(RTREAL, obj);
                case System.TypeCode.Int64:
                    return new TypedValue(RTINT64, obj);
                default:
                    throw new ArgumentException();
            }
        }
    }
}
