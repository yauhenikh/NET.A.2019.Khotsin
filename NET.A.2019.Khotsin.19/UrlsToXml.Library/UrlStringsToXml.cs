using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace UrlsToXml.Library
{
    /// <summary>
    /// Represents class to create XML file from URL strings
    /// </summary>
    public class UrlStringsToXml
    {
        private readonly string[] _urls;
        private readonly ILogger _logger;
        private XDocument _xDocument;

        /// <summary>
        /// Parameterized constructor with filePath and logger arguments
        /// </summary>
        /// <param name="filePath">Path to file with URL addresses</param>
        /// <param name="logger">Given logger</param>
        public UrlStringsToXml(string filePath, ILogger logger)
        {
            if (logger == null)
            {
                _logger = new SimpleLogger();
            }
            else
            {
                _logger = logger;
            }

            try
            {
                _urls = File.ReadAllLines(filePath, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                logger.Error($"Impossible to read file: {filePath}");
                throw;
            }

            _xDocument = new XDocument();
        }

        /// <summary>
        /// Parameterized constructor with urls and logger arguments
        /// </summary>
        /// <param name="urls">Arrays of strings with URL addresses</param>
        /// <param name="logger">Given logger</param>
        public UrlStringsToXml(string[] urls, ILogger logger)
        {
            if (logger == null)
            {
                _logger = new SimpleLogger();
            }
            else
            {
                _logger = logger;
            }

            _urls = urls;
            _xDocument = new XDocument();
        }

        /// <summary>
        /// Gets XML document with URL addresses
        /// </summary>
        /// <returns>XML document with URL addresses</returns>
        public XDocument UrlsToXml()
        {
            XElement xUrls = new XElement("urlAddresses");

            foreach (string url in _urls)
            {
                try
                {
                    XElement xHost = null;
                    XElement xSegments = null;
                    XElement xParameters = null;

                    UrlPartsGetter urlPartsGetter = new UrlPartsGetter(url);

                    XElement xUrl = new XElement("urlAddress");

                    xHost = HostToXml(urlPartsGetter);
                    xSegments = SegmentsToXml(urlPartsGetter);
                    xParameters = ParametersToXml(urlPartsGetter);

                    if (xHost != null)
                    {
                        xUrl.Add(xHost);
                    }

                    if (xSegments != null)
                    {
                        xUrl.Add(xSegments);
                    }

                    if (xParameters != null)
                    {
                        xUrl.Add(xParameters);
                    }

                    xUrls.Add(xUrl);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    _logger.Error($"Impossible to add url: {url}");
                }
            }

            _xDocument.Add(xUrls);

            return _xDocument;
        }

        /// <summary>
        /// Saves URL addresses to XML file
        /// </summary>
        /// <param name="filePath">Path to XML file to save URL addresses</param>
        public void SaveUrlsToXmlFile(string filePath)
        {
            try
            {
                _xDocument.Save(filePath);
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
            }
        }

        /// <summary>
        /// Converts host part of URL address to XML element
        /// </summary>
        /// <param name="urlPartsGetter">Getter of URL parts</param>
        /// <returns>XML element, containing host part of URL address</returns>
        private XElement HostToXml(UrlPartsGetter urlPartsGetter)
        {
            XElement xHost = new XElement("host");

            XAttribute xHostNameAttribute = new XAttribute("name", urlPartsGetter.GetHost());
            xHost.Add(xHostNameAttribute);

            return xHost;
        }

        /// <summary>
        /// Converts segments part of URL address to XML element
        /// </summary>
        /// <param name="urlPartsGetter">Getter of URL parts</param>
        /// <returns>XML element, containing segments part of URL address</returns>
        private XElement SegmentsToXml(UrlPartsGetter urlPartsGetter)
        {
            XElement xSegments = null;

            var segments = urlPartsGetter.GetSegments();

            if (segments.Any())
            {
                xSegments = new XElement("uri");

                foreach (var segment in urlPartsGetter.GetSegments())
                {
                    XElement xSegment = new XElement("segment", segment);
                    xSegments.Add(xSegment);
                }
            }

            return xSegments;
        }

        /// <summary>
        /// Converts parameters part of URL address to XML element
        /// </summary>
        /// <param name="urlPartsGetter">Getter of URL parts</param>
        /// <returns>XML element, containing parameters part of URL address</returns>
        private XElement ParametersToXml(UrlPartsGetter urlPartsGetter)
        {
            XElement xParameters = null;

            var parameters = urlPartsGetter.GetParameters();

            if (parameters.Any())
            {
                xParameters = new XElement("parameters");

                foreach (var kvp in parameters)
                {
                    XElement xParameter = new XElement("parameter");
                    XAttribute xParameterValueAttribute = new XAttribute("value", kvp.Value);
                    XAttribute xParameterKeyAttribute = new XAttribute("key", kvp.Key);

                    xParameter.Add(xParameterValueAttribute, xParameterKeyAttribute);

                    xParameters.Add(xParameter);
                }
            }

            return xParameters;
        }
    }
}
