using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.BusinessLogic.Interface
{
    interface IPersonBusiness
    {
        List<PersonViewModel> GetAllPerson();
        void AddPerson(PersonViewModel objPersonView);
        void UpdatePerson(PersonViewModel objPersonView);
        void DeletePerson(int id);
    }
}
