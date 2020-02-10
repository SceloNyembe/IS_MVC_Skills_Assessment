using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PersonViewModel
    {

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Person Code")]
        public int code { get; set; }

        [Display(Name = "Firstname")]
        public string name { get; set; }

        [Display(Name = "Lastname")]
        public string surname { get; set; }

        [Display(Name = "ID Number ")]
        public string id_number { get; set; }

        public string Email { get; set; }

    }
}
