using EmployeeManager.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class DeptModel
    {
        //控制器提示消息
        public string Message { get; set; }

        //表单数据
        public TblDept Dept { get; set; }

        //视图查询列表
        public List<TblDept> DeptList { get; set; }
    }
}