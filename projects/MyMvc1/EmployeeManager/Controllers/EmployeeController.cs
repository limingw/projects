using EmployeeManager.DAL.DAO;
using EmployeeManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManager.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        public ActionResult Index()
        {
            EmployeeModel model = new EmployeeModel();
            model.DeptList = TblDeptDAO.QueryAll();
            model.EmployeeList = TblEmployeeDAO.QueryAll();
            return View(model);
        }

        public ActionResult Add(EmployeeModel model)
        {
            try
            {
                TblEmployeeDAO.Add(model.Employee);
                model.Message = "添加信息成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            model.EmployeeList = TblEmployeeDAO.QueryAll();
            return View("Index", model);
        }

        public ActionResult ToModify(EmployeeModel model)
        {
            try
            {
                model.Employee = TblEmployeeDAO.QueryByKey(model.Employee);
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            return View(model);
        }

        public ActionResult Modify(EmployeeModel model)
        {
            try
            {
                TblEmployeeDAO.Modify(model.Employee);
                model.Message = "修改成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            model.DeptList = TblDeptDAO.QueryAll();
            return View("ToModify", model);
        }

        public ActionResult Delete(EmployeeModel model)
        {
            try
            {
                TblEmployeeDAO.Delete(model.Employee);
                model.Message = "删除成功";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return View("Index", model);
        }

        public ActionResult List()
        {
            EmployeeModel model = new EmployeeModel();
            model.Page = 1;
            SetList(model);
            return View(model);
        }

        public ActionResult Page(EmployeeModel model)
        {
            if (model.Page <= 0) //设置页数下限
            {
                model.Page = 1;
            }
            SetList(model);
            return View("List", model);
        }


        private void SetList(EmployeeModel model)
        {
            //设置List页面需要的数据
            model.EmpDeptList = TblEmployeeDAO.QueryList();
            model.DicList = TblEmployeeDAO.QueryDicList();
            model.PageBase = TblEmployeeDAO.QueryPageBase();
            model.PageList = TblEmployeeDAO.QueryPage(7, model.Page);
        }
    }
}
