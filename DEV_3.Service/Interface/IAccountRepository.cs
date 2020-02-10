using Dev.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Service.Interface
{
    public interface IAccountRepository
    {
        Account GetById(int id);
        List<Account> GetAll();
        void Insert(Account model);
        void Update(Account model);
        void Delete(Account model);
        IEnumerable<Account> Find(Func<Account, bool> predicate);
    }
}
