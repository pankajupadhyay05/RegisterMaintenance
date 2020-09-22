using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    public class Ledgers
    {
        public string Id { get; set; }
        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify a Seller");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string PanNo { get; set; }
        public string SaleTaxNo { get; set; }
        public string TinNo { get; set; }

        public string Update()
        {
            XDocument doc = XDocument.Load(@"Ledgers.xml");
            var record = from r in doc.Descendants("Ledger")
                         where r.Attribute("Id").Value == Id
                         select r;
            foreach (XElement r in record)
            {
                r.Element("Name").Value = Name;
                r.Element("PhoneNo").Value = PhoneNo;
                r.Element("Email").Value = Email;
                r.Element("PanNo").Value = PanNo;
                r.Element("SaleTaxNo").Value = SaleTaxNo;
                r.Element("TinNo").Value = TinNo;
            }
            doc.Save(@"Ledgers.xml");
            return "Record Updated Successfully";
        }
    }
    class DAL_Ledgers
    {
        public static Ledgers LoadLedger(string ledgerName)
        {
            XDocument doc = XDocument.Load(@"Ledgers.xml");
            var records = from r in doc.Element("Ledgers").Elements("Ledger")
                          where r.Element("Name").Value == ledgerName
                          select r;
            Ledgers ld = new Ledgers();
            foreach (var record in records)
            {
                Ledgers lLedger = new Ledgers
                {
                    Id = record.Attribute("Id").Value,
                    Name = record.Element("Name").Value,
                    PhoneNo = record.Element("PhoneNo").Value,
                    Email = record.Element("Email").Value,
                    PanNo = record.Element("PanNo").Value,
                    SaleTaxNo = record.Element("SaleTaxNo").Value,
                    TinNo = record.Element("TinNo").Value
                };
                ld = lLedger;
            }
            return ld;
        }
            

        public static List<Ledgers> LoadLedgers()
        {
            List<Ledgers> ListLedgerRecords = new List<Ledgers>();
            // Execute the query using the LINQ to XML
            XDocument doc = XDocument.Load(@"Ledgers.xml");
            var records = from r in doc.Element("Ledgers").Elements("Ledger") select r;
            foreach (var record in records)
            {
                Ledgers lLedger = new Ledgers
                {
                    Id = record.Attribute("Id").Value,
                    Name = record.Element("Name").Value,
                    PhoneNo = record.Element("PhoneNo").Value,
                    Email = record.Element("Email").Value,
                    PanNo = record.Element("PanNo").Value,
                    SaleTaxNo = record.Element("SaleTaxNo").Value,
                    TinNo = record.Element("TinNo").Value
                };
                ListLedgerRecords.Add(lLedger);
            }
            return ListLedgerRecords;
        }

        public static List<string> LoadLedgersString()
        {
            List<string> ListLedgerStringRecords = new List<string>();
            // Execute the query using the LINQ to XML
            XDocument doc = XDocument.Load(@"Ledgers.xml");
            var records = from r in doc.Element("Ledgers").Elements("Ledger")
                          orderby(string)r.Elements("Name").First()
                          select r;
            foreach (var record in records)
            {
                string lLedgerString = record.Element("Name").Value;
                ListLedgerStringRecords.Add(lLedgerString);
            }
            return ListLedgerStringRecords;
        }
    }
}
