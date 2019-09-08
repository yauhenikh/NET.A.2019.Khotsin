using System.Collections.Generic;

namespace FileCabinet.Library
{
    /// <summary>
    /// Represents interface for repository classes
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Number of records in repository
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Value of maximum id of records in repository
        /// </summary>
        int MaxId { get; }

        /// <summary>
        /// Path to the csv file used for export
        /// </summary>
        string ExportCsvFilePath { get; }

        /// <summary>
        /// Path to the xml file used for export
        /// </summary>
        string ExportXmlFilePath { get; }

        /// <summary>
        /// Retrieves indexed value
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Indexed value</returns>
        Record this[string index] { get; }

        /// <summary>
        /// Adds new record to the repository
        /// </summary>
        /// <param name="record">Record to add</param>
        void Add(Record record);

        /// <summary>
        /// Updates record in the repository
        /// </summary>
        /// <param name="record">Record to update</param>
        void Update(Record record);

        /// <summary>
        /// Gets all records in the repository
        /// </summary>
        /// <returns>Sequence of records in the repository</returns>
        IEnumerable<Record> GetAll();

        /// <summary>
        /// Finds records by tag
        /// </summary>
        /// <param name="tag">Tag for searching</param>
        /// <param name="search">Search query string</param>
        /// <returns>Sequence containing found books</returns>
        IEnumerable<Record> FindByTag(string tag, string search);

        /// <summary>
        /// Exports all records to csv file
        /// </summary>
        void ExportCsv();

        /// <summary>
        /// Exports all records to xml file
        /// </summary>
        void ExportXml();

        /// <summary>
        /// Imports all records from csv file to repository
        /// </summary>
        /// <param name="filePath">Path to csv file</param>
        void ImportCsv(string filePath);

        /// <summary>
        /// Imports all records from xml file to repository
        /// </summary>
        /// <param name="filePath">Path to xml file</param>
        void ImportXml(string filePath);

        /// <summary>
        /// Removes record with given id from the repository
        /// </summary>
        /// <param name="id">Given id</param>
        void Remove(string id);

        /// <summary>
        /// Removes all records from the repository
        /// </summary>
        void Purge();
    }
}
