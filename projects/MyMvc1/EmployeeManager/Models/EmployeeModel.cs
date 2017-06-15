using EmployeeManager.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class EmployeeModel
    {
        public string Message { get; set; }
        public TblEmployee Employee { get; set; }
        public List<TblEmployee> EmployeeList { get; set; }

        public List<TblDept> DeptList { get; set; }
        public List<VwEmpDept> EmpDeptList { get; set; }
        public List<Dictionary<string, object>> DicList { get; set; }
        public List<Dictionary<string, object>> PageBase { get; set; }
        public List<Dictionary<string, object>> PageList { get; set; }

        //分页表单信息
        public int Page { get; set; }
    }
}