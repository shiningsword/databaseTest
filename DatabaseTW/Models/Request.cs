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
        public CurrencyAmount AmountMin { get; set; }
        public CurrencyAmount AmountMax { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ExchangeRateMode ExchangeMode { get; set; }
        public bool NeedEscrow { get; set; }
        public string UserId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual ApplicationUser User { get; set; }
    }

    public enum ExchangeRateMode
    {
        CurrentRate,
        RateOnTrasanctionTime
    }

    public struct CurrencyAmount
    {
        public double Amount;
        public CurrencyType Type;
    }

    public enum CurrencyType
    {
        CNY,
        USD
    }
}