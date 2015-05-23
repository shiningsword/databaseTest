using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DatabaseTW.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public string RecipientUserName { get; set; }
        public string SenderUserName { get; set; }
        public string Message { get; set; }
        public CurrencyAmount Amount { get; set; }
        public string SenderUserId { get; set; }
        public string RecipientUserId { get; set; }

        [ForeignKey("SenderUserId")]
        virtual public ApplicationUser SenderUser { get; set; }
        [ForeignKey("RecipientUserId")]
        virtual public ApplicationUser RecipientUser { get; set; }        
    }
}