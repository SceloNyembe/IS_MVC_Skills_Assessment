
using DEV_3.Data.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Data.Entities
{
   // [Table("Transaction")]
    public class Transaction : IEntity<Transaction>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int code { get; set; }
            public int acc_code { get; set; }
            public System.DateTime transaction_date { get; set; }
            public System.DateTime capture_date { get; set; }
            public decimal amount { get; set; }
            public string description { get; set; }
            public virtual Account Account { get; set; }
        
    }
}
