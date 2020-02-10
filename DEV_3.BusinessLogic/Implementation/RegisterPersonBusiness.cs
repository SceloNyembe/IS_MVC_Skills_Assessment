
using Dev.Data.Entities;
using Dev.Service.Implementation;
using Dev.Service.Interface;
using DEV_3.BusinessLogic.Interface;
using DEV_3.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.BusinessLogic.Implementation
{
    public class RegisterPersonBusiness : IRegisterPersonBusiness
    {

        private readonly RegisterPersonRepository personRepo = new RegisterPersonRepository();

      

  
        public void AddPerson(RegisterViewModel objPersonView)
        {
            var per = new Person
            {
                code = objPersonView.code,
                name = objPersonView.name,
                surname = objPersonView.surname,
                id_number = objPersonView.id_number
            };
            personRepo.Insert(per);
        }


        public List<RegisterViewModel> GetAllPerson()
        {
            return personRepo.GetAll().Select(x => new RegisterViewModel
            {
                code = x.code,
                name = x.name,
                surname = x.surname,
                id_number = x.id_number,
                Email = x.Email,
            }).ToList();

        }

        public void UpdatePerson(RegisterViewModel objPersonView)
        {
            Person per = personRepo.GetById(objPersonView.code);
            if (per != null)
            {
                per.code = objPersonView.code;
                per.code = objPersonView.code;
                per.code = objPersonView.code;
                per.code = objPersonView.code;
                personRepo.Update(per);
            }
        }

        public PersonViewModel GetPersonById(int id)
        {

            Person per = personRepo.GetById(id);
            var perViewModel = new PersonViewModel();
            if (per != null)
            {
                perViewModel.code = per.code;
                perViewModel.name = per.name;
                perViewModel.surname = per.surname;
                perViewModel.id_number = per.id_number;
            }
            return perViewModel;
        }

        public void DeletePerson(int id)
        {
            Person per = personRepo.GetById(id);
            if (per != null)
            {
                personRepo.Delete(per);
            }
        }

    }

}
      


   
