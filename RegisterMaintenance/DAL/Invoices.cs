using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    public class Invoices
    {
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Station { get; set; }
        public string Bales { get; set; }
        public string Quality { get; set; }
        public decimal RatePerMound { get; set; }
        public decimal RatePerQuintal { get; set; }
        public decimal Amount { get; set; }
        public string Buyer { get; set; }
        public string TinNo { get; set; }
        public string PressSerialFrom { get; set; }
        public string PressSerialTo { get; set; }
        public string PressMark { get; set; }
        public DateTime? PressDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DespatchDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string GrossWeight { get; set; }
        public string LessTear { get; set; }
        public string LessSample { get; set; }
        public string LessDamage { get; set; }
        public string NetWeight { get; set; }
        public string GRNo { get; set; }
        public decimal CommissionOnAmount { get; set; }
        public decimal CommissionAmount { get; set; }
        public decimal CommissionRate { get; set; }
        public decimal VatOnAmount { get; set; }
        public decimal VatRate { get; set; }
        public decimal VatAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string TruckNo { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string LotNo { get; set; }
        public string PhoneNo { get; set; }

        public string Update()
        {
            CommissionAmount = (CommissionRate * Amount) / 100;
            CommissionAmount = Math.Round((decimal)CommissionAmount);
            VatOnAmount = Amount + CommissionAmount;
            VatAmount = (CommissionAmount + Amount) * VatRate / 100;
            VatAmount = Math.Round((decimal)VatAmount);
            InvoiceAmount = Amount + CommissionAmount + VatAmount;
            
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var record = from r in doc.Descendants("Transaction")
                         where (int)r.Element("Invoice").Attribute("Id") == InvoiceId
                         select r;
            foreach (XElement r in record)
            {
                r.Element("Invoice").Element("InvoiceNo").Value = InvoiceNo;
                r.Element("Invoice").Element("InvoiceDate").Value = XmlConvert.ToString(InvoiceDate, XmlDateTimeSerializationMode.RoundtripKind);
                r.Element("Invoice").Element("CommissionRate").Value = CommissionRate.ToString();
                r.Element("Invoice").Element("CommissionAmount").Value = CommissionAmount.ToString();
                r.Element("Invoice").Element("VatRate").Value = VatRate.ToString();
                r.Element("Invoice").Element("VatAmount").Value = VatAmount.ToString();
                r.Element("Invoice").Element("InvoiceAmount").Value = InvoiceAmount.ToString();
                r.Element("Invoice").Element("Source").Value = Source;
                r.Element("Invoice").Element("Destination").Value = Destination;
                r.Element("Invoice").Element("TruckNo").Value = TruckNo;
            }
            doc.Save(@"Transactions.xml");
            return "Record Updated";
        }
    }

    class DAL_Invoices
    {
        public static List<Invoices> LoadInvoices()
        {
            List<Invoices> ListInvoiceRecords = new List<Invoices>();
            // Execute the query using the LINQ to XML
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction") 
                          where r.Element("Invoice").HasElements
                          select r;
            foreach (var record in records)
            {
                Invoices lInvoice = new Invoices
                {
                    InvoiceId = (int)record.Element("Invoice").Attribute("Id"),
                    TransactionDate = (DateTime)record.Element("Date"),
                    InvoiceNo = record.Element("Invoice").Element("InvoiceNo").Value,
                    InvoiceDate = (DateTime)record.Element("Invoice").Element("InvoiceDate"),
                    Station = record.Element("Station").Value,
                    Bales = record.Element("Bales").Value,
                    Quality = record.Element("Quality").Value,
                    RatePerMound = (decimal)record.Element("RatePerMound"),
                    RatePerQuintal = (decimal)record.Element("RatePerQuintal"),
                    Amount = (decimal)record.Element("Amount"),
                    Buyer = record.Element("Buyer").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    PressDate = record.Element("PressDate") != null && !record.Element("PressDate").Nodes().Any() ? null : (DateTime?)record.Element("PressDate"),
                    DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate"),
                    GrossWeight = record.Element("GrossWeight").Value,
                    LessTear = record.Element("LessTear").Value,
                    LessSample = record.Element("LessSample").Value,
                    LessDamage = record.Element("LessDamage").Value,
                    NetWeight = record.Element("NetWeight").Value,
                    GRNo = record.Element("GRNo").Value,
                    CommissionRate = (decimal)record.Element("Invoice").Element("CommissionRate"),
                    CommissionAmount = (decimal)record.Element("Invoice").Element("CommissionAmount"),
                    VatRate = (decimal)record.Element("Invoice").Element("VatRate"),
                    VatAmount = (decimal)record.Element("Invoice").Element("VatAmount"),
                    InvoiceAmount = (decimal)record.Element("Invoice").Element("InvoiceAmount"),
                    Source = record.Element("Invoice").Element("Source").Value,
                    Destination = record.Element("Invoice").Element("Destination").Value,
                    TruckNo = record.Element("Invoice").Element("TruckNo").Value,
                    TinNo = record.Element("Invoice").Element("TinNo").Value,
                    CommissionOnAmount = (decimal)record.Element("Amount"),
                    VatOnAmount = ((decimal)record.Element("Amount") + (decimal)record.Element("Invoice").Element("CommissionAmount")),
                    LotNo = record.Element("LotNo").Value,
                    PhoneNo = record.Element("Invoice").Element("PhoneNo").Value,
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                    PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate")
                };
                ListInvoiceRecords.Add(lInvoice);
            }
            return ListInvoiceRecords;
        }
    }
}
