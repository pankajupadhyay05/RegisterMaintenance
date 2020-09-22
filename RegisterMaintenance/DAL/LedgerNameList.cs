using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

namespace RegisterMaintenance.DAL
{
    class LedgerNameList
    {
        public string Ledger { get; set; }
    }

    class DAL_LedgerNameList
    {
        public static List<LedgerNameList> LoadLedgerNameList()
        {
            List<LedgerNameList> ListLedgerNameList = new List<LedgerNameList>();
            // Execute the query using the LINQ to XML
            var records = (from r in XElement.Load(@"Ledgers.xml").Elements("Ledger") select r.Element("Name").Value).Distinct();
            foreach (var record in records)
            {
                LedgerNameList lLedgerNameList = new LedgerNameList
                {
                    Ledger = record
                };
                ListLedgerNameList.Add(lLedgerNameList);
            }
            return ListLedgerNameList;
        }

        public static List<string> LoadLedgerNameListString()
        {
            List<string> ListLedgerNameListString = new List<string>();
            // Execute the query using the LINQ to XML
            var records = (from r in XElement.Load(@"Ledgers.xml").Elements("Ledger") select r.Element("Name").Value).Distinct();
            foreach (var record in records)
            {
                string lLedgerNameListString = record;
                ListLedgerNameListString.Add(lLedgerNameListString);
            }
            return ListLedgerNameListString;
        }
    }
}
