﻿namespace SipayApi.Data.Models
{
    public class TransactionParameters
    {
        public int AccountNumber { get; set; }
        public string ReferenceNumber { get; set; }

        public decimal MinAmountCredit { get; set; }
        public decimal MaxAmountCredit { get; set; }

        public decimal MinAmountDebit { get; set; }
        public decimal MaxAmountDebit { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }
    }
}
