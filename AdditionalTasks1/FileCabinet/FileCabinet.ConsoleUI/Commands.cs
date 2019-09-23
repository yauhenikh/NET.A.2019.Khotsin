using System;
using System.Collections.Generic;
using FileCabinet.Library;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace FileCabinet.ConsoleUI
{
    /// <summary>
    /// Represents different commands to execute in console application
    /// </summary>
    public class Commands
    {
        private IRepository _repository;
        private Logger _logger;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="repository">Given repository</param>
        public Commands(IRepository repository)
        {
            _repository = repository;

            ConfigureLogger();
        }

        /// <summary>
        /// Creates new record
        /// </summary>
        public void CreateCommand()
        {
            _logger.Info("Executing \"create\" command...");

            Console.Write("First name: ");
            string firstName = Console.ReadLine().Replace("\"", string.Empty);
            Console.Write("Last name: ");
            string lastName = Console.ReadLine().Replace("\"", string.Empty);
            Console.Write("Date of birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            string id = "#" + (_repository.MaxId + 1);

            Record record = new Record
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            _logger.Info($"Adding record ({id}, {firstName}, {lastName}, {dateOfBirth})...");

            _repository.Add(record);

            Console.WriteLine($"Record {id} is created");

            _logger.Info($"\"create\" command successfully executed");
        }

        /// <summary>
        /// Shows list with all records
        /// </summary>
        /// <param name="args">Arguments for list command</param>
        public void ListCommand(params string[] args)
        {
            _logger.Info("Executing \"list\" command...");

            if (args.Length == 0)
            {
                foreach (var record in _repository.GetAll())
                {
                    Console.WriteLine($"{record.Id}, {record.FirstName}, {record.LastName}");
                }

                _logger.Info($"\"list\" command successfully executed");
                return;
            }

            foreach (var record in _repository.GetAll())
            {
                string line = string.Empty;

                for (int i = 0; i < args.Length; i++)
                {
                    string tag = args[i].Replace("\"", string.Empty).Replace(",", string.Empty);

                    switch (tag)
                    {
                        case "id":
                            line += record.Id + ", ";
                            break;
                        case "firstname":
                            line += record.FirstName + ", ";
                            break;
                        case "lastname":
                            line += record.LastName + ", ";
                            break;
                        case "dateofbirth":
                            line += record.DateOfBirth.ToShortDateString() + ", ";
                            break;
                    }
                }

                if (line != string.Empty)
                {
                    line = line.Remove(line.Length - 2);
                    Console.WriteLine(line);
                }
            }

            _logger.Info($"\"list\" command successfully executed");
        }

        /// <summary>
        /// Shows number of records
        /// </summary>
        public void StatCommand()
        {
            _logger.Info("Executing \"stat\" command...");

            Console.WriteLine($"{_repository.Count} records");

            _logger.Info($"\"stat\" command successfully executed");
        }

        /// <summary>
        /// Finds record by given arguments
        /// </summary>
        /// <param name="args">Arguments for find command</param>
        public void FindCommand(params string[] args)
        {
            _logger.Info("Executing \"find\" command...");

            List<string> foundEntries = new List<string>();

            for (int i = 0; i < args.Length; i += 2)
            {
                string tag = args[i];
                string search = args[i + 1];

                search = search.Replace("\"", string.Empty).Replace(",", string.Empty);

                string propName = string.Empty;

                switch (tag)
                {
                    case "firstname":
                        propName = "FirstName";
                        break;
                    case "lastname":
                        propName = "LastName";
                        break;
                    case "dateofbirth":
                        propName = "DateOfBirth";
                        break;
                }

                if (propName != string.Empty)
                {
                    foreach (var record in _repository.FindByTag(propName, search))
                    {
                        if (!foundEntries.Contains(record.Id))
                        {
                            foundEntries.Add(record.Id);
                            Console.WriteLine(record.Id);
                        }
                    }
                }
            }

            _logger.Info($"\"find\" command successfully executed");
        }

        /// <summary>
        /// Edits record
        /// </summary>
        /// <param name="id">Id of editing record</param>
        public void EditCommand(string id)
        {
            _logger.Info("Executing \"edit\" command...");

            if (_repository[id] == null)
            {
                _logger.Info($"Record with id {id} not found");
                _logger.Info($"\"edit\" command successfully executed");
                return;
            }

            _logger.Info($"Editing record {id}...");

            Console.Write("First name: ");
            string firstName = Console.ReadLine().Replace("\"", string.Empty);
            Console.Write("Last name: ");
            string lastName = Console.ReadLine().Replace("\"", string.Empty);
            Console.Write("Date of birth: ");
            DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

            Record record = new Record
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            _repository.Update(record);

            Console.WriteLine($"Record {id} is edited");

            _logger.Info($"\"edit\" command successfully executed");
        }

        /// <summary>
        /// Exports records to csv file
        /// </summary>
        public void ExportCsvCommand()
        {
            _logger.Info("Executing \"export csv\" command...");

            _repository.ExportCsv();

            Console.WriteLine($"{_repository.Count} records exported to {_repository.ExportCsvFilePath}");

            _logger.Info($"\"export csv\" command successfully executed");
        }

        /// <summary>
        /// Exports records to xml file
        /// </summary>
        public void ExportXmlCommand()
        {
            _logger.Info("Executing \"export xml\" command...");

            _repository.ExportXml();

            Console.WriteLine($"{_repository.Count} records exported to {_repository.ExportXmlFilePath}");

            _logger.Info($"\"export xml\" command successfully executed");
        }

        /// <summary>
        /// Imports records from csv file
        /// </summary>
        /// <param name="filePath">Path to csv file</param>
        public void ImportCsvCommand(string filePath)
        {
            _logger.Info("Executing \"import csv\" command...");

            _repository.ImportCsv(filePath);

            Console.WriteLine($"{_repository.Count} records imported from {filePath}");

            _logger.Info("\"import csv\" command successfully executed");
        }

        /// <summary>
        /// Imports records from xml file
        /// </summary>
        /// <param name="filePath">Path to xml file</param>
        public void ImportXmlCommand(string filePath)
        {
            _logger.Info("Executing \"import xml\" command...");

            _repository.ImportXml(filePath);

            Console.WriteLine($"{_repository.Count} records imported from {filePath}");

            _logger.Info("\"import xml\" command successfully executed");
        }

        /// <summary>
        /// Removes record with given id
        /// </summary>
        /// <param name="id">Given id</param>
        public void RemoveCommand(string id)
        {
            _logger.Info("Executing \"remove\" command...");

            if (_repository[id] == null)
            {
                _logger.Info($"Record with id {id} not found");
                _logger.Info($"\"remove\" command successfully executed");
                return;
            }

            _logger.Info($"Removing record {id}...");

            _repository.Remove(id);

            Console.WriteLine($"Record {id} is removed");

            _logger.Info("\"remove\" command successfully executed");
        }

        /// <summary>
        /// Removes all records
        /// </summary>
        public void PurgeCommand()
        {
            _logger.Info("Executing \"purge\" command...");

            _repository.Purge();

            Console.WriteLine("All records are removed");

            _logger.Info("\"purge\" command successfully executed");
        }

        /// <summary>
        /// Consfigures logger
        /// </summary>
        private void ConfigureLogger()
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
    }
}
