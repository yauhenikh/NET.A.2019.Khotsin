using System;
using System.Linq;
using System.Text.RegularExpressions;
using FileCabinet.Library;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace FileCabinet.ConsoleUI
{
    /// <summary>
    /// Represents class containing Main method
    /// </summary>
    internal class Program
    {
        private static Logger _logger;

        /// <summary>
        /// Method indicating the start point of application execution
        /// </summary>
        /// <param name="args">Arguments for Main method</param>
        private static void Main(string[] args)
        {
            ConfigureLogger();

            var commands = new Commands(new MemoryRepository());

            // var commands = new Commands(new BinaryFileRepository("data.bin"));
            while (true)
            {
                Console.Write("> ");
                string commandInput = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(commandInput))
                {
                    continue;
                }

                try
                {
                    string[] commandAndArgs = Regex.Split(commandInput, "(?<=^[^\"]*(?:\"[^\"]*\"[^\"]*)*) (?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");

                    string command = commandAndArgs[0];

                    switch (command)
                    {
                        case "create":
                            commands.CreateCommand();
                            break;
                        case "list":
                            var listArgs = GetListCommandArguments(commandAndArgs);
                            commands.ListCommand(listArgs);
                            break;
                        case "stat":
                            commands.StatCommand();
                            break;
                        case "find":
                            var findArgs = GetFindCommandArguments(commandAndArgs);
                            if (findArgs != null)
                            {
                                commands.FindCommand(findArgs);
                            }

                            break;
                        case "edit":
                            var editArg = GetEditCommandArgument(commandAndArgs);
                            if (editArg != null)
                            {
                                commands.EditCommand(editArg);
                            }

                            break;
                        case "export":
                            var exportArg = GetExportCommandArgument(commandAndArgs);
                            if (exportArg == "csv")
                            {
                                commands.ExportCsvCommand();
                            }

                            if (exportArg == "xml")
                            {
                                commands.ExportXmlCommand();
                            }

                            break;
                        case "import":
                            var importArgs = GetImportCommandArguments(commandAndArgs);
                            if (importArgs != null)
                            {
                                if (importArgs[0] == "csv")
                                {
                                    commands.ImportCsvCommand(importArgs[1]);
                                }

                                if (importArgs[0] == "xml")
                                {
                                    commands.ImportXmlCommand(importArgs[1]);
                                }
                            }

                            break;
                        case "remove":
                            var removeArg = GetRemoveCommandArgument(commandAndArgs);
                            if (removeArg != null)
                            {
                                commands.RemoveCommand(removeArg);
                            }

                            break;
                        case "purge":
                            commands.PurgeCommand();
                            break;
                        case "exit":
                            return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    _logger.Error(ex.Message);
                }
            }
        }

        /// <summary>
        /// Configures logger
        /// </summary>
        private static void ConfigureLogger()
        {
            var config = new LoggingConfiguration();
            var fileTarget = new FileTarget("logFile")
            {
                FileName = "${basedir}/logs.log",
                Layout = "${longdate} ${level} ${message}  ${exception}"
            };

            config.AddTarget(fileTarget);
            config.AddRuleForAllLevels(fileTarget);

            LogManager.Configuration = config;

            _logger = LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Gets arguments for list command
        /// </summary>
        /// <param name="commandAndArgs">Array containing command with arguments</param>
        /// <returns>Array of arguments for list command</returns>
        private static string[] GetListCommandArguments(string[] commandAndArgs)
        {
            commandAndArgs = RemoveEmptyEntries(commandAndArgs);

            string[] result = new string[commandAndArgs.Length - 1];
            for (int i = 1; i < commandAndArgs.Length; i++)
            {
                result[i - 1] = commandAndArgs[i];
            }

            return result;
        }

        /// <summary>
        /// Gets arguments for find command
        /// </summary>
        /// <param name="commandAndArgs">Array containing command with arguments</param>
        /// <returns>Array of arguments for find command</returns>
        private static string[] GetFindCommandArguments(string[] commandAndArgs)
        {
            commandAndArgs = RemoveEmptyEntries(commandAndArgs);

            if (commandAndArgs.Length < 3)
            {
                return null;
            }

            int length;

            if (commandAndArgs.Length % 2 != 1)
            {
                length = commandAndArgs.Length - 1;
            }
            else
            {
                length = commandAndArgs.Length;
            }

            string[] result = new string[length - 1];
            for (int i = 1; i < length; i++)
            {
                result[i - 1] = commandAndArgs[i];
            }

            return result;
        }

        /// <summary>
        /// Gets argument for edit command
        /// </summary>
        /// <param name="commandAndArgs">Array containing command with arguments</param>
        /// <returns>Argument for edit command</returns>
        private static string GetEditCommandArgument(string[] commandAndArgs)
        {
            commandAndArgs = RemoveEmptyEntries(commandAndArgs);

            if (commandAndArgs.Length < 2)
            {
                return null;
            }

            return commandAndArgs[1];
        }

        /// <summary>
        /// Gets argument for export command
        /// </summary>
        /// <param name="commandAndArgs">Array containing command with arguments</param>
        /// <returns>Argument for export command</returns>
        private static string GetExportCommandArgument(string[] commandAndArgs)
        {
            commandAndArgs = RemoveEmptyEntries(commandAndArgs);

            if (commandAndArgs.Length < 2)
            {
                return null;
            }

            return commandAndArgs[1];
        }

        /// <summary>
        /// Gets arguments for import command
        /// </summary>
        /// <param name="commandAndArgs">Array containing command with arguments</param>
        /// <returns>Array of arguments for import command</returns>
        private static string[] GetImportCommandArguments(string[] commandAndArgs)
        {
            commandAndArgs = RemoveEmptyEntries(commandAndArgs);

            if (commandAndArgs.Length < 3)
            {
                return null;
            }

            string[] result = new string[2];
            for (int i = 1; i < 3; i++)
            {
                result[i - 1] = commandAndArgs[i];
            }

            return result;
        }

        /// <summary>
        /// Gets argument for remove command
        /// </summary>
        /// <param name="commandAndArgs">Array containing command with arguments</param>
        /// <returns>Argument for import command</returns>
        private static string GetRemoveCommandArgument(string[] commandAndArgs)
        {
            commandAndArgs = RemoveEmptyEntries(commandAndArgs);

            if (commandAndArgs.Length < 2)
            {
                return null;
            }

            return commandAndArgs[1];
        }

        /// <summary>
        /// Removes empty entries in string array
        /// </summary>
        /// <param name="array">Given string array</param>
        /// <returns>String array without empty entries</returns>
        private static string[] RemoveEmptyEntries(string[] array)
        {
            return array.Where(el => !string.IsNullOrEmpty(el)).ToArray();
        }
    }
}
