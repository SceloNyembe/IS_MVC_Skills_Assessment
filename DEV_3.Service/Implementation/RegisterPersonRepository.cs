
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
    public class RegisterPersonRepository : IRegisterPersonRepository, IDisposable
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Person> _RegisterPersonRepository;

        public RegisterPersonRepository()
        {
            _datacontext = new ApplicationDbContext();
            _RegisterPersonRepository = new RepositoryService<Person>(_datacontext);

        }

        public Person GetById(int id)
        {
            return _RegisterPersonRepository.GetById(id);
        }

        public List<Person> GetAll()
        {
            return _RegisterPersonRepository.GetAll().ToList();

        }

        public void Insert(Person model)
        {
            _RegisterPersonRepository.Insert(model);
            _datacontext.SaveChanges();
        }

        public void Update(Person model)
        {
            _RegisterPersonRepository.Update(model);
        }

        public void Delete(Person model)
        {
            _RegisterPersonRepository.Delete(model);
        }

        public IEnumerable<Person> Find(Func<Person, bool> predicate)
        {
            return _RegisterPersonRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
