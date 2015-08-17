namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class LayerTableRecordExtensions
    {
        public static TypedValue LayerNameTypedValue(this Entity ent)
        {
            return new TypedValue((int) TypeCode.LayerName, ent.Layer);
        }
    }
}
