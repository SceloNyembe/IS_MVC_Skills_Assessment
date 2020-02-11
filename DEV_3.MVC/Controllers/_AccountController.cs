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
    [Authorize]
    public class _AccountController : Controller
    {
        // GET: _Account
        private readonly AccountBusiness AccountBusiness = new AccountBusiness();
        private readonly PersonBusiness PersonBusiness = new PersonBusiness();
     
        private string getLoggedInUserName
        {
            get
            {
               return User.Identity.Name; 
            }
        }
        public ActionResult AccountList()
        {
            
            return View(AccountBusiness.GetAllAccount().ToList());

        }

        public ActionResult Acc()
       { 
            return View(AccountBusiness.GetAllAccount().ToList());
        }
        public ActionResult MyAccountList()
        {
          
            var per = PersonBusiness.GetAllPerson().Where(x => x.Email == getLoggedInUserName).FirstOrDefault();
            return View(AccountBusiness.GetAllAccount().Where(x => x.per_code == per.code).ToList());
        }

        public ActionResult AddAccount()
        {
            string acc_no = AccountBusiness.GenAccountNumber(6);
            var model = new  _AccountViewModel();
           
            model.account_number = acc_no;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAccount(_AccountViewModel model)
        {

            var per = PersonBusiness.GetAllPerson().Where(x => x.Email == getLoggedInUserName).FirstOrDefault().code;
            string acc_no = AccountBusiness.GenAccountNumber(6);
            var acc = AccountBusiness.GetAllAccount().Where(x => x.account_number == acc_no).FirstOrDefault();

            if (acc == null)
            {
                model.account_number = acc_no;
                model.per_code = per;
                AccountBusiness.AddAccount(model);
                return RedirectToAction("MyAccountList");
            }
            else
            {
                ViewBag.AddAcc = "User with  ID Number [ " + model.account_number + " ] already exists!";
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult EditAccount(int id)
        {
            return View(AccountBusiness.GetAccountById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccount(_AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountBusiness.UpdateAccount(model);
                return RedirectToAction("AccountList");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditAccountAdmin(int id)
        {
            return View(AccountBusiness.GetAccountById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditAccountAdmin(_AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                AccountBusiness.UpdateAccount(model);
                return RedirectToAction("AccountList");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult CloseOpenAccount(int id,int statusId)
        {
            var account =AccountBusiness.GetAccountById(id);

            string status = string.Empty;
            if(statusId==0)
            {
                status = "Closed";
            }
            else if(statusId==1)
            {
                status = "Active";
            }
            ViewBag.StatusId = statusId;
            Session["StatusId"] = statusId;
            Session["status"] = status;
            return View(account);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CloseOpenAccount(_AccountViewModel model)
        {

            int statusId = Convert.ToInt16(Session["StatusId"]);
            string status = Session["status"].ToString();

            if (statusId==0 && model.outstanding_balance<=0)
            {
                ViewBag.AccStatus = "you cannot close an account with balance less or equal to 0 {zero}";
                return View(model);
            }

            if (ModelState.IsValid)
            {
                model.status = status;
                AccountBusiness.UpdateAccount(model);
                return RedirectToAction("MyAccountList");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeleteAccount(int id)
        {
            return View(AccountBusiness.GetAccountById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAccount(_AccountViewModel model, int id)
        {
            //AccountBusiness.GetAccountById(id);
            AccountBusiness.DeleteAccount(id);

            Content("Successful");
            return RedirectToAction("AccountList");


        }
    }
}