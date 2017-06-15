using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeiBo.DAL.DAO;
using WeiBo.DAL.Entity;
using WeiBo.Models;

namespace WeiBo.Controllers
{
    public class MessageController : Controller
    {
        public ActionResult Info(MessageModel model)
        {
            model.Info = TblMessageDAO.QueryByKey(model.Info);
            model.RList = TblReturnDAO.QueryByMid(model.Info);
            return View(model);
        }

        public ActionResult List(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user==null)
            {
                return RedirectToAction("Index","Default");
            }
            model.PageInfo.Count = TblMessageDAO.CountUser(user);
            model.MList = TblMessageDAO.QueryPageUser(model.PageInfo, user);
            return View(model);
        }

        public ActionResult Delete(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            TblMessageDAO.Delete(model.Info);
            model.PageInfo.Count = TblMessageDAO.CountUser(user);
            model.MList = TblMessageDAO.QueryPageUser(model.PageInfo, user);
            return View("List",model);
        }

        public ActionResult Add(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            try
            {
                //不需要页面提交当前用户
                //直接在session中获取登录的用户信息，然后添加给数据库
                model.Info.Uid = user.Uid;
                TblMessageDAO.Add(model.Info);
                model.Message = "添加成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.PageInfo.Count = TblMessageDAO.CountUser(user);
            model.MList = TblMessageDAO.QueryPageUser(model.PageInfo, user);
            return View("List", model);
        }

        public ActionResult AddReturn(MessageModel model)
        {
            TblUser user = (TblUser)Session["LoginUser"];
            if (user == null)
            {
                return RedirectToAction("Index", "Default");
            }
            try
            {
                model.RInfo.Uid = user.Uid;
                TblReturnDAO.Add(model.RInfo);
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return Redirect("/Message/Info?Info.Mid="+model.RInfo.Mid);
        }
    }
}
