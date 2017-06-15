using EmployeeManager.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.Models
{
    public class PageModel
    {
        public Page PageInfo { get; set; }
        public List<Dictionary<string, object>> PageData { get; set; }
        public string Message { get; set; }

        //为了确保控制器能获取到基础分页信息，需要对属性做初始化，构造函数是创建对象必须执行代码，作用就是初始化
        public PageModel()
        {
            PageInfo = new Page();
            PageData = new List<Dictionary<string, object>>();
        }
    }
}