namespace TimerLibrary
{
    /// <summary>
    /// Represents class for objects, containing event data
    /// </summary>
    public class TimerEventArgs
    {
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="message">Given message</param>
        /// <param name="milliseconds">Given number of milliseconds</param>
        public TimerEventArgs(string message, int milliseconds)
        {
            Message = message;
            Milliseconds = milliseconds;
        }

        /// <summary>
        /// String message
        /// </summary>
        public string Message { get; }

        /// <summary>
        /// Number of milliseconds
        /// </summary>
        public int Milliseconds { get; }
    }
}