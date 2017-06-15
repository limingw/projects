using EmployeeManager.DAL.DAO;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class DeptController : Controller
    {
        //
        // GET: /Dept/

        public ActionResult Index()
        {
            DeptModel model = new DeptModel();
            model.DeptList = TblDeptDAO.QueryAll();

            return View(model);
        }

        public ActionResult Add(DeptModel model)
        {
            try
            {
                TblDeptDAO.Add(model.Dept);
                model.Message = "添加部门信息成功";
            }
            catch (Exception ex)
            {
                //传递错误到页面
                model.Message = ex.Message;
            }
            //需要查询更新数据
            model.DeptList = TblDeptDAO.QueryAll();
            //添加完成数据返回到添加页面
            return View("Index",model);
        }

        public ActionResult Delete(DeptModel model)
        {
            try
            {
                TblDeptDAO.Delete(model.Dept.DeptId);
                model.Message = "删除部门成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            return View("Index",model);
        }

        public ActionResult ToModify(DeptModel model)
        {
            model.Dept = TblDeptDAO.QueryByKey(model.Dept);
            return View(model);
        }

        public ActionResult Modify(DeptModel model)
        {
            try
            {
                TblDeptDAO.Modify(model.Dept);
                model.Message = "修改部门信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("ToModify",model);
        }
    }
}
