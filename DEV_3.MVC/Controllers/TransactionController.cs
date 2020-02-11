using Dev.BusinessLogic.Implementation;
using DEV_3.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEV_3.MVC.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        private readonly TransactionBusiness TransactionBusiness = new TransactionBusiness();
        private readonly AccountBusiness AccountBusiness = new AccountBusiness();
        private readonly PersonBusiness PersonBusiness = new PersonBusiness();

        private string getLoggedInUserName
        {
            get
            {
                return User.Identity.Name;
            }
        }
        public ActionResult TransactionList()
        {
          
            return View(TransactionBusiness.GetAllTransaction().ToList());

        }

        public ActionResult MyTransactions()
        {
            var per = PersonBusiness.GetAllPerson().Where(x => x.Email == getLoggedInUserName).FirstOrDefault();

            var acc = AccountBusiness.GetAllAccount().Where(x => x.per_code == per.code).ToList();

            List<TransactionViewModel> myTransactions = new List<TransactionViewModel>(); 
            foreach (var x in acc) 
            { 
                if(x.per_code==per.code)
                {
                   myTransactions= TransactionBusiness.GetAllTransaction().Where(y => y.acc_code == x.code).ToList();
                }
            }

            return View(myTransactions.ToList());

        }

        public ActionResult AddTransaction(int id, int methodId)
        {

            var model = new TransactionViewModel();
            var account = AccountBusiness.GetAccountById(id);

            if (account != null)
            {
                model.availableBalance = account.outstanding_balance;
                Session["account_code"] = id;
                Session["methodId"] = methodId;

                ViewBag.MethodId = methodId;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTransaction(TransactionViewModel model)
        {
            int id = Convert.ToInt16(Session["account_code"]);
            var per = PersonBusiness.GetAllPerson().Where(x => x.Email == getLoggedInUserName).FirstOrDefault();
            var acc = AccountBusiness.GetAccountById(id);

            if (model.transaction_date > System.DateTime.Now)
            {
                ViewBag.Date = "transaction date can never be in the future";
                return View(model);
            }
            if(model.Amount<=0)
            {
                ViewBag.Amount = "amount must be greater than 0{zer0}";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                int account_code = Convert.ToInt16(Session["account_code"].ToString());
                int methodId = Convert.ToInt16(Session["methodId"].ToString());
                try
                {
                    AccountBusiness.UpdateAccountBalance(account_code, model.Amount, methodId);
                }
                catch (Exception e)
                {
                    ViewBag.WithdralError = e.Message;
                    return View(model);
                }

                model.capture_date = System.DateTime.Now;
                model.acc_code = acc.code;
                TransactionBusiness.AddTransaction(model, methodId);

                return RedirectToAction("MyTransactions");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditTransaction(int id)
        {
            return View(TransactionBusiness.GetTransactionById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditTransaction(TransactionViewModel model)
        {

            if (ModelState.IsValid)
            {

                TransactionBusiness.UpdateTransaction(model);
                return RedirectToAction("TransactionList");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteTransaction(int id)
        {
            return View(TransactionBusiness.GetTransactionById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTransaction(TransactionViewModel model, int id)
        {
            //TransactionBusiness.GetTransactionById(id);
            TransactionBusiness.DeleteTransaction(id);

            Content("Successful");
            return RedirectToAction("TransactionList");


        }
    }
}