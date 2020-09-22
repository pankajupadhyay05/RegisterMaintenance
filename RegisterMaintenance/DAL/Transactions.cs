using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace RegisterMaintenance.DAL
{
    public class Transactions
    {
        public int Serial { get; set; }
        public DateTime Date { get; set; }
        private string seller;
        public string Seller
        {
            get { return this.seller; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify a Seller");
                }
                else
                {
                    this.seller = value;
                }
            }
        }

        private string station;
        public string Station
        {
            get { return this.station; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Select a Station");
                }
                else
                {
                    this.station = value;
                }
            }
        }

        private int? bales;
        public int? Bales
        {
            get { return this.bales; }
            set
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Enter No. of Bales");
                }
                else
                {
                    this.bales = value;
                }
            }
        }

        private string quality;
        public string Quality
        {
            get { return this.quality; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Select the Quality");
                }
                else
                {
                    this.quality = value;
                }
            }
        }

        private decimal? ratePerMound;
        public decimal? RatePerMound
        {
            get { return this.ratePerMound; }
            set
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Enter Rate Per Mound");
                }
                else
                {
                    this.ratePerMound = value;
                }
            }
        }
        
        public decimal? RatePerQuintal { get; set; }

        private string condition;
        public string Condition
        {
            get { return this.condition; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify the Condition");
                }
                else
                {
                    this.condition = value;
                }
            }
        }
        
        public DateTime? PaymentDate { get; set; }

        private string broker;
        public string Broker
        {
            get { return this.broker; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify the Broker Name");
                }
                else
                {
                    this.broker = value;
                }
            }
        }
        
        public decimal? BrokeragePaid { get; set; }
        public decimal? Amount { get; set; }

        private string buyer;
        public string Buyer
        {
            get { return this.buyer; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Specify the Buyer");
                }
                else
                {
                    this.buyer = value;
                }
            }
        }

        public string PressSerialFrom { get; set; }    
        public string PressSerialTo { get; set; }
        public string PressMark { get; set; }
        public DateTime? PressDate { get; set; }
        public decimal? GrossWeight { get; set; }
        public decimal? LessTear { get; set; }
        public decimal? LessSample { get; set; }
        public decimal? LessDamage { get; set; }
        public decimal? NetWeight { get; set; }
        public DateTime? DespatchDate { get; set; }
        public string GRNo { get; set; }
        public DateTime? DueDate { get; set; }
        public string LotNo { get; set; }

        public string Update()
        {
            NetWeight = GrossWeight - (LessTear + LessSample + LessDamage);
            RatePerQuintal = RatePerMound * (decimal)2.6792;
            RatePerQuintal = Math.Round((decimal)RatePerQuintal, 2, MidpointRounding.AwayFromZero);
            Amount = NetWeight * RatePerQuintal;
            if (Amount.HasValue)
            {
                Amount = Math.Round((decimal)Amount);
            }
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var record = from r in doc.Descendants("Transaction")
                         where (int)r.Element("Serial") == Serial
                         select r;
            foreach (XElement r in record)
            {
                r.Element("Seller").Value = Seller;
                r.Element("Bales").Value = Bales.ToString();
                r.Element("Date").Value = XmlConvert.ToString(Date, XmlDateTimeSerializationMode.RoundtripKind);
                r.Element("Station").Value = Station;
                r.Element("Quality").Value = Quality;
                r.Element("RatePerMound").Value = RatePerMound.ToString();
                r.Element("Condition").Value = Condition;
                r.Element("Broker").Value = Broker;
                r.Element("BrokeragePaid").Value = BrokeragePaid.ToString();
                r.Element("PaymentDate").Value = PaymentDate.HasValue ? XmlConvert.ToString(PaymentDate.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("Buyer").Value = Buyer;
                r.Element("PressSerialFrom").Value = PressSerialFrom;
                r.Element("PressSerialTo").Value = PressSerialTo;
                r.Element("PressMark").Value = PressMark;
                r.Element("PressDate").Value = PressDate.HasValue ? XmlConvert.ToString(PressDate.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("GrossWeight").Value = GrossWeight.ToString();
                r.Element("LessTear").Value = LessTear.ToString();
                r.Element("LessSample").Value = LessSample.ToString();
                r.Element("LessDamage").Value = LessDamage.ToString();
                r.Element("DespatchDate").Value = DespatchDate.HasValue ? XmlConvert.ToString(DespatchDate.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("NetWeight").Value = NetWeight.ToString();
                r.Element("RatePerQuintal").Value = RatePerQuintal.ToString();
                r.Element("Amount").Value = Amount.ToString();
                r.Element("GRNo").Value = GRNo;
                r.Element("LotNo").Value = LotNo;
                r.Element("DueDate").Value = DueDate.HasValue ? XmlConvert.ToString(DueDate.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
            }
            doc.Save(@"Transactions.xml");
            return "Record Updated Successfully";
        }

        public string Delete()
        {
            XDocument doc = XDocument.Load(@"Transactions.xml");
            doc.Element("Transactions").Elements("Transaction").Where(x => x.Element("Serial").Value.Trim() == Serial.ToString()).Remove();   
            doc.Save(@"Transactions.xml" );
            return "Transaction Deleted Successfully";
        }
    }

    class DAL_Transactions
    {
        public static List<Transactions> LoadTransactions()
        {
            List<Transactions> ListRegisterRecords = new List<Transactions>();
            // Execute the query using the LINQ to XML
            // trial path
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction") select r;
            foreach (var record in records)
            {
                Transactions lTransaction = new Transactions
                {
                    Serial = (int)record.Element("Serial"),
                    Date = (DateTime)record.Element("Date"),
                    Seller = record.Element("Seller").Value,
                    Station = record.Element("Station").Value,
                    Bales = (int)record.Element("Bales"),
                    Quality = record.Element("Quality").Value,
                    RatePerMound = (decimal)record.Element("RatePerMound"),
                    RatePerQuintal = (decimal)record.Element("RatePerQuintal"),
                    Condition = record.Element("Condition").Value,
                    PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate"),
                    Broker = record.Element("Broker").Value,
                    BrokeragePaid = record.Element("BrokeragePaid") != null && !record.Element("BrokeragePaid").Nodes().Any() ? null : (decimal?)record.Element("BrokeragePaid"),
                    Amount = record.Element("Amount") != null && !record.Element("Amount").Nodes().Any() ? null : (decimal?)record.Element("Amount"),
                    Buyer = record.Element("Buyer").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    PressDate = record.Element("PressDate") != null && !record.Element("PressDate").Nodes().Any() ? null : (DateTime?)record.Element("PressDate"),
                    GrossWeight = record.Element("GrossWeight") != null && !record.Element("GrossWeight").Nodes().Any() ? null : (decimal?)record.Element("GrossWeight"),
                    LessTear = record.Element("LessTear") != null && !record.Element("LessTear").Nodes().Any() ? null : (decimal?)record.Element("LessTear"),
                    LessSample = record.Element("LessSample") != null && !record.Element("LessSample").Nodes().Any() ? null : (decimal?)record.Element("LessSample"),
                    LessDamage = record.Element("LessDamage") != null && !record.Element("LessDamage").Nodes().Any() ? null : (decimal?)record.Element("LessDamage"),
                    NetWeight = record.Element("NetWeight") != null && !record.Element("NetWeight").Nodes().Any() ? null : (decimal?)record.Element("NetWeight"),
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                    GRNo = record.Element("GRNo").Value,
                    LotNo = record.Element("LotNo").Value,
                    DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate")
                };
                ListRegisterRecords.Add(lTransaction);
            }
            return ListRegisterRecords;
        }

        public static List<Transactions> LoadTransactionsPendingInvoice()
        {
            List<Transactions> ListRegisterRecords = new List<Transactions>();
            // Execute the query using the LINQ to XML
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction")
                          where !(r.Element("Invoice").HasElements) && r.Element("Amount").Value != ""
                          select r;
            foreach (var record in records)
            {
                Transactions lTransaction = new Transactions
                {
                    Serial = (int)record.Element("Serial"),
                    Date = (DateTime)record.Element("Date"),
                    Seller = record.Element("Seller").Value,
                    Station = record.Element("Station").Value,
                    Bales = int.Parse(record.Element("Bales").Value),
                    Quality = record.Element("Quality").Value,
                    RatePerMound = decimal.Parse(record.Element("RatePerMound").Value),
                    RatePerQuintal = decimal.Parse(record.Element("RatePerQuintal").Value),
                    Condition = record.Element("Condition").Value,
                    PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate"),
                    Broker = record.Element("Broker").Value,
                    BrokeragePaid = record.Element("BrokeragePaid") != null && !record.Element("BrokeragePaid").Nodes().Any() ? null : (decimal?)record.Element("BrokeragePaid"),
                    Amount = record.Element("Amount") != null && !record.Element("Amount").Nodes().Any() ? null : (decimal?)record.Element("Amount"),
                    Buyer = record.Element("Buyer").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    PressDate = record.Element("PressDate") != null && !record.Element("PressDate").Nodes().Any() ? null : (DateTime?)record.Element("PressDate"),
                    GrossWeight = record.Element("GrossWeight") != null && !record.Element("GrossWeight").Nodes().Any() ? null : (decimal?)record.Element("GrossWeight"),
                    LessTear = record.Element("LessTear") != null && !record.Element("LessTear").Nodes().Any() ? null : (decimal?)record.Element("LessTear"),
                    LessSample = record.Element("LessSample") != null && !record.Element("LessSample").Nodes().Any() ? null : (decimal?)record.Element("LessSample"),
                    LessDamage = record.Element("LessDamage") != null && !record.Element("LessDamage").Nodes().Any() ? null : (decimal?)record.Element("LessDamage"),
                    NetWeight = record.Element("NetWeight") != null && !record.Element("NetWeight").Nodes().Any() ? null : (decimal?)record.Element("NetWeight"),
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                    GRNo = record.Element("GRNo").Value,
                    LotNo = record.Element("LotNo").Value,
                    DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate")
                };
                ListRegisterRecords.Add(lTransaction);
            }
            return ListRegisterRecords;
        }

        public static List<Transactions> LoadTransactionsPendingDebitNote()
        {
            List<Transactions> ListRegisterRecords = new List<Transactions>();
            // Execute the query using the LINQ to XML
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction")
                          where !(r.Element("DebitNote").HasElements) && r.Element("Invoice").HasElements
                          select r;
            foreach (var record in records)
            {
                Transactions lTransaction = new Transactions
                {
                    Serial = (int)record.Element("Serial"),
                    Date = (DateTime)record.Element("Date"),
                    Seller = record.Element("Seller").Value,
                    Station = record.Element("Station").Value,
                    Bales = int.Parse(record.Element("Bales").Value),
                    Quality = record.Element("Quality").Value,
                    RatePerMound = decimal.Parse(record.Element("RatePerMound").Value),
                    RatePerQuintal = decimal.Parse(record.Element("RatePerQuintal").Value),
                    Condition = record.Element("Condition").Value,
                    PaymentDate = record.Element("PaymentDate") != null && !record.Element("PaymentDate").Nodes().Any() ? null : (DateTime?)record.Element("PaymentDate"),
                    Broker = record.Element("Broker").Value,
                    BrokeragePaid = record.Element("BrokeragePaid") != null && !record.Element("BrokeragePaid").Nodes().Any() ? null : (decimal?)record.Element("BrokeragePaid"),
                    Amount = record.Element("Amount") != null && !record.Element("Amount").Nodes().Any() ? null : (decimal?)record.Element("Amount"),
                    Buyer = record.Element("Buyer").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    PressDate = record.Element("PressDate") != null && !record.Element("PressDate").Nodes().Any() ? null : (DateTime?)record.Element("PressDate"),
                    GrossWeight = record.Element("GrossWeight") != null && !record.Element("GrossWeight").Nodes().Any() ? null : (decimal?)record.Element("GrossWeight"),
                    LessTear = record.Element("LessTear") != null && !record.Element("LessTear").Nodes().Any() ? null : (decimal?)record.Element("LessTear"),
                    LessSample = record.Element("LessSample") != null && !record.Element("LessSample").Nodes().Any() ? null : (decimal?)record.Element("LessSample"),
                    LessDamage = record.Element("LessDamage") != null && !record.Element("LessDamage").Nodes().Any() ? null : (decimal?)record.Element("LessDamage"),
                    NetWeight = record.Element("NetWeight") != null && !record.Element("NetWeight").Nodes().Any() ? null : (decimal?)record.Element("NetWeight"),
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                    GRNo = record.Element("GRNo").Value,
                    LotNo = record.Element("LotNo").Value,
                    DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate")
                };
                ListRegisterRecords.Add(lTransaction);
            }
            return ListRegisterRecords;
        }
    }
}
