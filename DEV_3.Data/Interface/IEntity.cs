using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Data.Interface
{
    public interface IEntity<T>
    {
         int code { get; set; }
    }
}
