using Dev.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Service.Interface
{
    interface IRegisterPersonRepository
    {
        Person GetById(int id);
        List<Person> GetAll();
        void Insert(Person model);
        void Update(Person model);
        void Delete(Person model);
        IEnumerable<Person> Find(Func<Person, bool> predicate);
    }
}
