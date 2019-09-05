using System;

namespace Matrix.Library
{
    /// <summary>
    /// Represents class for objects, containing event data
    /// </summary>
    public class ElementChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="message">Given message</param>
        public ElementChangedEventArgs(string message) : base()
        {
            this.Message = message;
        }

        /// <summary>
        /// String message
        /// </summary>
        public string Message { get; }
    }
}
