using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.DAL.Entity
{
    //继承与主表的实体对象(可以获得主表的全部属性)
    public class VwEmpDept:TblEmployee
    {
        public string DeptName { get; set; }
        public string DeptInfo { get; set; }
    }
}