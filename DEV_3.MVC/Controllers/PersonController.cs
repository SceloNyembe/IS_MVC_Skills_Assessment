using Dev.BusinessLogic.Implementation;
using DEV_3.Model;
using Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DEV_3.MVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        private readonly PersonBusiness personBusiness = new PersonBusiness();

        private readonly AccountBusiness AccountBusiness = new AccountBusiness();

        public ActionResult PersonList(int? page)
        {
            int pagenumber = (page ?? 1);
            return View(personBusiness.GetAllPerson().ToPagedList(pagenumber, 10));
  
        }

        public ActionResult MyAccounts(int? page)
        {
            int pagenumber = (page ?? 1);
           // var loggedInUser = System.Web.HttpContext.Current.User.Identity.Name;
            var loggedInUser = User.Identity.Name;
            var person = personBusiness.GetAllPerson().Where(x => x.Email == loggedInUser);
            
            //foreach(var y in AccountBusiness.GetAllAccount())
            //{
            //    if (y.Person.Email =  person)
            //    {
            //        return View(AccountBusiness.GetAllAccount().Where(x => x.Person.Email == loggedInUser).ToList().FirstOrDefault());
            //    }
            //}

           // var accounts = AccountBusiness.GetAllAccount().Where(x=>x.Person)

return View(AccountBusiness.GetAllAccount().Where(x => x.Person.Email == loggedInUser).ToList().FirstOrDefault());


        }

        public ActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPerson(PersonViewModel model)
        {
            var per = personBusiness.GetAllPerson().Where(x => x.id_number == model.id_number).FirstOrDefault();

            if (per == null)
            { 
                    personBusiness.AddPerson(model);
                    return RedirectToAction("PersonList");
            }
            else
            {
                ViewBag.Addper = "User with  ID Number [ " + model.id_number + " ] already exists!";
                return View(model);
            }


        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AddPerson(RegisterViewModel model)
        //{
        //    var per = personBusiness.GetAllPerson().Where(x => x.id_number == model.id_number).FirstOrDefault();

        //    if (per == null)
        //    {
        //        personBusiness.AddPerson(model);
        //        return RedirectToAction("PersonList");
        //    }
        //    else
        //    {
        //        ViewBag.Addper = "User with  ID Number [ " + model.id_number + " ] already exists!";
        //        return View(model);
        //    }


        //}

        [HttpGet]
        public ActionResult EditPerson(int id)
        {
            return View(personBusiness.GetPersonById(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPerson(PersonViewModel model)
        {
            if (ModelState.IsValid)
            {
                personBusiness.UpdatePerson(model);
                return RedirectToAction("PersonList");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DeletePerson(int id)
        {
            return View(personBusiness.GetPersonById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePerson(PersonViewModel model, int id)
        {
            //personBusiness.GetPersonById(id);
            personBusiness.DeletePerson(id);

            Content("Successful");
            return RedirectToAction("PersonList");


        }

    }
}