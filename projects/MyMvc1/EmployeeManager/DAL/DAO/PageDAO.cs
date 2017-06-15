using EmployeeManager.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.DAL.DAO
{
    public class PageDAO
    {
        public static int Count()  //查询记录总数
        {
            return (int)DBHelper.QueryValue(@"select count(*) from TblEmployee");
        }

        public static List<Dictionary<string, object>> QueryPageData(Page page)
        {
            if (page.PageNumber>1)
            {
                return DBHelper.QueryDics(string.Format(@"select top {0} * from TblEmployee where eid not in(select top {1} eid from TblEmployee)",page.PageSize,page.Skip));
            }
            return DBHelper.QueryDics(string.Format(@"select top {0} * from TblEmployee",page.PageSize));
        }
    }
}