
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
    public class AccountBusiness : IAccountBusiness
    {

        private readonly AccountRepository AccountRepo = new AccountRepository();

        public void AddAccount(_AccountViewModel objAccountView)
        {
            var acc = new Account
            {
                code = objAccountView.code,
                per_code = objAccountView.per_code,
                account_number = objAccountView.account_number,
                outstanding_balance = objAccountView.outstanding_balance,
                status = "Active" ,
                Person = objAccountView.Person,
                Transactions = objAccountView.Transactions


            };
            AccountRepo.Insert(acc);
        }

        public string GenAccountNumber(int CodeLength)
        {
            string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
            Random randNum = new Random();
            char[] chars = new char[CodeLength];
            int allowedCharCount = _allowedChars.Length;
            for (int i = 0; i < CodeLength; i++)
            {
                chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
            }
            return new string(chars);
        }



        public List<_AccountViewModel> GetAllAccount()
        {
            return AccountRepo.GetAll().Select(x => new _AccountViewModel
            {
                code = x.code,
                account_number = x.account_number,
                outstanding_balance = x.outstanding_balance,
                Person = x.Person,
                Transactions = x.Transactions,
                per_code = x.per_code,

            status = x.status
            }).ToList();

        }


        public void UpdateAccount(_AccountViewModel objAccountView)
        {
            Account acc = AccountRepo.GetById(objAccountView.code);
            if (acc != null)
            {
                acc.code = objAccountView.code;
                acc.account_number = objAccountView.account_number;
                acc.outstanding_balance = objAccountView.outstanding_balance;
                acc.Person = objAccountView.Person;
                acc.Transactions = objAccountView.Transactions;
                acc.status = objAccountView.status;
                AccountRepo.Update(acc);
            }
        }


        public void UpdateAccountBalance(int code, decimal depositAmount, int methodId)
        {
            Account acc = AccountRepo.GetById(code);
            if (acc != null)
            {
                if (methodId == 1)
                {
                    acc.outstanding_balance = (acc.outstanding_balance + depositAmount);
                }
                else if (methodId == 0)
                {
                    if (IsOutstandingBalanceGreater(acc.outstanding_balance, depositAmount))
                    {
                        acc.outstanding_balance = (acc.outstanding_balance - depositAmount);
                    }
                    else
                    {
                        throw new Exception("Insufficient amount");
                    }
                }

                AccountRepo.Update(acc);
            }
        }


        public bool IsOutstandingBalanceGreater(decimal outstanding_balance, decimal withdralAmount)
        {
            return outstanding_balance > withdralAmount;
        }
        public _AccountViewModel GetAccountById(int id)
        {

            Account acc = AccountRepo.GetById(id);
            var AccViewModel = new _AccountViewModel();
            if (acc != null)
            {
                AccViewModel.code = acc.code;
                AccViewModel.account_number = acc.account_number;
                AccViewModel.outstanding_balance = acc.outstanding_balance;
                AccViewModel.Person = acc.Person;
                AccViewModel.Transactions = acc.Transactions;
              AccViewModel.status = acc.status;
                AccountRepo.Update(acc);
            }
            return AccViewModel;
        }

        public void DeleteAccount(int id)
        {
            Account per = AccountRepo.GetById(id);
            if (per != null)
            {
                AccountRepo.Delete(per);
            }
        }

        

    }

}




