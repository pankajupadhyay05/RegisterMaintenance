using System;
using System.Linq;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    class InsertLedger
    {
        private int id;
        public int Id
        {
            get
            {
                XDocument doc = XDocument.Load(@"Ledgers.xml");
                if (doc.Element("Ledgers").HasElements)
                {
                    string xIdString = doc.Element("Ledgers").Elements("Ledger").Last().Attribute("Id").Value;
                    int xIdInt = Int32.Parse(xIdString);
                    xIdInt++;
                    this.id = xIdInt;
                    return this.id;
                }
                else
                {
                    this.id = 1;
                    return this.id;
                }
            }
            set { this.id = value; }
        }

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

        public string Add()
        {
            XDocument xmlDoc = XDocument.Load(@"Ledgers.xml");
            
            xmlDoc.Element("Ledgers").Add(new XElement("Ledger", new XAttribute("Id", Id),
                new XElement("Name", this.name), new XElement("PhoneNo", PhoneNo),
                new XElement("Email", Email), new XElement("PanNo", PanNo),
                new XElement("SaleTaxNo", SaleTaxNo), new XElement("TinNo", TinNo)));

            xmlDoc.Save(@"Ledgers.xml");

            return ("Record Added Successfully");
        }
    }
}
