using Dev.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.Service.Interface
{
    interface ITransactionRepository
    {
        Transaction GetById(int id);
        List<Transaction> GetAll();
        void Insert(Transaction model);
        void Update(Transaction model);
        void Delete(Transaction model);
        IEnumerable<Transaction> Find(Func<Transaction, bool> predicate);
    }
}
