using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace RegisterMaintenance.DAL
{
    class Sellers
    {
        public string Seller { get; set; }
    }

    class DAL_Sellers
    {
        public static List<Sellers> LoadSellers()
        {
            List<Sellers> ListSellerRecords = new List<Sellers>();
            // Execute the query using the LINQ to XML
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var records = (from r in XElement.Load(@"Transactions.xml").Elements("Transaction") select r.Element("Seller").Value).Distinct();
            foreach (var record in records)
            {
                Sellers lSeller = new Sellers
                {
                    Seller = record 
                };
                ListSellerRecords.Add(lSeller);
            }
            return ListSellerRecords;
        }
        
        public static List<string> LoadSellersString()
        {
            List<string> ListSellerStringRecords = new List<string>();
            // Execute the query using the LINQ to XML
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var records = (from r in XElement.Load(@"Transactions.xml").Elements("Transaction")
                           orderby(string)r.Elements("Seller").First()
                           select r.Element("Seller").Value).Distinct();
            foreach (var record in records)
            {
                string lSellerString = record;
                ListSellerStringRecords.Add(lSellerString);
            }
            return ListSellerStringRecords;
        }
    }
}
