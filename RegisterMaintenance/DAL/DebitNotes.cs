using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace RegisterMaintenance.DAL
{
    public class DebitNotes
    {
        public int DebitNoteId { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string DebitNoteNo { get; set; }
        public DateTime DebitNoteDate { get; set; }
        public string Station { get; set; }
        public decimal? Bales { get; set; }
        public string Quality { get; set; }
        public decimal InvoiceAmount { get; set; }
        public string Buyer { get; set; }
        public string PressSerialFrom { get; set; }
        public string PressSerialTo { get; set; }
        public string PressMark { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? DespatchDate { get; set; }
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
        

        public string Update()
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
            this.CarringChargesAmount = this.CarringChargesOn * this.CarringChargesFor * this.CarringChargesRate / 3000;
            if (CarringChargesAmount.HasValue)
            {
                this.CarringChargesAmount = Math.Round((decimal)this.CarringChargesAmount);
            }

            //AmountAndVat

            
            //Debit Note Total
            this.DebitNoteTotal = (this.CommissionAmount ?? 0) + (this.CharityAmount ?? 0) + (this.BrokerageAmount ?? 0) + (this.PostageCost ?? 0) +
                (this.CottonDeliveryExpAmount ?? 0) + (this.JafferyActualCost ?? 0) + (this.MarkingAmount ?? 0) + (this.SampleCuttingCost ?? 0) +
                (this.CartagePlatformAmount ?? 0) + (this.StackingAmount ?? 0) + (this.KatlaExpAmount ?? 0) + (this.CartageFactoryAmount ?? 0) +
                (this.StationExpAmount ?? 0) + (this.TruckLoadingAmount ?? 0) + (this.BankChargeAmount ?? 0) + (this.GodownRentCost ?? 0) +
                (this.StockInsuranceCost ?? 0) + (this.FreightCost ?? 0) + (this.CarringChargesAmount ?? 0);

            //Update XML
            XDocument doc = XDocument.Load(@"Transactions.xml");
            var record = from r in doc.Descendants("Transaction")
                         where (int)r.Element("DebitNote").Attribute("Id") == DebitNoteId
                         select r;
            foreach (XElement r in record)
            {
                r.Element("DebitNote").Element("DebitNoteNo").Value = DebitNoteNo;
                r.Element("DebitNote").Element("DebitNoteDate").Value = XmlConvert.ToString(DebitNoteDate, XmlDateTimeSerializationMode.RoundtripKind);
                r.Element("DebitNote").Element("CommissionRate").Value = CommissionRate.ToString();
                r.Element("DebitNote").Element("CommissionAmount").Value = CommissionAmount.ToString();
                r.Element("DebitNote").Element("CharityRate").Value = CharityRate.ToString();
                r.Element("DebitNote").Element("CharityAmount").Value = CharityAmount.ToString();
                r.Element("DebitNote").Element("BrokerageRate").Value = BrokerageRate.ToString();
                r.Element("DebitNote").Element("BrokerageAmount").Value = BrokerageAmount.ToString();
                r.Element("DebitNote").Element("Postage").Value = Postage;
                r.Element("DebitNote").Element("PostageCost").Value = PostageCost.ToString();
                r.Element("DebitNote").Element("CottonDeliveryExpRate").Value = CottonDeliveryExpRate.ToString();
                r.Element("DebitNote").Element("CottonDeliveryExpAmount").Value = CottonDeliveryExpAmount.ToString();
                r.Element("DebitNote").Element("JafferyActual").Value = JafferyActual;
                r.Element("DebitNote").Element("JafferyActualCost").Value = JafferyActualCost.ToString();
                r.Element("DebitNote").Element("MarkingRate").Value = MarkingRate.ToString();
                r.Element("DebitNote").Element("MarkingAmount").Value = MarkingAmount.ToString();
                r.Element("DebitNote").Element("SampleCutting").Value = SampleCutting;
                r.Element("DebitNote").Element("SampleCuttingCost").Value = SampleCuttingCost.ToString();
                r.Element("DebitNote").Element("PostageCost").Value = PostageCost.ToString();
                r.Element("DebitNote").Element("CartagePlatformRate").Value = CartagePlatformRate.ToString();
                r.Element("DebitNote").Element("CartagePlatformAmount").Value = CartagePlatformAmount.ToString();
                r.Element("DebitNote").Element("StackingRate").Value = StackingRate.ToString();
                r.Element("DebitNote").Element("StackingAmount").Value = StackingAmount.ToString();
                r.Element("DebitNote").Element("KatlaExp").Value = KatlaExp;
                r.Element("DebitNote").Element("KatlaExpRate").Value = KatlaExpRate.ToString();
                r.Element("DebitNote").Element("KatlaExpAmount").Value = KatlaExpAmount.ToString();
                r.Element("DebitNote").Element("CartageFactoryRate").Value = CartageFactoryRate.ToString();
                r.Element("DebitNote").Element("CartageFactoryAmount").Value = CartageFactoryAmount.ToString();
                r.Element("DebitNote").Element("StationExpRate").Value = StationExpRate.ToString();
                r.Element("DebitNote").Element("StationExpAmount").Value = StationExpAmount.ToString();
                r.Element("DebitNote").Element("TruckLoadingRate").Value = TruckLoadingRate.ToString();
                r.Element("DebitNote").Element("TruckLoadingAmount").Value = TruckLoadingAmount.ToString();
                r.Element("DebitNote").Element("BankChargeCost").Value = BankChargeCost.ToString();
                r.Element("DebitNote").Element("BankChargeAmount").Value = BankChargeAmount.ToString();
                r.Element("DebitNote").Element("GodownRentFrom").Value = GodownRentFrom.HasValue? XmlConvert.ToString(GodownRentFrom.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("DebitNote").Element("GodownRentTo").Value = GodownRentTo.HasValue ? XmlConvert.ToString(GodownRentTo.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("DebitNote").Element("GodownRentCost").Value = GodownRentCost.ToString();
                r.Element("DebitNote").Element("StockInsurance").Value = StockInsurance;
                r.Element("DebitNote").Element("StockInsuranceCost").Value = StockInsuranceCost.ToString();
                r.Element("DebitNote").Element("FreightFrom").Value = FreightFrom;
                r.Element("DebitNote").Element("FreightTo").Value = FreightTo;
                r.Element("DebitNote").Element("FreightCost").Value = FreightCost.ToString();
                r.Element("DebitNote").Element("CarringChargesOn").Value = CarringChargesOn.ToString();
                r.Element("DebitNote").Element("CarringChargesFrom").Value = CarringChargesFrom.HasValue ? XmlConvert.ToString(CarringChargesFrom.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("DebitNote").Element("CarringChargesTo").Value = CarringChargesTo.HasValue ? XmlConvert.ToString(CarringChargesTo.Value, XmlDateTimeSerializationMode.RoundtripKind) : "";
                r.Element("DebitNote").Element("CarringChargesFor").Value = CarringChargesFor.ToString();
                r.Element("DebitNote").Element("CarringChargesRate").Value = CarringChargesRate.ToString();
                r.Element("DebitNote").Element("CarringChargesAmount").Value = CarringChargesAmount.ToString();
                r.Element("DebitNote").Element("AmountAndVat").Value = AmountAndVat.ToString();
                r.Element("DebitNote").Element("DebitNoteTotal").Value = DebitNoteTotal.ToString();                
            }
            doc.Save(@"Transactions.xml");
            return "Record Updated";
        }
    }
    class DAL_DebitNotes
    {
        public static List<DebitNotes> LoadDebitNotes()
        {
            List<DebitNotes> ListDebitNoteRecords = new List<DebitNotes>();
            // Execute the query using the LINQ to XML
            var records = from r in XElement.Load(@"Transactions.xml").Elements("Transaction")
                          where r.Element("DebitNote").HasElements
                          select r;
            foreach (var record in records)
            {
                DebitNotes lDebitNote = new DebitNotes
                {
                    DebitNoteId = (int)record.Element("DebitNote").Attribute("Id"),
                    DebitNoteNo = record.Element("DebitNote").Element("DebitNoteNo").Value,
                    DebitNoteDate = (DateTime)record.Element("DebitNote").Element("DebitNoteDate"),
                    InvoiceNo = record.Element("Invoice").Element("InvoiceNo").Value,
                    InvoiceDate = (DateTime)record.Element("Invoice").Element("InvoiceDate"),
                    Station = record.Element("Station").Value,
                    Bales = (decimal)record.Element("Bales"),
                    Quality = record.Element("Quality").Value,
                    Buyer = record.Element("Buyer").Value,
                    PressSerialFrom = record.Element("PressSerialFrom").Value,
                    PressSerialTo = record.Element("PressSerialTo").Value,
                    PressMark = record.Element("PressMark").Value,
                    DueDate = record.Element("DueDate") != null && !record.Element("DueDate").Nodes().Any() ? null : (DateTime?)record.Element("DueDate"),
                    DespatchDate = record.Element("DespatchDate") != null && !record.Element("DespatchDate").Nodes().Any() ? null : (DateTime?)record.Element("DespatchDate"),
                    InvoiceAmount = (decimal)record.Element("Invoice").Element("InvoiceAmount"),
                    LotNo = record.Element("LotNo").Value,
                    CommissionRate = record.Element("DebitNote").Element("CommissionRate") != null && !record.Element("DebitNote").Element("CommissionRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CommissionRate"),
                    CommissionAmount = record.Element("DebitNote").Element("CommissionAmount") != null && !record.Element("DebitNote").Element("CommissionAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CommissionAmount"),
                    CharityRate = record.Element("DebitNote").Element("CharityRate") != null && !record.Element("DebitNote").Element("CharityRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CharityRate"),
                    CharityAmount = record.Element("DebitNote").Element("CharityAmount") != null && !record.Element("DebitNote").Element("CharityAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CharityAmount"),
                    BrokerageRate = record.Element("DebitNote").Element("BrokerageRate") != null && !record.Element("DebitNote").Element("BrokerageRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("BrokerageRate"),
                    BrokerageAmount = record.Element("DebitNote").Element("BrokerageAmount") != null && !record.Element("DebitNote").Element("BrokerageAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("BrokerageAmount"),
                    Postage = record.Element("DebitNote").Element("Postage").Value,
                    PostageCost = record.Element("DebitNote").Element("PostageCost") != null && !record.Element("DebitNote").Element("PostageCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("PostageCost"),
                    CottonDeliveryExpRate = record.Element("DebitNote").Element("CottonDeliveryExpRate") != null && !record.Element("DebitNote").Element("CottonDeliveryExpRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CottonDeliveryExpRate"),
                    CottonDeliveryExpAmount = record.Element("DebitNote").Element("CottonDeliveryExpAmount") != null && !record.Element("DebitNote").Element("CottonDeliveryExpAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CottonDeliveryExpAmount"),
                    JafferyActual = record.Element("DebitNote").Element("JafferyActual").Value,
                    JafferyActualCost = record.Element("DebitNote").Element("JafferyActualCost") != null && !record.Element("DebitNote").Element("JafferyActualCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("JafferyActualCost"),
                    MarkingRate = record.Element("DebitNote").Element("MarkingRate") != null && !record.Element("DebitNote").Element("MarkingRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("MarkingRate"),
                    MarkingAmount = record.Element("DebitNote").Element("MarkingAmount") != null && !record.Element("DebitNote").Element("MarkingAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("MarkingAmount"),
                    SampleCutting = record.Element("DebitNote").Element("SampleCutting").Value,
                    SampleCuttingCost = record.Element("DebitNote").Element("SampleCuttingCost") != null && !record.Element("DebitNote").Element("SampleCuttingCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("SampleCuttingCost"),
                    CartagePlatformRate = record.Element("DebitNote").Element("CartagePlatformRate") != null && !record.Element("DebitNote").Element("CartagePlatformRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CartagePlatformRate"),
                    CartagePlatformAmount = record.Element("DebitNote").Element("CartagePlatformAmount") != null && !record.Element("DebitNote").Element("CartagePlatformAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CartagePlatformAmount"),
                    StackingRate = record.Element("DebitNote").Element("StackingRate") != null && !record.Element("DebitNote").Element("StackingRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("StackingRate"),
                    StackingAmount = record.Element("DebitNote").Element("StackingAmount") != null && !record.Element("DebitNote").Element("StackingAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("StackingAmount"),
                    KatlaExp = record.Element("DebitNote").Element("KatlaExp").Value,
                    KatlaExpRate = record.Element("DebitNote").Element("KatlaExpRate") != null && !record.Element("DebitNote").Element("KatlaExpRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("KatlaExpRate"),
                    KatlaExpAmount = record.Element("DebitNote").Element("KatlaExpAmount") != null && !record.Element("DebitNote").Element("KatlaExpAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("KatlaExpAmount"),
                    CartageFactoryRate = record.Element("DebitNote").Element("CartageFactoryRate") != null && !record.Element("DebitNote").Element("CartageFactoryRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CartageFactoryRate"),
                    CartageFactoryAmount = record.Element("DebitNote").Element("CartageFactoryAmount") != null && !record.Element("DebitNote").Element("CartageFactoryAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CartageFactoryAmount"),
                    StationExpRate = record.Element("DebitNote").Element("StationExpRate") != null && !record.Element("DebitNote").Element("StationExpRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("StationExpRate"),
                    StationExpAmount = record.Element("DebitNote").Element("StationExpAmount") != null && !record.Element("DebitNote").Element("StationExpAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("StationExpAmount"),
                    TruckLoadingRate = record.Element("DebitNote").Element("TruckLoadingRate") != null && !record.Element("DebitNote").Element("TruckLoadingRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("TruckLoadingRate"),
                    TruckLoadingAmount = record.Element("DebitNote").Element("TruckLoadingAmount") != null && !record.Element("DebitNote").Element("TruckLoadingAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("TruckLoadingAmount"),
                    BankChargeCost = record.Element("DebitNote").Element("BankChargeCost") != null && !record.Element("DebitNote").Element("BankChargeCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("BankChargeCost"),
                    BankChargeAmount = record.Element("DebitNote").Element("BankChargeAmount") != null && !record.Element("DebitNote").Element("BankChargeAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("BankChargeAmount"),
                    GodownRentFrom = record.Element("DebitNote").Element("GodownRentFrom") != null && !record.Element("DebitNote").Element("GodownRentFrom").Nodes().Any() ? null : (DateTime?)record.Element("DebitNote").Element("GodownRentFrom"),
                    GodownRentTo = record.Element("DebitNote").Element("GodownRentTo") != null && !record.Element("DebitNote").Element("GodownRentTo").Nodes().Any() ? null : (DateTime?)record.Element("DebitNote").Element("GodownRentTo"),
                    GodownRentCost = record.Element("DebitNote").Element("GodownRentCost") != null && !record.Element("DebitNote").Element("GodownRentCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("GodownRentCost"),
                    StockInsurance = record.Element("DebitNote").Element("StockInsurance").Value,
                    StockInsuranceCost = record.Element("DebitNote").Element("StockInsuranceCost") != null && !record.Element("DebitNote").Element("StockInsuranceCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("StockInsuranceCost"),
                    FreightFrom = record.Element("DebitNote").Element("FreightFrom").Value,
                    FreightTo = record.Element("DebitNote").Element("FreightTo").Value,
                    FreightCost = record.Element("DebitNote").Element("FreightCost") != null && !record.Element("DebitNote").Element("FreightCost").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("FreightCost"),
                    CarringChargesOn = record.Element("DebitNote").Element("CarringChargesOn") != null && !record.Element("DebitNote").Element("CarringChargesOn").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CarringChargesOn"),
                    CarringChargesFrom = record.Element("DebitNote").Element("CarringChargesFrom") != null && !record.Element("DebitNote").Element("CarringChargesFrom").Nodes().Any() ? null : (DateTime?)record.Element("DebitNote").Element("CarringChargesFrom"),
                    CarringChargesTo = record.Element("DebitNote").Element("CarringChargesTo") != null && !record.Element("DebitNote").Element("CarringChargesTo").Nodes().Any() ? null : (DateTime?)record.Element("DebitNote").Element("CarringChargesTo"),
                    CarringChargesFor = record.Element("DebitNote").Element("CarringChargesFor") != null && !record.Element("DebitNote").Element("CarringChargesFor").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CarringChargesFor"),
                    CarringChargesRate = record.Element("DebitNote").Element("CarringChargesRate") != null && !record.Element("DebitNote").Element("CarringChargesRate").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CarringChargesRate"),
                    CarringChargesAmount = record.Element("DebitNote").Element("CarringChargesAmount") != null && !record.Element("DebitNote").Element("CarringChargesAmount").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("CarringChargesAmount"),
                    AmountAndVat = record.Element("DebitNote").Element("AmountAndVat") != null && !record.Element("DebitNote").Element("AmountAndVat").Nodes().Any() ? null : (decimal?)record.Element("DebitNote").Element("AmountAndVat"),
                    DebitNoteTotal = (decimal)record.Element("DebitNote").Element("DebitNoteTotal")
                };
                ListDebitNoteRecords.Add(lDebitNote);
            }
            return ListDebitNoteRecords;
        }
    }
}
