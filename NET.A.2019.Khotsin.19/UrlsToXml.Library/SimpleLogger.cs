using System;
using System.IO;

namespace UrlsToXml.Library
{
    /// <summary>
    /// Represents custom logger with simple functionality
    /// </summary>
    public class SimpleLogger : ILogger
    {
        private readonly string _filePath;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="filePath">Path to log file</param>
        public SimpleLogger(string filePath = "SimpleLogFile.log")
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Writes the message to mark the entry and exit of functions, for purposes of performance profiling
        /// </summary>
        /// <param name="message">Log message</param>
        public void Trace(string message)
        {
            string dateTime = DateTime.Now.ToString();
            message = dateTime + " Trace " + message;
            this.WriteToFile(message);
        }

        /// <summary>
        /// Writes the message - additional information about application behavior
        /// </summary>
        /// <param name="message">Log message</param>
        public void Debug(string message)
        {
            string dateTime = DateTime.Now.ToString();
            message = dateTime + " Debug " + message;
            this.WriteToFile(message);
        }

        /// <summary>
        /// Writes message - application events for general purposes
        /// </summary>
        /// <param name="message">Log message</param>
        public void Info(string message)
        {
            string dateTime = DateTime.Now.ToString();
            message = dateTime + " Info " + message;
            this.WriteToFile(message);
        }

        /// <summary>
        /// Writes message - application events that may be an indication of a problem
        /// </summary>
        /// <param name="message">Log message</param>
        public void Warn(string message)
        {
            string dateTime = DateTime.Now.ToString();
            message = dateTime + " Warn " + message;
            this.WriteToFile(message);
        }

        /// <summary>
        /// Writes message - typically logged in the catch block a try/catch block, includes the exception and contextual data
        /// </summary>
        /// <param name="message">Log message</param>
        public void Error(string message)
        {
            string dateTime = DateTime.Now.ToString();
            message = dateTime + " Error " + message;
            this.WriteToFile(message);
        }

        /// <summary>
        /// Writes message - a critical error that results in the termination of an application
        /// </summary>
        /// <param name="message">Log message</param>
        public void Fatal(string message)
        {
            string dateTime = DateTime.Now.ToString();
            message = dateTime + " Fatal " + message;
            this.WriteToFile(message);
        }

        /// <summary>
        /// Writes the string to the file
        /// </summary>
        /// <param name="message">The string to write to the file</param>
        private void WriteToFile(string message)
        {
            using (StreamWriter writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine(message);
                writer.Flush();
            }
        }
    }
}
