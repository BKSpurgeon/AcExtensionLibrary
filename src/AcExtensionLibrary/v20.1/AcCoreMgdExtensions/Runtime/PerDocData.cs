using Autodesk.AutoCAD.ApplicationServices;
using System;
using System.Collections.Generic;

namespace Autodesk.AutoCAD.Runtime
{
    /// <summary>
    ///
    /// </summary>
    public class PerDocData : IDisposable
    {
        /// <summary>
        /// The document data dictionary
        /// </summary>
        private static Dictionary<Document, PerDocData> docDataDictionary = new Dictionary<Document, PerDocData>();

        /// <summary>
        /// Initializes the <see cref="PerDocData"/> class.
        /// </summary>
        static PerDocData()
        {
        }

        /// <summary>
        /// Creates the specified document.
        /// </summary>
        /// <param name="doc">The document.</param>
        /// <returns></returns>
        public static PerDocData Create(Document doc)
        {
            if (doc != null)
            {
            }
            if (docDataDictionary.ContainsKey(doc))
            {
                return docDataDictionary[doc];
            }
            else
            {
                var data = new PerDocData(doc);
                docDataDictionary.Add(doc, data);
                return data;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The is disposed
        /// </summary>
        private bool isDisposed = false;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (isDisposed) return;
            if (disposing)
            {
                docDataDictionary.Remove(document);
                document = null;
            }
            isDisposed = true;
        }

        /// <summary>
        /// Gets or sets the document.
        /// </summary>
        /// <value>
        /// The document.
        /// </value>
        private Document document { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerDocData"/> class.
        /// </summary>
        /// <param name="doc">The document.</param>
        public PerDocData(Document doc)
        {
            document = doc;
        }
    }
}