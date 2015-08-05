//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Autodesk.AutoCAD.DatabaseServices;
//using Autodesk.AutoCAD.Geometry;

//namespace Autodesk.AutoCAD.EditorInput
//{
//   public class AcedCmdResultBuffer
//    {
//        //internal static short RTNONE = 5000; /* No result */
//        static readonly short RTREAL = 5001; /*Real number */
//        static readonly short RTPOINT = 5002; /* 2D point X and Y only */
//        static readonly short RTSHORT = 5003; /* Short integer */
//        //static readonly short RTANG = 5004; /* Angle */
//        static readonly short RTSTR = 5005; /* String */
//        static readonly short RTENAME = 5006; /* Entity name */
//        static readonly short RTPICKS = 5007; /* Pick set */
//        //internal const short RTORINT = 5008; /* Orientation */
//        static readonly short RT3DPOINT = 5009; /* 3D point - X, Y, and Z */
//        static readonly short RTLONG = 5010; /* Long integer */
//        //internal const short RTVOID = 5014; /* Blank symbol */
//        //static readonly short RTLB = 5016; /* list begin */
//        //static readonly short RTLE = 5017; /* list end */
//        //internal const short RTDOTE = 5018; /* dotted pair */
//        //internal const short RTNIL = 5019; /* nil */
//        //internal const short RTDXF0 = 5020; /* DXF code 0 for ads_buildlist only */
//        //internal const short RTT = 5021; /* T atom */
//        //static readonly short RTRESBUF = 5023; /* resbuf */
//        //internal const short RTMODELESS = 5027; /* interrupted by modeless dialog*/
//        //internal const short RTLONG_PTR = 5030; // integer val with pointer precision
//        static readonly short RTINT64 = 5031; // integer val with 64-bit precision

//        public static ResultBuffer CreateBuffer(string value)
//        {
//            return new ResultBuffer(new TypedValue(RTSTR, value));
//        }

//        public static ResultBuffer CreateBuffer(short value)
//        {
//            return new ResultBuffer(new TypedValue(RTSHORT, value));
//        }

//        public static ResultBuffer CreateBuffer(int value)
//        {
//            return new ResultBuffer(new TypedValue(RTLONG, value));
//        }

//        public static ResultBuffer CreateBuffer(long value)
//        {
//            return new ResultBuffer(new TypedValue(RTINT64, value));
//        }

//        public static ResultBuffer CreateBuffer(double value)
//        {
//            return new ResultBuffer(new TypedValue(RTREAL, value));
//        }

//        public static ResultBuffer CreateBuffer(Point2d value)
//        {
//            return new ResultBuffer(new TypedValue(RTPOINT, value));
//        }

//        public static ResultBuffer CreateBuffer(Point3d value)
//        {
//            return new ResultBuffer(new TypedValue(RT3DPOINT, value));
//        }

//        public static ResultBuffer CreateBuffer(ObjectId value)
//        {
//            return new ResultBuffer(new TypedValue(RTENAME, value));
//        }

//        public static ResultBuffer CreateBuffer(SelectionSetDelayMarshalled value)
//        {
//            return new ResultBuffer(new TypedValue(RTPICKS, value), new TypedValue(RTSTR, String.Empty));
//        }

//        public static ResultBuffer CreateBuffer(object value)
//        {
//            Type typ = value.GetType();
//            System.TypeCode typeCode = Type.GetTypeCode(typ);

//            if (typeCode == System.TypeCode.Object)
//            {
//                return ResultBufferFromAcadType(typ, value);
//            }

//            else
//            {
//                return ResultBufferFromCTS(typ, typeCode, value);
//            }
//        }

//        private static ResultBuffer ResultBufferFromAcadType(Type typ, object obj)
//        {
//            if (typ == typeof(Point2d))
//            {
//                return new ResultBuffer(new TypedValue(RTPOINT, obj));
//            }
//            else if (typ == typeof(Point3d))
//            {
//                return new ResultBuffer(new TypedValue(RT3DPOINT, obj));
//            }
//            else if (typ == typeof(ObjectId))
//            {
//                return new ResultBuffer(new TypedValue(RTENAME, obj));
//            }
//            else if (typ == typeof(SelectionSetDelayMarshalled))
//            {
//                return new ResultBuffer(new TypedValue(RTPICKS, obj), new TypedValue(RTSTR, String.Empty));
//            }
//            throw new ArgumentException();
//        }

//        private static ResultBuffer ResultBufferFromCTS(Type typ, System.TypeCode typeCode, object obj)
//        {
//            switch (typeCode)
//            {
//                case System.TypeCode.String:
//                    return new ResultBuffer(new TypedValue(RTSTR, obj));
//                case System.TypeCode.Int16:
//                    return new ResultBuffer(new TypedValue(RTSHORT, obj));
//                case System.TypeCode.Int32:
//                    return new ResultBuffer(new TypedValue(RTLONG, obj));
//                case System.TypeCode.Double:
//                    return new ResultBuffer(new TypedValue(RTREAL, obj));
//                case System.TypeCode.Int64:
//                    return new ResultBuffer(new TypedValue(RTINT64, obj));
//                default:
//                    throw new ArgumentException();
//            }
//        }

//    }
//}
