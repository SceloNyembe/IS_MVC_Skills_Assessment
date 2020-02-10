
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
    public class AccountRepository : IAccountRepository, IDisposable
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Account> _AccountRepository;

        public AccountRepository()
        {
            _datacontext = new ApplicationDbContext();
            _AccountRepository = new RepositoryService<Account>(_datacontext);

        }

        public Account GetById(int id)
        {
            return _AccountRepository.GetById(id);
        }

        public List<Account> GetAll()
        {
            return _AccountRepository.GetAll().ToList();

        }

        public void Insert(Account model)
        {
            _AccountRepository.Insert(model);
            _datacontext.SaveChanges();
        }

        public void Update(Account model)
        {
            _AccountRepository.Update(model);
        }

        public void Delete(Account model)
        {
            _AccountRepository.Delete(model);
        }

        public IEnumerable<Account> Find(Func<Account, bool> predicate)
        {
            return _AccountRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
