using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseTW.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public string Message { get; set; }
        public double AmountMin { get; set; }
        public double AmountMax { get; set; }
        public CurrencyType Currency { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ExchangeRateMode ExchangeMode { get; set; }
        public bool NeedEscrow { get; set; }
        public string UserId { get; set; }

        public int CloseToZipcode { get; set; }

        public string CompanyDomain { get; set; }
        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
    }

    public enum ExchangeRateMode
    {
        CurrentRate,
        RateOnTrasanctionTime
    }

    public enum CurrencyType
    {
        CNY,
        USD
    }
}