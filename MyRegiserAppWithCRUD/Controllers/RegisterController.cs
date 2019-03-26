using MyRegiserAppWithCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyRegiserAppWithCRUD.Controllers
{
    public class RegisterController : Controller
    {
        MyRegisterAppWithCRUDEntities1 db = new MyRegisterAppWithCRUDEntities1();
        // GET: Register
        public ActionResult SetDataInDatabase()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult SetDataInDatabase(LoginPanel model)
        {
            LoginPanel tbl = new LoginPanel();
            tbl.Username = model.Username;
            tbl.Password = model.Password;

            db.LoginPanels.Add(tbl);
            db.SaveChanges();
            return View();
        }

        public ActionResult ShowDataToTheUSer()
        {
            var TableFromDatabaseLoginPanel = db.LoginPanels.ToList();
            return View(TableFromDatabaseLoginPanel);
        }


        public ActionResult Delete(int id)
        {
            var item = db.LoginPanels.Where(x => x.ID == id).First();
            db.LoginPanels.Remove(item);
            db.SaveChanges();

            var item2 = db.LoginPanels.ToList();
            return View("ShowDataToTheUSer",item2);
        }

        public ActionResult Edit(int id)
        {
            var item = db.LoginPanels.Where(x => x.ID == id).First();
            return View(item);
        }
        [HttpPost]
        public ActionResult Edit(LoginPanel model)
        {
            var item = db.LoginPanels.Where(x => x.ID ==model.ID).First();
            item.Username = model.Username;
            item.Password = model.Password;
            db.SaveChanges();
            return View();
        }

        public JsonResult CheckUSernameAvailability(string userdata)
        {
            var searchData = db.LoginPanels.Where(x => x.Username== userdata).SingleOrDefault();
            if (searchData != null)
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }
        }
    }
}