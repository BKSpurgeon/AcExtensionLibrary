namespace System
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Indicates if object is null
        /// </summary>
        /// <typeparam name="T">Type of Object</typeparam>
        /// <param name="data">The Object to check</param>
        /// <returns>True if object is null</returns>
        public static bool IsNull<T>(this T data) where T : class
        {
            return data == null;
        }
        /// <summary>
        /// Throws an ArgumentNullException if the given data item is null.
        /// </summary>
        /// <param name="data">The item to check for if null.</param>
        /// <param name="name">Name of parameter to pass to exception</param>
        public static void ThrowIfNull<T>(this T data, string name) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException(name);
            }
        }
        /// <summary>
        /// Throws an ArgumentNullException if the given data item is null.
        /// See overloaded method to pass parameter name
        /// </summary>
        /// <param name="data">The item to check for if null.</param>
        public static void ThrowIfNull<T>(this T data) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
