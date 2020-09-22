using System;
using System.Linq;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    class InsertInvoice
    {
        public int Serial { get; set; }

        private string invoiceNo;
        public string InvoiceNo 
        {
            get { return this.invoiceNo; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Enter Invoice No.");
                }
                else
                {
                    this.invoiceNo = value;
                }
            }
        }

        private DateTime? invoiceDate;
        public DateTime? InvoiceDate 
        { 
            get { return this.invoiceDate; }
            set
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Select a Date");
                }
                else
                {
                    this.invoiceDate = value;
                }
            } 
        }

        public string Station { get; set; }
        public string Bales { get; set; }
        public string Quality { get; set; }
        public decimal RatePerMound { get; set; }
        public decimal RatePerQuintal { get; set; }
        public string Condition { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string Buyer { get; set; }
        public string TinNo { get; set; }
        public string PressSerialFrom { get; set; }
        public string PressSerialTo { get; set; }
        public string PressMark { get; set; }
        public DateTime? PressDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string GrossWeight { get; set; }
        public string LessTear { get; set; }
        public string LessSample { get; set; }
        public string LessDamage { get; set; }
        public string NetWeight { get; set; }
        public DateTime? DespatchDate { get; set; }
        public string GRNo { get; set; }
        public decimal? CommissionAmount { get; set; }

        private decimal? commissionRate;
        public decimal? CommissionRate 
        {
            get { return this.commissionRate; }
            set
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Enter Commission Rate");
                }
                else
                {
                    this.commissionRate = value;
                }
            } 
        }

        private decimal? vatRate;
        public decimal? VatRate 
        {
            get { return this.vatRate; }
            set
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Enter Vat Rate");
                }
                else
                {
                    this.vatRate = value;
                }
            } 
        }
        public decimal? VatAmount { get; set; }
        public string TransactionDate { get; set; }
        
        private string source;
        public string Source 
        {
            get { return this.source; }
            set
            {
                this.source = value;          
            }
        }

        private string destination;
        public string Destination 
        {
            get { return this.destination; }
            set
            {
                this.destination = value;
            }
        }

        private string truckNo;
        public string TruckNo
        {
            get { return this.truckNo; }
            set
            {
                this.truckNo = value;
            }
        }

        public decimal? InvoiceAmount { get; set; }
        public string PhoneNo { get; set; }

        public void Load(int serial)
        {
            XDocument xdoc = XDocument.Load(@"Transactions.xml");
            var record = (from r in xdoc.Descendants("Transaction")
                         where (int)r.Element("Serial") == serial
                         select r).FirstOrDefault();
            this.Serial = (int)record.Element("Serial");
            this.TransactionDate = record.Element("Date").Value;
            this.Station = record.Element("Station").Value;
            this.Bales = record.Element("Bales").Value;
            this.Quality = record.Element("Quality").Value;
            this.RatePerMound = (decimal)record.Element("RatePerMound");
            this.RatePerQuintal = (decimal)record.Element("RatePerQuintal");
            this.Condition = record.Element("Condition").Value;
            this.PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate");
            this.Amount = (decimal)record.Element("Amount");
            this.Buyer = record.Element("Buyer").Value;
            this.PressSerialFrom = record.Element("PressSerialFrom").Value;
            this.PressSerialTo = record.Element("PressSerialTo").Value;
            this.PressMark = record.Element("PressMark").Value;
            this.PressDate = record.Element("PressDate") != null && !record.Element("PressDate").Nodes().Any() ? null : (DateTime?)record.Element("PressDate");
            this.DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate");
            this.GrossWeight = record.Element("GrossWeight").Value;
            this.LessTear = record.Element("LessTear").Value;
            this.LessSample = record.Element("LessSample").Value;
            this.LessDamage = record.Element("LessDamage").Value;
            this.NetWeight = record.Element("NetWeight").Value;
            this.DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate");
            this.GRNo = record.Element("GRNo").Value;
        }

        public string Add()
        {
            XDocument doc1 = XDocument.Load(@"Ledgers.xml");
            XElement elem = (from r in doc1.Descendants("Ledger")
                    where r.Element("Name").Value == this.Buyer
                    select r).First();
            this.TinNo = (string)elem.Element("TinNo");
            this.PhoneNo = (string)elem.Element("PhoneNo");
            this.CommissionAmount = (this.CommissionRate * this.Amount) / 100;
            this.CommissionAmount = Math.Round((decimal)this.CommissionAmount);
            this.VatAmount = (this.CommissionAmount + this.Amount) * this.VatRate / 100;
            this.VatAmount = Math.Round((decimal)this.VatAmount);
            this.InvoiceAmount = this.Amount + this.CommissionAmount + this.VatAmount;
            XDocument doc2 = XDocument.Load(@"Transactions.xml");
            var record = from r in doc2.Descendants("Transaction")
                         where (int)r.Element("Serial") == Serial
                         select r;
            foreach (XElement r in record)
            {
                r.Element("Invoice").Add(new XElement("InvoiceNo", this.InvoiceNo), new XElement("InvoiceDate", this.InvoiceDate),
                    new XElement("TinNo", this.TinNo), new XElement("PhoneNo", this.PhoneNo), new XElement("TruckNo", this.TruckNo), new XElement("Source", this.Source),
                    new XElement("Destination", this.Destination), new XElement("InvoiceAmount", this.InvoiceAmount),
                    new XElement("CommissionRate", this.CommissionRate), new XElement("CommissionAmount", this.CommissionAmount),
                    new XElement("VatRate", this.VatRate), new XElement("VatAmount", this.VatAmount));
            }
            doc2.Save(@"Transactions.xml");
            return "Invoice Created Successfully";
        }
    }
}
