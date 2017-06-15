using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.DAL.DAO;
using WeiBo.Models;

namespace WeiBo.Controllers
{
    public class DefaultController : Controller
    {
        //
        // 创建QQ空间数据库，里面包括用户信息表，创建说说表，创建说说回复表，创建QQ空间项目，完成基本MVC框架，完成用户登录和注册页面

        public ActionResult Index(DefaultModel model)
        {
            model.PageInfo.Count = TblMessageDAO.Count();
            model.MessageList = TblMessageDAO.QueryPage(model.PageInfo);
            return View(model);
        }

        
    }
}
