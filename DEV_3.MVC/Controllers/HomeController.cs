using Dev.BusinessLogic.Implementation;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEV_3.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AccountBusiness AccountBusiness = new AccountBusiness();
        private readonly PersonBusiness PersonBusiness = new PersonBusiness();

        private string getLoggedInUserName
        {
            get
            {
                return User.Identity.Name;
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewHome()
        {
            return View();
        }



        public ActionResult AdminDash(int? page)
        {
            int pagenumber = (page ?? 1);
            return View(PersonBusiness.GetAllPerson().ToPagedList(pagenumber, 10));
        }
        public ActionResult DashPerson(int? page)
        {
            int pagenumber = (page ?? 1);
            var per = PersonBusiness.GetAllPerson().Where(x => x.Email == getLoggedInUserName).FirstOrDefault();
            return View(AccountBusiness.GetAllAccount().Where(x => x.per_code == per.code).ToPagedList(pagenumber, 10));
      
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}