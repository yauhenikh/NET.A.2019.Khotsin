using System;

namespace FileCabinet.Library
{
    /// <summary>
    /// Represents records in file cabinet
    /// </summary>
    [Serializable]
    public class Record
    {
        private string _id;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Record()
        {
        }

        /// <summary>
        /// Id of the record
        /// </summary>
        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                if (value == null ||
                    value[0] != '#' ||
                    !char.IsNumber(value[1]) ||
                    int.TryParse(value.Substring(1), out int res) == false)
                {
                    throw new ArgumentException("Invalid Id value");
                }

                _id = value;
            }
        }

        /// <summary>
        /// First name in the record
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name in the record
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Date of birth in the record
        /// </summary>
        public DateTime DateOfBirth { get; set; }
    }
}
