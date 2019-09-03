using NLog;
using NLog.Config;
using NLog.Targets;

namespace BookListServiceLibrary
{
    /// <summary>
    /// Represents logger using NLog framework
    /// </summary>
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger;

        /// <summary>
        /// Default constructor
        /// </summary>
        public NLogLogger()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget("NLogFile")
            {
                FileName = "${basedir}/NLogFile.log",
                Layout = "${longdate} ${level} ${message}  ${exception}"
            };

            config.AddTarget(fileTarget);
            config.AddRuleForAllLevels(fileTarget);

            LogManager.Configuration = config;

            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Writes the message to mark the entry and exit of functions, for purposes of performance profiling
        /// </summary>
        /// <param name="message">Log message</param>
        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        /// <summary>
        /// Writes the message - additional information about application behavior
        /// </summary>
        /// <param name="message">Log message</param>
        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        /// <summary>
        /// Writes message - application events for general purposes
        /// </summary>
        /// <param name="message">Log message</param>
        public void Info(string message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// Writes message - application events that may be an indication of a problem
        /// </summary>
        /// <param name="message">Log message</param>
        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        /// <summary>
        /// Writes message - typically logged in the catch block a try/catch block, includes the exception and contextual data
        /// </summary>
        /// <param name="message">Log message</param>
        public void Error(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// Writes message - a critical error that results in the termination of an application
        /// </summary>
        /// <param name="message">Log message</param>
        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
