using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class SessionController : Controller
    {
        //
        // GET: /Session/

        public ActionResult Index(String name)
        {
            //浏览器变量
            if (!string.IsNullOrWhiteSpace(name))
            {
                //记录提交到name到浏览器变量中
                Session.Add("SessionName",name);
            }
            return View();
        }

        public ActionResult One()
        {
            return View();
        }
    }
}
