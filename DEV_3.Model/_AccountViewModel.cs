using Dev.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Model
{
    public class _AccountViewModel
    {
        [Key]
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Account code ")]
        public int code { get; set; }

          [Display(Name = "Person code")]
         public int per_code { get; set; }

        [Display(Name = "Account number")]
        public string account_number { get; set; }

        [Display(Name = "Outstanding balance")]
        [DataType(DataType.Currency)]
        public decimal outstanding_balance { get; set; }

        [Display(Name = "Account Status")]
        public string status { get; set; }

        public virtual Person Person { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
