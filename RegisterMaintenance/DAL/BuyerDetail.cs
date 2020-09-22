using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    class BuyerDetail
    {
        public string Serial { get; set; }
        public DateTime Date { get; set; }
        public string LotNo { get; set; }
        public string InvoiceNo { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public string Bales { get; set; }
        public string Quality { get; set; }
        public decimal RatePerMound { get; set; }
        public decimal RatePerQuintal { get; set; }
        public string Condition { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        public string Seller { get; set; }
        public string PressSerialFrom { get; set; }
        public string PressSerialTo { get; set; }
        public string PressMark { get; set; }
        public string NetWeight { get; set; }
        public DateTime? DespatchDate { get; set; }
        public string DebitNoteNo { get; set; }
    }

    class DAL_BuyerDetail
    {
        public static List<BuyerDetail> LoadBuyerDetail(string buyerName)
        {
            List<BuyerDetail> ListBuyerDetail = new List<BuyerDetail>();
            // Execute the query using the LINQ to XML
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction")
                          where r.Element("Buyer").Value == buyerName
                          select r;
            foreach (var record in records)
            {
 
                BuyerDetail lBuyerDetail = new BuyerDetail
                { 
                    Serial = record.Element("Serial").Value,
                    Date = (DateTime)record.Element("Date"),
                    LotNo = record.Element("LotNo").Value,
                    Bales = record.Element("Bales").Value,
                    Quality = record.Element("Quality").Value,
                    RatePerMound = (decimal)record.Element("RatePerMound"),
                    RatePerQuintal = (decimal)record.Element("RatePerQuintal"),
                    Condition = record.Element("Condition").Value,
                    PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate"),
                    Amount = record.Element("Amount") != null && !record.Element("Amount").Nodes().Any() ? null : (decimal?)record.Element("Amount"),
                    Seller = record.Element("Seller").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    NetWeight = record.Element("NetWeight").Value,
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                    InvoiceNo = !(record.Element("Invoice").HasElements) ? "Not Created" : record.Element("Invoice").Element("InvoiceNo").Value,
                    DebitNoteNo = !(record.Element("DebitNote").HasElements) ? "Not Created" : record.Element("DebitNote").Element("DebitNoteNo").Value,
                    InvoiceAmount = !(record.Element("Invoice").HasElements) ? 0 : (decimal)record.Element("Invoice").Element("InvoiceAmount")
                };
                ListBuyerDetail.Add(lBuyerDetail);
            }
            return ListBuyerDetail;
        }
    }
}
