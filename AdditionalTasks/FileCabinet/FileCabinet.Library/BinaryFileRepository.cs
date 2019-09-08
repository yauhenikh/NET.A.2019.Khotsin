using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FileCabinet.Library
{
    /// <summary>
    /// Represents binary file repository class
    /// </summary>
    public class BinaryFileRepository : MemoryRepository
    {
        private readonly string _filePath;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        public BinaryFileRepository(string filePath)
        {
            this._filePath = filePath;
            this.Load(this._filePath);
        }

        /// <summary>
        /// Adds new record to the binary repository
        /// </summary>
        /// <param name="record">Record to add</param>
        public override void Add(Record record)
        {
            base.Add(record);

            this.Rewrite(this._filePath);
        }

        /// <summary>
        /// Updates record in the binary repository
        /// </summary>
        /// <param name="record">Record to update</param>
        public override void Update(Record record)
        {
            base.Update(record);

            this.Rewrite(this._filePath);
        }

        /// <summary>
        /// Imports all records from csv file to the binary repository
        /// </summary>
        /// <param name="filePath">Path to csv file</param>
        public override void ImportCsv(string filePath)
        {
            base.ImportCsv(filePath);

            this.Rewrite(this._filePath);
        }

        /// <summary>
        /// Imports all records from xml file to the binary repository
        /// </summary>
        /// <param name="filePath">Path to xml file</param>
        public override void ImportXml(string filePath)
        {
            base.ImportXml(filePath);

            this.Rewrite(this._filePath);
        }

        /// <summary>
        /// Removes record with given id from the binary repository
        /// </summary>
        /// <param name="id">Given id</param>
        public override void Remove(string id)
        {
            base.Remove(id);

            this.Rewrite(this._filePath);
        }

        /// <summary>
        /// Removes all records from the binary repository
        /// </summary>
        public override void Purge()
        {
            base.Purge();

            this.Rewrite(this._filePath);
        }

        /// <summary>
        /// Load records from binary file
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        private void Load(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    List<Record> deserializeRecords = (List<Record>)formatter.Deserialize(fs);

                    this.Records = deserializeRecords;
                }
            }
        }

        /// <summary>
        /// Rewrites binary file
        /// </summary>
        /// <param name="filePath">Path to binary file</param>
        private void Rewrite(string filePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                formatter.Serialize(fs, this.Records);
            }
        }
    }
}
