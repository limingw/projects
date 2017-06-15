using MyMvc1.DAL.DAO;
using MyMvc1.DAL.Entity;
using MyMvc1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvc1.Controllers
{
    public class TestController : Controller
    {
        /*
           -创建学校管理数据库，包含班级表和学生表
         * 创建学校管理系统的MVC项目，创建实体层和数据可访问层，创建测试MVC文件，测试数据库连接
         * 创建DBHelper类，测试DBHelper类的全部数据库方法
         */

        public ActionResult Index()
        {
                TestModel model = new TestModel();
                using (SqlConnection conn=DBConn.GetConn())
                {
                    model.DataBase = conn.Database;
                    conn.Close();
                }
                model.DataBase = "还没连接...";
                TblDept dept = DBHelper.QueryOne(new TblDept(), "select top 1 * from TblDept");

                model.Dept = dept;

                //测试属性获取
                model.Properties = DBHelper.GetProperties(new TblEmployee());

                //测试数据库查询到集合
                model.DeptList = DBHelper.QueryList(new TblDept(),"select * from TblDept");

                model.Count = (int)DBHelper.QueryValue("select count(*) from TblDept");
                ViewBag.Rows = DBHelper.Update(@"insert into TblDept(deptName,deptInfo) values(@p0,@p1)","部门"+new Random().Next(),"部门描述...");

                return View(model);
        }

    }
}
