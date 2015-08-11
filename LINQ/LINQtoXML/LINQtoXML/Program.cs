using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;
using System.Collections.Generic;
using System;

namespace LINQtoXML
{
    class Program
    {

        static void Main(string[] args)
        {

            QueryXML();
        }

        private static void QueryXML()
        {
            XDocument doc = new XDocument(
                new XElement("Processes",
                from p in Process.GetProcesses()
                orderby p.ProcessName ascending
                select new XElement("Process",
                new XAttribute("Name", p.ProcessName),
                new XAttribute("PID", p.Id))));

            IEnumerable<int> pids = from e in doc.Descendants("Process")
                                     where e.Attribute("Name").Value == "devenv"
                                     orderby (int) e.Attribute("PID") ascending
                                     select (int) e.Attribute("PID");

            foreach(int id in pids)
            {
                Console.WriteLine(id);
            }

            Console.Read();
        }
    }
}
