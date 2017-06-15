using MyMvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvc1.Controllers
{
    public class OneController : Controller
    {
        //
        // GET: /One/

        public ActionResult Index()
        {
            //简单的传递数据到视图的方法
            ViewBag.Info = "通过ViewBag传递数据";

            //获取到应用程序的http路径对应服务器的位置
            ViewBag.RealPath = Server.MapPath("/Index.html");
            return View();
        }

        public ActionResult Other()
        {
            ViewBag.Info = "其它页面的shuju";
            //通过model传递数据到视图
            OneModel m = new OneModel();
            m.Id = 123;
            m.Name = "滴滴";
            return View(m);
        }
    }
}
