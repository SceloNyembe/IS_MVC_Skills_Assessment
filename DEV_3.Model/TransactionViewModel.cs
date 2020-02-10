using Dev.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Model
{
    public class TransactionViewModel
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Transaction code ")]
        public int code { get; set; }

          [Display(Name = "Account code ")]
        public int acc_code { get; set; }

        [Display(Name = "Transaction date ")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public System.DateTime transaction_date { get; set; }

        [Display(Name = "Capture date ")]
        public System.DateTime capture_date { get; set; }

        [Display(Name = "Amount")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Display(Name = "Description")]
        public string description { get; set; }
        public virtual Account Account { get; set; }

        [Display(Name = "Available Balance ")]
        public decimal availableBalance { get; set; }
    }
}
