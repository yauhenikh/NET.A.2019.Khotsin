namespace BookListServiceLibrary
{
    /// <summary>
    /// Interface for logger classes
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the message to mark the entry and exit of functions, for purposes of performance profiling
        /// </summary>
        /// <param name="message">Log message</param>
        void Trace(string message);

        /// <summary>
        /// Writes the message - additional information about application behavior
        /// </summary>
        /// <param name="message">Log message</param>
        void Debug(string message);

        /// <summary>
        /// Writes message - application events for general purposes
        /// </summary>
        /// <param name="message">Log message</param>
        void Info(string message);

        /// <summary>
        /// Writes message - application events that may be an indication of a problem
        /// </summary>
        /// <param name="message">Log message</param>
        void Warn(string message);

        /// <summary>
        /// Writes message - typically logged in the catch block a try/catch block, includes the exception and contextual data
        /// </summary>
        /// <param name="message">Log message</param>
        void Error(string message);

        /// <summary>
        /// Writes message - a critical error that results in the termination of an application
        /// </summary>
        /// <param name="message">Log message</param>
        void Fatal(string message);
    }
}
