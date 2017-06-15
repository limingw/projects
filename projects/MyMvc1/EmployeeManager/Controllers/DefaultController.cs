using EmployeeManager.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test()
        {
            using (SqlConnection conn=DBConn.GetConn())
            {
                ViewBag.DataBase = conn.Database;
                conn.Close();
            }
            return View();
        }
    }
}
