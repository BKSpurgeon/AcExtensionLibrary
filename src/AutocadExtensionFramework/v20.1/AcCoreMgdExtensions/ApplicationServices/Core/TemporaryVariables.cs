using System;
using System.Collections.Generic;

namespace Autodesk.AutoCAD.ApplicationServices.Core
{
    /// <summary>
    ///
    /// </summary>
    public class TemporarySystemVariables : Settings.SystemVariables, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TemporarySystemVariables"/> class.
        /// </summary>
        public TemporarySystemVariables()
        {
        }

        /// <summary>
        /// The _variables
        /// </summary>
        private Dictionary<string, object> _variables = new Dictionary<string, object>();

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified name.
        /// </summary>
        /// <value>
        /// The <see cref="System.Object"/>.
        /// </value>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public override object this[string name]
        {
            get
            {
                return base[name];
            }
            set
            {
                if (base[name] != value)
                {
                    if (!_variables.ContainsKey(name))
                    {
                        _variables.Add(name, base[name]);
                    }
                    base[name] = value;
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            foreach (var variable in _variables)
            {
                base[variable.Key] = variable.Value;
            }
            _variables.Clear();
        }
    }
}