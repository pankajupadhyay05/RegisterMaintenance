using System;
using System.Xml.Linq;
using System.Linq;

namespace RegisterMaintenance.DAL
{
    public class InsertDebitNote
    {
        public int Serial { get; set; }
        public string InvoiceNo { get; set; }

        private string debitNoteNo;
        public string DebitNoteNo 
        {
            get { return this.debitNoteNo; }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ApplicationException
                        ("Enter DebitNote No.");
                }
                else
                {
                    this.debitNoteNo = value;
                }
            } 
        }

        private DateTime? debitNoteDate;
        public DateTime? DebitNoteDate 
        {
            get { return this.debitNoteDate; }
            set
            {
                if (value == null)
                {
                    throw new ApplicationException
                        ("Select a Date");
                }
                else
                {
                    this.debitNoteDate = value;
                }
            } 
        }
        public string Station { get; set; }
        public decimal? Bales { get; set; }
        public string Quality { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string Buyer { get; set; }
        public string PressSerialFrom { get; set; }
        public string PressSerialTo { get; set; }
        public string PressMark { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime DespatchDate { get; set; }
        public string LotNo { get; set; }
        public decimal? CommissionRate { get; set; }
        public decimal? CommissionAmount { get; set; }
        public decimal? CharityRate { get; set; }
        public decimal? CharityAmount { get; set; }
        public decimal? BrokerageRate { get; set; }
        public decimal? BrokerageAmount { get; set; }
        public string Postage { get; set; }
        public decimal? PostageCost { get; set; }
        public decimal? CottonDeliveryExpRate { get; set; }
        public decimal? CottonDeliveryExpAmount { get; set; }
        public string JafferyActual { get; set; }
        public decimal? JafferyActualCost { get; set; }
        public decimal? MarkingRate { get; set; }
        public decimal? MarkingAmount { get; set; }
        public string SampleCutting { get; set; }
        public decimal? SampleCuttingCost { get; set; }
        public decimal? CartagePlatformRate { get; set; }
        public decimal? CartagePlatformAmount { get; set; }
        public decimal? StackingRate { get; set; }
        public decimal? StackingAmount { get; set; }
        public string KatlaExp { get; set; }
        public decimal? KatlaExpRate { get; set; }
        public decimal? KatlaExpAmount { get; set; }
        public decimal? CartageFactoryRate { get; set; }
        public decimal? CartageFactoryAmount { get; set; }
        public decimal? StationExpRate { get; set; }
        public decimal? StationExpAmount { get; set; }
        public decimal? TruckLoadingRate { get; set; }
        public decimal? TruckLoadingAmount { get; set; }
        public decimal? BankChargeCost { get; set; }
        public decimal? BankChargeAmount { get; set; }
        public DateTime? GodownRentFrom { get; set; }
        public DateTime? GodownRentTo { get; set; }
        public decimal? GodownRentCost { get; set; }
        public string StockInsurance { get; set; }
        public decimal? StockInsuranceCost { get; set; }
        public string FreightFrom { get; set; }
        public string FreightTo { get; set; }
        public decimal? FreightCost { get; set; }
        public decimal? CarringChargesOn { get; set; }
        public DateTime? CarringChargesFrom { get; set; }
        public DateTime? CarringChargesTo { get; set; }
        public decimal? CarringChargesFor { get; set; }
        public decimal? CarringChargesRate { get; set; }
        public decimal? CarringChargesAmount { get; set; }
        public decimal DebitNoteTotal { get; set; }
        public decimal? AmountAndVat { get; set; }
        
        public bool Load(int serial)
        {
            XDocument xdoc = XDocument.Load(@"Transactions.xml");
            var record = (from r in xdoc.Descendants("Transaction")
                          where (int)r.Element("Serial") == serial
                          select r).FirstOrDefault();
            try
            {
                this.Serial = (int)record.Element("Serial");
                this.Station = record.Element("Station").Value;
                this.Bales = (decimal)record.Element("Bales");
                this.Quality = record.Element("Quality").Value;
                this.InvoiceAmount = (decimal)record.Element("Invoice").Element("InvoiceAmount");
                this.Buyer = record.Element("Buyer").Value;
                this.PressSerialFrom = record.Element("PressSerialFrom").Value;
                this.PressSerialTo = record.Element("PressSerialTo").Value;
                this.PressMark = record.Element("PressMark").Value;
                this.DueDate = (DateTime)record.Element("DueDate");
                this.DespatchDate = (DateTime)record.Element("DespatchDate");
                this.LotNo = record.Element("LotNo").Value;
            }
            catch (FormatException)
            {
                return false;
            }
            return true;
        }

        public string Add()
        {
            
            //Rounding off for direct costings
            
            if (this.PostageCost.HasValue)
            {
                this.PostageCost = Math.Round((decimal)this.PostageCost);
            }
            if (this.JafferyActualCost.HasValue)
            {
                this.JafferyActualCost = Math.Round((decimal)this.JafferyActualCost);
            }
            if (this.SampleCuttingCost.HasValue)
            {
                this.SampleCuttingCost = Math.Round((decimal)this.SampleCuttingCost);
            }
            if (this.GodownRentCost.HasValue)
            {
                this.GodownRentCost = Math.Round((decimal)this.GodownRentCost);
            }
            if (this.StockInsuranceCost.HasValue)
            {
                this.StockInsuranceCost = Math.Round((decimal)this.StockInsuranceCost);
            }
            if (this.FreightCost.HasValue)
            {
                this.FreightCost = Math.Round((decimal)this.FreightCost);
            }

            //AmountAndVat

            /*this.AmountAndVat = this.Amount + (this.VatRate * this.Amount / 100);
            this.AmountAndVat = Math.Round((decimal)this.AmountAndVat);*/
            
            //Calculation and Rounding for calculated costings
            
            this.CommissionAmount = (this.CommissionRate * this.AmountAndVat) / 100;
            if (this.CommissionAmount.HasValue)
            {
                this.CommissionAmount = Math.Round((decimal)this.CommissionAmount);
            }
            this.CharityAmount = (this.CharityRate * this.AmountAndVat) / 100;
            if (this.CharityAmount.HasValue)
            {
                this.CharityAmount = Math.Round((decimal)this.CharityAmount);
            }
            this.BrokerageAmount = (this.BrokerageRate * this.AmountAndVat) / 100;
            if (this.BrokerageAmount.HasValue)
            {
                this.BrokerageAmount = Math.Round((decimal)this.BrokerageAmount);
            }
            this.CottonDeliveryExpAmount = this.CottonDeliveryExpRate * this.Bales;
            if (this.CottonDeliveryExpAmount.HasValue)
            {
                this.CottonDeliveryExpAmount = Math.Round((decimal)this.CottonDeliveryExpAmount);
            }
            this.MarkingAmount = this.MarkingRate * this.Bales;
            if (this.MarkingAmount.HasValue)
            {
                this.MarkingAmount = Math.Round((decimal)this.MarkingAmount);
            }
            this.CartagePlatformAmount = this.CartagePlatformRate * this.Bales;
            if (this.CartagePlatformAmount.HasValue)
            {
                this.CartagePlatformAmount = Math.Round((decimal)this.CartagePlatformAmount);
            }
            this.StackingAmount = this.StackingRate * this.Bales;
            if (this.StackingAmount.HasValue)
            {
                this.StackingAmount = Math.Round((decimal)this.StackingAmount);
            }
            this.KatlaExpAmount = this.KatlaExpRate * this.Bales;
            if (this.KatlaExpAmount.HasValue)
            {
                this.KatlaExpAmount = Math.Round((decimal)this.KatlaExpAmount);
            }
            this.CartageFactoryAmount = this.CartageFactoryRate * this.Bales;
            if (this.CartageFactoryAmount.HasValue)
            {
                this.CartageFactoryAmount = Math.Round((decimal)this.CartageFactoryAmount);
            }
            this.StationExpAmount = this.StationExpRate * this.Bales;
            if (this.StationExpAmount.HasValue)
            {
                this.StationExpAmount = Math.Round((decimal)this.StationExpAmount);
            }
            this.TruckLoadingAmount = this.TruckLoadingRate * this.Bales;
            if (this.TruckLoadingAmount.HasValue)
            {
                this.TruckLoadingAmount = Math.Round((decimal)this.TruckLoadingAmount);
            }
            this.BankChargeAmount = this.BankChargeCost;
            if (this.BankChargeAmount.HasValue)
            {
                this.BankChargeAmount = Math.Round((decimal)this.BankChargeAmount);
            }
            if (this.CarringChargesFrom != null && this.CarringChargesTo != null)
            {
                DateTime d1 = (DateTime)this.CarringChargesFrom;
                DateTime d2 = (DateTime)this.CarringChargesTo;
                TimeSpan t1 = d2.Subtract(d1);
                this.CarringChargesFor = t1.Days;
            }
            this.CarringChargesAmount = this.CarringChargesOn * this.CarringChargesFor * this.CarringChargesRate/3000;
            if (CarringChargesAmount.HasValue)
            {
                this.CarringChargesAmount = Math.Round((decimal)this.CarringChargesAmount);
            }

            //AmountAndVat

            /*this.AmountAndVat = this.Amount + (5 * this.Amount / 100);
            this.AmountAndVat = Math.Round(this.AmountAndVat);*/

            //Debit Note Total
            this.DebitNoteTotal = (this.CommissionAmount??0) + (this.CharityAmount??0) + (this.BrokerageAmount??0) + (this.PostageCost??0) +
                (this.CottonDeliveryExpAmount??0) + (this.JafferyActualCost??0) + (this.MarkingAmount??0) + (this.SampleCuttingCost??0) +
                (this.CartagePlatformAmount??0) + (this.StackingAmount??0) + (this.KatlaExpAmount??0) + (this.CartageFactoryAmount??0) +
                (this.StationExpAmount??0) + (this.TruckLoadingAmount??0) + (this.BankChargeAmount??0) + (this.GodownRentCost??0) +
                (this.StockInsuranceCost??0) + (this.FreightCost??0) + (this.CarringChargesAmount??0);

            //Insertion in XML
            XDocument doc1 = XDocument.Load(@"Transactions.xml");
            var record = from r in doc1.Descendants("Transaction")
                         where (int)r.Element("Serial") == Serial
                         select r;
            foreach (XElement r in record)
            {
                r.Element("DebitNote").Add(new XElement("DebitNoteNo", this.DebitNoteNo), new XElement("DebitNoteDate", this.DebitNoteDate), new XElement("CommissionRate", this.CommissionRate),
                    new XElement("CommissionAmount", this.CommissionAmount), new XElement("CharityRate", this.CharityRate), new XElement("CharityAmount", this.CharityAmount), new XElement("BrokerageRate", this.BrokerageRate),
                    new XElement("BrokerageAmount", this.BrokerageAmount), new XElement("Postage", this.Postage), new XElement("PostageCost", this.PostageCost), new XElement("CottonDeliveryExpRate", this.CottonDeliveryExpRate),
                    new XElement("CottonDeliveryExpAmount", this.CottonDeliveryExpAmount), new XElement("JafferyActual", this.JafferyActual), new XElement("JafferyActualCost", this.JafferyActualCost), new XElement("MarkingRate", this.MarkingRate),
                    new XElement("MarkingAmount", this.MarkingAmount), new XElement("SampleCutting", this.SampleCutting), new XElement("SampleCuttingCost", this.SampleCuttingCost), new XElement("CartagePlatformRate", this.CartagePlatformRate),
                    new XElement("CartagePlatformAmount", this.CartagePlatformAmount), new XElement("StackingRate", this.StackingRate), new XElement("StackingAmount", this.StackingAmount), new XElement("KatlaExp", this.KatlaExp),
                    new XElement("KatlaExpRate", this.KatlaExpRate), new XElement("KatlaExpAmount", this.KatlaExpAmount), new XElement("CartageFactoryRate", this.CartageFactoryRate), new XElement("CartageFactoryAmount", this.CartageFactoryAmount),
                    new XElement("StationExpRate", this.StationExpRate), new XElement("StationExpAmount", this.StationExpAmount), new XElement("TruckLoadingRate", this.TruckLoadingRate), new XElement("TruckLoadingAmount", this.TruckLoadingAmount),
                    new XElement("BankChargeCost", this.BankChargeCost), new XElement("BankChargeAmount", this.BankChargeAmount), new XElement("GodownRentFrom", this.GodownRentFrom), new XElement("GodownRentTo", this.GodownRentTo),
                    new XElement("GodownRentCost", this.GodownRentCost), new XElement("StockInsurance", this.StockInsurance), new XElement("StockInsuranceCost", this.StockInsuranceCost), new XElement("FreightFrom", this.FreightFrom),
                    new XElement("FreightTo", this.FreightTo), new XElement("FreightCost", this.FreightCost), new XElement("CarringChargesOn", this.CarringChargesOn), new XElement("CarringChargesFrom", this.CarringChargesFrom),
                    new XElement("CarringChargesTo", this.CarringChargesTo), new XElement("CarringChargesFor", this.CarringChargesFor), new XElement("CarringChargesRate", this.CarringChargesRate), new XElement("CarringChargesAmount", this.CarringChargesAmount),
                    new XElement("AmountAndVat", this.AmountAndVat), new XElement("DebitNoteTotal", this.DebitNoteTotal));

            }
            doc1.Save(@"Transactions.xml");
            return "DebitNote Created Successfully";
        }
    }
}
