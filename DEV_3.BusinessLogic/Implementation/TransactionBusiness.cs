
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
    public class TransactionBusiness : ITransactionBusiness
    {

        private readonly TransactionRepository TransactionRepo = new TransactionRepository();

        public void AddTransaction(TransactionViewModel objTransactionView,int methodId)
        {
            var per = new Transaction
            {
                code = objTransactionView.code,
                amount = objTransactionView.Amount,
                capture_date = objTransactionView.capture_date,
                description = TransationDescription(methodId),
                Account = objTransactionView.Account,
                transaction_date = objTransactionView.transaction_date,
                acc_code = objTransactionView.acc_code

            };
            TransactionRepo.Insert(per);
        }


        public List<TransactionViewModel> GetAllTransaction()
        {
            return TransactionRepo.GetAll().Select(x => new TransactionViewModel
            {
                code = x.code,
                Amount = x.amount,
                capture_date = x.capture_date,
                description = x.description,
                Account = x.Account,
                transaction_date = x.transaction_date,
                acc_code = x.acc_code
            }).ToList();

        }

        public void UpdateTransaction(TransactionViewModel objTransactionView)
        {
            Transaction tra = TransactionRepo.GetById(objTransactionView.code);
            if (tra != null)
            {
                tra.code = objTransactionView.code;
                tra.amount = objTransactionView.Amount;
                tra.capture_date = objTransactionView.capture_date;
                tra.description = objTransactionView.description;
                tra.Account = objTransactionView.Account;
                tra.transaction_date = objTransactionView.transaction_date;
                tra.acc_code = objTransactionView.acc_code;

                TransactionRepo.Update(tra);
            }

          
        }


        public string TransationDescription(int methodId)
        {
            var desc = "Deposit";

            if(methodId == 0)
            {
                desc = "Withdraw";
            }

            return desc;
        }

        public void Deposit(TransactionViewModel objTransactionView)
        {
            var per = new Transaction
            {
                code = objTransactionView.code,
                amount = objTransactionView.Amount,
                capture_date = objTransactionView.capture_date,
                description = objTransactionView.description,
                Account = objTransactionView.Account,
                transaction_date = objTransactionView.transaction_date,
                acc_code = objTransactionView.acc_code

            };
            TransactionRepo.Insert(per);
        }

        public TransactionViewModel GetTransactionById(int id)
        {

            Transaction tra = TransactionRepo.GetById(id);
            var TraViewModel = new TransactionViewModel();
            if (tra != null)
            {
                TraViewModel.code = tra.code;
                TraViewModel.Amount = tra.amount;
                TraViewModel.capture_date = tra.capture_date;
                TraViewModel.description = tra.description;
                TraViewModel.Account = tra.Account;
                TraViewModel.transaction_date = tra.transaction_date;
                TraViewModel.acc_code = tra.acc_code;

            }
            return TraViewModel;
        }

        public void DeleteTransaction(int id)
        {
            Transaction tra = TransactionRepo.GetById(id);
            if (tra != null)
            {
                TransactionRepo.Delete(tra);
            }
        }

        public void UpdateCurrentBalance(TransactionViewModel model)
        {

        }
    }

}




