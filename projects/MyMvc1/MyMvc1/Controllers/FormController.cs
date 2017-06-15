using MyMvc1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvc1.Controllers
{
    //类名称，属性名称，方法名称都是首字母大写，变量都是首字母小写
    //作业：编写用户注册界面，用户名：密码，确认密码；校验：用户名密码必须填写，密码和确认密码必须一致
    public class FormController : Controller
    {
        //创建测试用的数据集合
        private List<MyMvc1.Models.Type> GetTypes()
        {
            List<MyMvc1.Models.Type> types = new List<Models.Type>();
            MyMvc1.Models.Type t = new Models.Type();
            t.Tid = 100;
            t.TypeName = "管理员";
            types.Add(t);

            t = new Models.Type();
            t.Tid = 101;
            t.TypeName = "用户";
            types.Add(t);
            return types;
        }

        public ActionResult Index()
        {
            //Model的初始化数据
            FormModel fm = new FormModel();
            fm.Types = this.GetTypes();
            return View(fm);
        }
        /*表单数据通过方法参数提交，一般参数是一个包含和页面提交数据名字一致字段的对象，官方一般都是使用model对象*/
        public ActionResult Login(FormModel fm)
        {
            fm.Types = this.GetTypes();
            if (String.IsNullOrEmpty(fm.UserName))
            {
                fm.Error = "用户名没有填写...";
                //用户名没有填写，页面转回Index,View("本控制器的其它视图名"),可以直接跳转到参数对应的视图
                return View("Index",fm);
            }
            if (String.IsNullOrEmpty(fm.Password))
            {
                fm.Error = "密码没有填写...";
                return View("Index",fm);
            }
            return View(fm);
        }
    }
}
