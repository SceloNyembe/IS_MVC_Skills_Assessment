using DEV_3.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.BusinessLogic.Interface
{
     interface IAccountBusiness
    {
        List<_AccountViewModel> GetAllAccount();
        string GenAccountNumber(int CodeLength);
        void AddAccount(_AccountViewModel objAccountView);
        void UpdateAccount(_AccountViewModel objAccountView);
        void DeleteAccount(int id);
    }
}
