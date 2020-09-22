using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace RegisterMaintenance.DAL
{
    class SellerDetail
    {
        public string Serial { get; set; } 
        public DateTime Date { get; set; }
        public string Bales { get; set; }
        public string Quality { get; set; }
        public decimal RatePerMound { get; set; }
        public decimal RatePerQuintal { get; set; }
        public string Condition { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string Broker { get; set; }
        public decimal? Amount { get; set; }
        public string Buyer { get; set; }
        public string PressSerialFrom { get; set; }
        public string PressSerialTo { get; set; }
        public DateTime? PressDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string PressMark { get; set; }
        public string NetWeight { get; set; }
        public DateTime? DespatchDate { get; set; }
    }

    class DAL_SellerDetail
    {
        public static List<SellerDetail> LoadSellerDetail(string sellerName)
        {
            List<SellerDetail> ListSellerDetail = new List<SellerDetail>();
            // Execute the query using the LINQ to XML
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction") 
                          where r.Element("Seller").Value == sellerName select r;
            foreach (var record in records)
            {
                SellerDetail lSellerDetail = new SellerDetail
                {
                    Serial = record.Element("Serial").Value,
                    Date = (DateTime)record.Element("Date"),
                    Bales = record.Element("Bales").Value,
                    Quality = record.Element("Quality").Value,
                    RatePerMound = (decimal)record.Element("RatePerMound"),
                    RatePerQuintal = (decimal)record.Element("RatePerQuintal"),
                    Condition = record.Element("Condition").Value,
                    PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate"),
                    Broker = record.Element("Broker").Value,
                    Amount = record.Element("Amount") != null && !record.Element("Amount").Nodes().Any() ? null : (decimal?)record.Element("Amount"),
                    Buyer = record.Element("Buyer").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    PressDate = record.Element("PressDate") != null && !record.Element("PressDate").Nodes().Any() ? null : (DateTime?)record.Element("PressDate"),
                    DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate"),
                    NetWeight = record.Element("NetWeight").Value,
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                };
                ListSellerDetail.Add(lSellerDetail);
            }
            return ListSellerDetail;
        }
    }
}
