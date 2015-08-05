using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autodesk.AutoCAD.DatabaseServices
{

    public enum ObjectIdTypeCode
    {
        SoftPointerId = 330,
        HardPointerId = 340,
        SoftOwnershipId = 350,
        HardOwnershipId = 360
    }
    public enum OverruleStatus
    {
        Off= 0,
        On = 1
    }
    [Flags]
    public enum OsnapMode : short
    {
        None = 0,
        Endpoint = 1,
        Midpoint = 2,
        Center = 4,
        Node = 8,
        Quadrant = 16,
        Intersection = 32,
        Insertion = 64,
        Perpendicular = 128,
        Tangent = 256,
        Nearest = 512,
        Quick = 1024,
        ApparentIntersection = 2048,
        Extension = 4096,
        Parallel = 8192,
    }

    public enum ColorIndex : short
    {
        BYBLOCK = 0,
        Red = 1,
        Yellow = 2,
        Green = 3,
        Cyan = 4,
        Blue = 5,
        Magenta = 6,
        White = 7,
        BYLAYER = 256
    }
    public enum TypeCode
    {
        Invalid = -9999,
        XDictionary = -6,
        PReactors = -5,
        Operator = -4,
        XDataStart = -3,
        FirstEntityId = -2,
        HeaderId = -2,
        End = -1,
        Start = 0,
        XRefPath = 1,
        Text = 1,
        AttributeTag = 2,
        ShapeName = 2,
        BlockName = 2,
        SymbolTableName = 2,
        MlineStyleName = 2,
        SymbolTableRecordName = 2,
        Description = 3,
        TextFontFile = 3,
        AttributePrompt = 3,
        LinetypeProse = 3,
        DimStyleName = 3,
        DimPostString = 3,
        CLShapeName = 4,
        DimensionAlternativePrefixSuffix = 4,
        TextBigFontFile = 4,
        SymbolTableRecordComments = 4,
        Handle = 5,
        DimensionBlock = 5,
        LinetypeName = 6,
        DimBlk1 = 6,
        DimBlk2 = 7,
        TextStyleName = 7,
        LayerName = 8,
        CLShapeText = 9,
        XCoordinate = 10,
        YCoordinate = 20,
        ZCoordinate = 30,
        Elevation = 38,
        Thickness = 39,
        TxtSize = 40,
        ViewportHeight = 40,
        Real = 40,
        ViewWidth = 41,
        TxtStyleXScale = 41,
        ViewportAspect = 41,
        TxtStylePSize = 42,
        ViewLensLength = 42,
        ViewFrontClip = 43,
        ViewBackClip = 44,
        ShapeXOffset = 44,
        ViewHeight = 45,
        ShapeYOffset = 45,
        ShapeScale = 46,
        PixelScale = 47,
        LinetypeScale = 48,
        DashLength = 49,
        MlineOffset = 49,
        LinetypeElement = 49,
        ViewportSnapAngle = 50,
        Angle = 50,
        ViewportTwist = 51,
        Visibility = 60,
        LayerLinetype = 61,
        Color = 62,
        HasSubentities = 66,
        ViewportVisibility = 67,
        ViewportActive = 68,
        ViewportNumber = 69,
        Int16 = 70,
        ViewMode = 71,
        TxtStyleFlags = 71,
        RegAppFlags = 71,
        CircleSides = 72,
        LinetypeAlign = 72,
        ViewportZoom = 73,
        LinetypePdc = 73,
        ViewportIcon = 74,
        ViewportSnap = 75,
        ViewportGrid = 76,
        ViewportSnapStyle = 77,
        ViewportSnapPair = 78,
        Int32 = 90,
        Subclass = 100,
        EmbeddedObjectStart = 101,
        ControlString = 102,
        DimVarHandle = 105,
        UcsOrg = 110,
        UcsOrientationX = 111,
        UcsOrientationY = 112,
        XReal = 140,
        ViewBrightness = 141,
        ViewContrast = 142,
        Int64 = 160,
        XInt16 = 170,
        NormalX = 210,
        NormalY = 220,
        NormalZ = 230,
        XXInt16 = 270,
        Int8 = 280,
        RenderMode = 281,
        Bool = 290,
        XTextString = 300,
        BinaryChunk = 310,
        ArbitraryHandle = 320,
        SoftPointerId = 330,
        HardPointerId = 340,
        SoftOwnershipId = 350,
        HardOwnershipId = 360,
        LineWeight = 370,
        PlotStyleNameType = 380,
        PlotStyleNameId = 390,
        ExtendedInt16 = 400,
        LayoutName = 410,
        ColorRgb = 420,
        ColorName = 430,
        Alpha = 440,
        GradientObjType = 450,
        GradientPatType = 451,
        GradientTintType = 452,
        GradientColCount = 453,
        GradientAngle = 460,
        GradientShift = 461,
        GradientTintVal = 462,
        GradientColVal = 463,
        GradientName = 470,
        Comment = 999

    }

    public enum XDataTypeCode
    {
        AsciiString = 1000,
        RegAppName = 1001,
        ControlString = 1002,
        LayerName = 1003,
        BinaryChunk = 1004,
        Handle = 1005,
        XCoordinate = 1010,
        WorldXCoordinate = 1011,
        WorldXDisp = 1012,
        WorldXDir = 1013,
        YCoordinate = 1020,
        WorldYCoordinate = 1021,
        WorldYDisp = 1022,
        WorldYDir = 1023,
        ZCoordinate = 1030,
        WorldZCoordinate = 1031,
        WorldZDisp = 1032,
        WorldZDir = 1033,
        Real = 1040,
        Dist = 1041,
        Scale = 1042,
        Integer16 = 1070,
        Integer32 = 1071
    }
    public enum XrecordTypeCode
    {
        String = 1,
        Point3d = 10,
        Integer = 90,
        Double = 140,
        Int64 = 160,
        Int16 = 170,
        Int8 = 280,
        Handle = 320,
        SoftPointerId = 330,
        HardPointerId = 340,
        SoftOwnershipId = 350,
        HardOwnershipId = 360
    }
    public enum ResultTypeCode : int
    {
        RTNONE = 0x1388,
        RTREAL = 0x1389,
        RTPOINT = 0x138a,
        RTSHORT = 0x138b,
        RTANG = 5004,
        RTSTR = 0x138d,
        RTENAME = 0x138e,
        RTPICKS = 0x138f,
        RTORINT = 5008,
        RT3DPOINT = 0x1391,
        RTLONG = 0x1392,
        RTVOID = 5014,
        RTLB = 5016,
        RTLE = 5017,
        RTDOTE = 5018,
        RTNIL = 5019,
        RTDXF0 = 5020,
        RTT = 5021,
        RTRESBUF = 5023,
        RTMODELESS = 5027,
        RTINT64 = 5031
    }

       [Flags]
       public enum SymbolTableRecordFilter
       {
           None = 0,
           IncludedErased = 1,
           IncludeDependent = 2,
           IncludedErasedAndDependent = IncludedErased | IncludeDependent
       }
       public static class SymbolTableRecordFilterExtensions
       {
           public static bool IsSet(this SymbolTableRecordFilter filter, SymbolTableRecordFilter testFlag)
           {
               if (testFlag == 0)
               {
                   throw new ArgumentNullException("testFlag");
               }
               return (filter & testFlag) == testFlag;
           }
       }
}
