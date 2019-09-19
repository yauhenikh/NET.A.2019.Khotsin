using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace UrlsToXml.Library
{
    /// <summary>
    /// Represents class to get host, segments, parameters parts from URL address
    /// </summary>
    public class UrlPartsGetter
    {
        private readonly Uri _url;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="url">String with URL address</param>
        public UrlPartsGetter(string url)
        {
            if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                throw new ArgumentException("Invalid URL value");
            }

            _url = new Uri(url);
        }

        /// <summary>
        /// Gets host part from URL address
        /// </summary>
        /// <returns>String with host part</returns>
        public string GetHost()
        {
            return _url.Host;
        }

        /// <summary>
        /// Gets collection of segments from URL address
        /// </summary>
        /// <returns>Collection of strings with segments</returns>
        public IEnumerable<string> GetSegments()
        {
            foreach (var segment in _url.Segments)
            {
                if (segment == "/")
                {
                    continue;
                }

                string clearSegment = segment.Replace("/", string.Empty);

                yield return clearSegment;
            }
        }

        /// <summary>
        /// Gets collection of parameters from URL address
        /// </summary>
        /// <returns>Dictionary with keys and values of URL parameters</returns>
        public Dictionary<string, string> GetParameters()
        {
            string query = _url.Query;

            NameValueCollection parameters = HttpUtility.ParseQueryString(query);

            if (parameters.AllKeys.Any(key => key == null))
            {
                throw new ArgumentException("parameter key cannot be null");
            }

            return parameters.AllKeys.ToDictionary(key => key, key => parameters[key]);
        }
    }
}
