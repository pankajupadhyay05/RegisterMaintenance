using System;
using System.Linq;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    class InsertTransaction
    {

        private int id;
        public int Id
        {
            get
            {
                XDocument doc = XDocument.Load(@"Transactions.xml");
                if (doc.Element("Transactions").HasElements)
                {
                    string xIdString = XElement.Load(@"Transactions.xml").Elements("Transaction").Last().Attribute("Id").Value;
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

        private int serial;
        public int Serial
        {
            get
            {
                XDocument doc = XDocument.Load(@"Transactions.xml");
                if (doc.Element("Transactions").HasElements)
                {
                    string xSerialString = XElement.Load(@"Transactions.xml").Elements("Transaction").Last().Element("Serial").Value;
                    int xSerialInt = Int32.Parse(xSerialString);
                    xSerialInt++;
                    this.serial = xSerialInt;
                    return this.serial;
                }
                else
                {
                    this.serial = 1;
                    return this.serial;
                }
            }
            set { this.serial = value; }
        }

        private string seller;
        public string Seller 
        {
            get { return this.seller; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Please Select a Seller");
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

        private decimal? ratePerQuintal;
        public decimal? RatePerQuintal
        {
            get 
            {
                return this.ratePerQuintal; 
            }
            set
            {
                this.ratePerQuintal = value;
            }
        }

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

        private DateTime? paymentDate;
        public DateTime? PaymentDate
        {
            get { return this.paymentDate; }
            set { this.paymentDate = value; }
        }

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

        private decimal? brokeragePaid;
        public decimal? BrokeragePaid
        {
            get { return this.brokeragePaid; }
            set { this.brokeragePaid = value; }
        }

        private decimal? amount;
        public decimal? Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

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

        private DateTime? date;
        public DateTime? Date 
        {
            get { return this.date; }
            set 
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Select a Transaction Date");
                }
                else
                {
                    this.date = value;
                }
            }
        }

        private string pressSerialFrom;
        public string PressSerialFrom 
        {
            get { return this.pressSerialFrom; }
            set { this.pressSerialFrom = value; }
        }

        private string pressSerialTo;
        public string PressSerialTo
        {
            get { return this.pressSerialTo; }
            set { this.pressSerialTo = value; }
        }

        private string pressMark;
        public string PressMark 
        {
            get { return this.pressMark; }
            set { this.pressMark = value; }
        }

        private decimal? grossWeight;
        public decimal? GrossWeight 
        {
            get { return this.grossWeight; }
            set { this.grossWeight = value; }
        }

        private decimal? lessTear;
        public decimal? LessTear 
        {
            get { return this.lessTear; }
            set { this.lessTear = value; }
        }

        private decimal? lessSample;
        public decimal? LessSample 
        {
            get { return this.lessSample; }
            set { this.lessSample = value; }
        }

        private decimal? lessDamage;
        public decimal? LessDamage 
        {
            get { return this.lessDamage; }
            set { this.lessDamage = value; }
        }

        private decimal? netWeight;
        public decimal? NetWeight 
        {
            get { return this.netWeight; }
            set { this.netWeight = value; }
        }

        private DateTime? despatchDate;
        public DateTime? DespatchDate 
        {
            get { return this.despatchDate; }
            set { this.despatchDate = value; }
        }

        private string gRNo;
        public string GRNo 
        {
            get { return this.gRNo; }
            set { this.gRNo = value; }
        }

        private int invoiceId;
        public int InvoiceId
        {
            get { return this.invoiceId; }
            set { this.invoiceId = value; }
        }

        private string lotNo;
        public string LotNo
        {
            get { return this.lotNo; }
            set { this.lotNo = value; }
        }

        private int debitNoteId;
        public int DebitNoteId
        {
            get { return this.debitNoteId; }
            set { this.debitNoteId = value; }
        }
        
        private DateTime? pressDate;
        public DateTime? PressDate
        {
            get { return this.pressDate; }
            set { this.pressDate = value; }
        }

        private DateTime? dueDate;
        public DateTime? DueDate
        {
            get { return this.dueDate; }
            set { this.dueDate = value; }
        }

        public string Add()
        {
            XDocument xmlDoc = XDocument.Load(@"Transactions.xml");
            DebitNoteId = this.Id;
            InvoiceId = this.Id;

            RatePerQuintal = this.ratePerMound * (decimal)2.6792;
            RatePerQuintal = Math.Round((decimal)RatePerQuintal, 2, MidpointRounding.AwayFromZero);
            NetWeight = this.grossWeight - ((this.lessTear) + (this.lessSample) + (this.lessDamage));
            Amount = this.ratePerQuintal * this.netWeight;
            if (Amount.HasValue)
            {
                Amount = Math.Round((decimal)Amount);
            }
            xmlDoc.Element("Transactions").Add(new XElement("Transaction", new XAttribute("Id", Id),
                new XElement("Serial", this.serial), new XElement("Date", this.date),
                new XElement("Seller", this.seller), new XElement("Station", this.station),
                new XElement("Bales", this.bales), new XElement("Quality", this.quality),
                new XElement("RatePerMound", this.ratePerMound), new XElement("RatePerQuintal", this.ratePerQuintal),
                new XElement("Condition", this.condition), new XElement("PaymentDate", this.paymentDate),
                new XElement("Broker", this.broker), new XElement("BrokeragePaid", this.brokeragePaid),
                new XElement("Amount", this.amount), new XElement("Buyer", this.buyer),
                new XElement("PressSerialFrom", this.pressSerialFrom), new XElement("PressSerialTo", this.pressSerialTo),
                new XElement("PressMark", this.pressMark),
                new XElement("GrossWeight", this.grossWeight), new XElement("LessTear", this.lessTear),
                new XElement("LessSample", this.lessSample), new XElement("LessDamage", this.lessDamage),
                new XElement("NetWeight", this.netWeight), new XElement("DespatchDate", this.despatchDate),
                new XElement("GRNo", this.gRNo), new XElement("Invoice", new XAttribute("Id", this.invoiceId)),
                new XElement("DebitNote", new XAttribute("Id", this.debitNoteId)), 
                new XElement("PressDate", this.pressDate), new XElement("LotNo", this.lotNo), new XElement("DueDate", this.dueDate)));

            xmlDoc.Save(@"Transactions.xml");

            return ("Record Added Successfully");
        }
    }
}
