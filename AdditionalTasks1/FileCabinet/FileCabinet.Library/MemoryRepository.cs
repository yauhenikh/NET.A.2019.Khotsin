using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace FileCabinet.Library
{
    /// <summary>
    /// Represents memory repository class
    /// </summary>
    public class MemoryRepository : IRepository
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MemoryRepository()
        {
            Records = new List<Record>();
        }

        /// <summary>
        /// Number of records in repository
        /// </summary>
        public int Count
        {
            get
            {
                return Records.Count;
            }
        }

        /// <summary>
        /// Value of maximum id of records in repository
        /// </summary>
        public int MaxId
        {
            get
            {
                return Count == 0 ? 0 : Records.Max(rec => Convert.ToInt32(rec.Id.Substring(1)));
            }
        }

        /// <summary>
        /// Path to the csv file used for export
        /// </summary>
        public string ExportCsvFilePath { get; } = "data.csv";

        /// <summary>
        /// Path to the xml file used for export
        /// </summary>
        public string ExportXmlFilePath { get; } = "data.xml";

        /// <summary>
        /// List of records in repository
        /// </summary>
        protected List<Record> Records { get; set; }

        /// <summary>
        /// Retrieves indexed value
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Indexed value</returns>
        public Record this[string index]
        {
            get
            {
                return FindById(index);
            }

            private set
            {
                var record = this[index];
                record.FirstName = value.FirstName;
                record.LastName = value.LastName;
                record.DateOfBirth = value.DateOfBirth;
            }
        }

        /// <summary>
        /// Adds new record to the repository
        /// </summary>
        /// <param name="record">Record to add</param>
        public virtual void Add(Record record)
        {
            Records.Add(record);
        }

        /// <summary>
        /// Updates record in the repository
        /// </summary>
        /// <param name="record">Record to update</param>
        public virtual void Update(Record record)
        {
            var recordToUpdate = this[record.Id];

            if (recordToUpdate != null)
            {
                this[record.Id] = record;
            }
        }

        /// <summary>
        /// Gets all records in the repository
        /// </summary>
        /// <returns>Sequence of records in the repository</returns>
        public IEnumerable<Record> GetAll()
        {
            foreach (var record in Records)
            {
                yield return record;
            }
        }

        /// <summary>
        /// Finds records by tag
        /// </summary>
        /// <param name="tag">Tag for searching</param>
        /// <param name="search">Search query string</param>
        /// <returns>Sequence containing found books</returns>
        public IEnumerable<Record> FindByTag(string tag, string search)
        {
            foreach (var record in Records)
            {
                string value = GetPropValue(record, tag).ToString();

                if (value == search)
                {
                    yield return record;
                }
            }
        }

        /// <summary>
        /// Exports all records to csv file
        /// </summary>
        public void ExportCsv()
        {
            using (StreamWriter sw = new StreamWriter(ExportCsvFilePath, false))
            {
                foreach (var record in Records)
                {
                    sw.WriteLine($"{record.Id},{record.FirstName.Replace(",", "")}," +
                        $"{record.LastName.Replace(",", "")},{record.DateOfBirth}");
                }
            }
        }

        /// <summary>
        /// Exports all records to xml file
        /// </summary>
        public void ExportXml()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));

            using (FileStream fs = new FileStream(ExportXmlFilePath, FileMode.Create))
            {
                formatter.Serialize(fs, Records);
            }
        }

        /// <summary>
        /// Imports all records from csv file to repository
        /// </summary>
        /// <param name="filePath">Path to csv file</param>
        public virtual void ImportCsv(string filePath)
        {
            List<Record> recordsInFile = new List<Record>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    string id = parts[0];
                    string firstName = parts[1];
                    string lastName = parts[2];
                    DateTime dateOfBirth = Convert.ToDateTime(parts[3]);

                    recordsInFile.Add(new Record
                    {
                        Id = id,
                        FirstName = firstName,
                        LastName = lastName,
                        DateOfBirth = dateOfBirth
                    });
                }

                Records = recordsInFile;
            }
        }

        /// <summary>
        /// Imports all records from xml file to repository
        /// </summary>
        /// <param name="filePath">Path to xml file</param>
        public virtual void ImportXml(string filePath)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(List<Record>));

            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                List<Record> recordsInFile = (List<Record>)formatter.Deserialize(fs);

                Records = recordsInFile;
            }
        }

        /// <summary>
        /// Removes record with given id from the repository
        /// </summary>
        /// <param name="id">Given id</param>
        public virtual void Remove(string id)
        {
            var recordToRemove = this[id];

            if (recordToRemove != null)
            {
                Records.Remove(this[id]);
            }
        }

        /// <summary>
        /// Removes all records from the repository
        /// </summary>
        public virtual void Purge()
        {
            Records.Clear();
        }

        /// <summary>
        /// Gets property value by its name
        /// </summary>
        /// <param name="record">Record to get property value</param>
        /// <param name="propName">Name of the property</param>
        /// <returns>Value of the property</returns>
        private static object GetPropValue(object record, string propName)
        {
            var result = record.GetType().GetProperty(propName).GetValue(record, null);

            if (propName == "DateOfBirth")
            {
                result = ((DateTime)result).ToShortDateString();
            }

            return result;
        }

        /// <summary>
        /// Finds record by given id
        /// </summary>
        /// <param name="id">Given id</param>
        /// <returns>Record with given id</returns>
        private Record FindById(string id)
        {
            return Records.Find(rec => rec.Id == id);
        }
    }
}
