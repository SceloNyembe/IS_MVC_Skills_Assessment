
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
     // [Table("Person")]
    public class Person : IEntity<Person>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int code { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string id_number { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }

    }
}
