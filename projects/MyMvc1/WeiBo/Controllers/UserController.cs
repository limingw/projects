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
    public class UserController : Controller
    {

        public ActionResult Index()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        public ActionResult ToReg()
        {
            UserModel model = new UserModel();
            return View(model);
        }

        public ActionResult Reg(UserModel model)
        {
            try
            {
                TblUserDAO.Reg(model.User);
                model.Message = "注册成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("ToReg", model);
        }

        public ActionResult Login(UserModel model)
        {
            try
            {
                TblUser user = TblUserDAO.Login(model.User);
                if (user != null)  //登录成功的情况
                {
                    Session.Add("LoginUser", user);
                    //登录成功不需要传递信息，页面转到用户首页
                    return RedirectToAction("Index", "User");
                }
                else
                {
                    model.Message = "登录失败";
                }
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("Index",model);
        }

        public ActionResult Logout()
        {
            //移除session中的登录用户信息
            Session.Remove("LoginUser");
            //View和redirectToAction的区别，view不会让浏览器发起二次请求，而是直接让浏览器看到view对应的视图
            //redirectToAction会通知浏览器中断当前请求，重写发起对redirectToAction参数请求的页面

            return RedirectToAction("Index","User");
        }
    }
}
