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
        MyRegisterAppWithCRUDEntitiesConn db = new MyRegisterAppWithCRUDEntitiesConn();
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
            return View();
        }
    }
}