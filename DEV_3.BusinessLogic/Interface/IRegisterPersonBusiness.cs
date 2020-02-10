using DEV_3.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.BusinessLogic.Interface
{
    interface IRegisterPersonBusiness
    {
        List<RegisterViewModel> GetAllPerson();
        void AddPerson(RegisterViewModel objPersonView);
        void UpdatePerson(RegisterViewModel objPersonView);
        void DeletePerson(int id);
    }
}
