namespace TimerLibrary
{
    /// <summary>
    /// Class for validation
    /// </summary>
    internal static class Validator
    {
        /// <summary>
        /// Determines if milliseconds value is valid
        /// </summary>
        /// <param name="millisecondsTimeout">Given milliseconds</param>
        /// <returns>True, if milliseconds value is valid</returns>
        internal static bool IsMillisecondsTimeoutValid(int millisecondsTimeout)
        {
            if (millisecondsTimeout < 0)
            {
                return false;
            }

            return true;
        }
    }
}
