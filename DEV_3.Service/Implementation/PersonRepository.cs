
using Dev.Data.Entities;
using Dev.Service.Interface;
using DEV_3.Data;
using DEV_3.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.Service.Implementation
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private ApplicationDbContext _datacontext = null;
        private readonly IRepository<Person> _PersonRepository;

        public PersonRepository()
        {
            _datacontext = new ApplicationDbContext();
            _PersonRepository = new RepositoryService<Person>(_datacontext);

        }

        public Person GetById(int id)
        {
            return _PersonRepository.GetById(id);
        }

        public List<Person> GetAll()
        {
            return _PersonRepository.GetAll().ToList();

        }

        public void Insert(Person model)
        {
            _PersonRepository.Insert(model);
        }

        public void Update(Person model)
        {
            _PersonRepository.Update(model);
        }

        public void Delete(Person model)
        {
            _PersonRepository.Delete(model);
        }

        public IEnumerable<Person> Find(Func<Person, bool> predicate)
        {
            return _PersonRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
