
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
    // [Table("Account")]
    public class Account : IEntity<Account>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int code { get; set; }
        public int per_code { get; set; }

        public int Person_code { get; set; }
        public string account_number { get; set; }
        public decimal outstanding_balance { get; set; }

        public string status { get; set; }

       public virtual Person Person { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
