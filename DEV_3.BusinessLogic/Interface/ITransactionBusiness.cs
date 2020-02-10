using DEV_3.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEV_3.BusinessLogic.Interface
{
    interface ITransactionBusiness
    {
        List<TransactionViewModel> GetAllTransaction();
        void AddTransaction(TransactionViewModel objTransactionView,int methodId);
        void UpdateTransaction(TransactionViewModel objTransactionView);
        void DeleteTransaction(int id);
    }
}
