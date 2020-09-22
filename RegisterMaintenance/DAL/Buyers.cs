using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace RegisterMaintenance.DAL
{
    class Buyers
    {
        public string Buyer { get; set; }
    }

    class DAL_Buyers
    {
        public static List<Buyers> LoadBuyers()
        {
            List<Buyers> ListBuyerRecords = new List<Buyers>();
            // Execute the query using the LINQ to XML
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var records = (from r in XElement.Load(@"Transactions.xml").Elements("Transaction") select r.Element("Buyer").Value).Distinct();
            foreach (var record in records)
            {
                Buyers lBuyer = new Buyers
                {
                    Buyer = record 
                };
                ListBuyerRecords.Add(lBuyer);
            }
            return ListBuyerRecords;
        }

        public static List<string> LoadBuyersString()
        {
            List<string> ListBuyerStringRecords = new List<string>();
            // Execute the query using the LINQ to XML
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var records = (from r in XElement.Load(@"Transactions.xml").Elements("Transaction")
                           orderby (string)r.Elements("Buyer").First()
                           select r.Element("Buyer").Value).Distinct();
            foreach (var record in records)
            {
                string lBuyerString = record;
                ListBuyerStringRecords.Add(lBuyerString);
            }
            return ListBuyerStringRecords;
        }
    }
}
