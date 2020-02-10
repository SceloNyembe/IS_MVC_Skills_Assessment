
using Dev.Data.Entities;
using Dev.Service.Implementation;
using Dev.Service.Interface;
using DEV_3.BusinessLogic.Interface;
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
    public class PersonBusiness : IPersonBusiness
    {

        private readonly PersonRepository personRepo = new PersonRepository();

        public void AddPerson(PersonViewModel objPersonView)
        {
            var per = new Person
            {
                code = objPersonView.code,
                name = objPersonView.name,
                surname = objPersonView.surname,
                id_number = objPersonView.id_number,
                Email = objPersonView.Email

            };
            personRepo.Insert(per);
        }


        public List<PersonViewModel> GetAllPerson()
        {
            return personRepo.GetAll().Select(x => new PersonViewModel
            {
                code = x.code,
                name = x.name,
                surname = x.surname,
                id_number = x.id_number,
                Email =x.Email
            }).ToList();

        }

        public void UpdatePerson(PersonViewModel objPersonView)
        {
            Person per = personRepo.GetById(objPersonView.code);
            if (per != null)
            {
                per.code = objPersonView.code;
                per.name = objPersonView.name;
                per.surname = objPersonView.surname; 
                per.id_number = objPersonView.id_number;
                per.Email = objPersonView.Email;
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
                perViewModel.Email = per.Email;


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
      


   
