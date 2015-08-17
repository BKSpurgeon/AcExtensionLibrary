namespace Autodesk.AutoCAD.DatabaseServices
{
    public static class ProxyEntityExtensions
    {
        public static bool IsErasable(this ProxyEntity proxy)
        {
            return (proxy.ProxyFlags & 1) == 1;
        }
    }
}
