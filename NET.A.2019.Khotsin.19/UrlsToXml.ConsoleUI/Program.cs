using System;
using System.IO;
using UrlsToXml.Library;

namespace UrlsToXml.ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string url1 = "https://github.com/AnzhelikaKravchuk?tab=repositories";
            string url2 = "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU";
            string url3 = "https://habrahabr.ru/company/it-grad/blog/341486/";
            string url4 = "fff/ddd/e";
            string url5 = "https://google.com";
            string url6 = "https://github.com/AnzhelikaKravchuk?tab=repositories&hhh=u&";
            string url7 = "https://github.com/AnzhelikaKravchuk?tab=repositories&hhh=u&ggg&jjj=g";

            string[] urls = new string[] { url1, url2, url3, url4, url5, url6, url7 };

            File.WriteAllLines("urls.txt", urls);

            Console.WriteLine("URLs from file: ");

            foreach (string url in File.ReadAllLines("urls.txt"))
            {
                Console.WriteLine(url);
            }

            Console.WriteLine();

            Console.WriteLine("Converting URL strings to XML...");

            UrlStringsToXml urlStringsToXml = new UrlStringsToXml("urls.txt", new SimpleLogger("logs.log"));

            var doc = urlStringsToXml.UrlsToXml();

            Console.WriteLine();
            Console.WriteLine("XML content:");
            Console.WriteLine(doc);

            urlStringsToXml.SaveUrlsToXmlFile("urls.xml");

            Console.ReadLine();
        }
    }
}
