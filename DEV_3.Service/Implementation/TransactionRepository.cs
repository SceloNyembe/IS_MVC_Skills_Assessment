
using Dev.Data.Entities;
using Dev.Service.Interface;
using DEV_3.Data;
using DEV_3.Interface;
using DEV_3.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Implementation
{
    public class TransactionRepository : ITransactionRepository, IDisposable
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Transaction> _TransactionRepository;

        public TransactionRepository()
        {
            _datacontext = new ApplicationDbContext();
            _TransactionRepository = new RepositoryService<Transaction>(_datacontext);

        }

        public Transaction GetById(int id)
        {
            return _TransactionRepository.GetById(id);
        }

        public List<Transaction> GetAll()
        {
            return _TransactionRepository.GetAll().ToList();

        }

        public void Insert(Transaction model)
        {
            _TransactionRepository.Insert(model);
            _datacontext.SaveChanges();
        }

        public void Update(Transaction model)
        {
            _TransactionRepository.Update(model);
        }

        public void Delete(Transaction model)
        {
            _TransactionRepository.Delete(model);
        }

        public IEnumerable<Transaction> Find(Func<Transaction, bool> predicate)
        {
            return _TransactionRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
