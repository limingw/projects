using EmployeeManager.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.DAL.DAO
{
    public class TblEmployeeDAO
    {
        public static List<TblEmployee> QueryAll()
        {
            return DBHelper.QueryList(new TblEmployee(), @"select * from TblEmployee order by eid desc");
        }

        public static int Add(TblEmployee emp)
        {
            return DBHelper.Update(@"insert into TblEmployee(deptId,ename,sex,salary) values(@p0,@p1,@p2,@p3)", emp.DeptId, emp.Ename, emp.Sex, emp.Salary);
        }

        public static int Delete(TblEmployee emp)
        {
            return DBHelper.Update(@"delete from TblEmployee where eid=@p0", emp.Eid);
        }

        public static TblEmployee QueryByKey(TblEmployee emp)
        {
            return DBHelper.QueryOne(emp, @"select * from TblEmployee where eid=@p0", emp.Eid);
        }

        public static int Modify(TblEmployee emp)
        {
            return DBHelper.Update(@"update TblEmployee set deptId=@p0,ename=@p1,sex=@p2,salary=@p3 where eid=@p4", emp.DeptId, emp.Ename, emp.Sex, emp.Salary, emp.Eid);
        }

        public static List<VwEmpDept> QueryList()
        {
            return DBHelper.QueryList(new VwEmpDept(), @"select e.eid,e.deptId,e.ename,e.salary,e.indate
                    ,case e.sex when 'm' then '男' else '女' end sex,d.deptName,d.deptInfo
                    from TblEmployee e
                    inner join TblDept d on e.deptId=d.deptId
                    order by e.eid desc");
        }

        public static List<Dictionary<string, object>> QueryDicList()
        {
            return DBHelper.QueryDics(@"select e.eid,e.deptId,e.ename,e.salary,e.indate
                    ,case e.sex when 'm' then '男' else '女' end sex,d.deptName,d.deptInfo
                    from TblEmployee e
                    inner join TblDept d on e.deptId=d.deptId
                    order by e.eid desc");
        }

        public static List<Dictionary<string, object>> QueryPageBase()
        {
            return DBHelper.QueryDics(@"select top 5 * from TblEmployee where eid not in(select top 5 eid from TblEmployee)");
        }

        public static List<Dictionary<string, object>> QueryPage(int PageSize, int Page)
        {
            if (Page == 1)
            {
                return DBHelper.QueryDics(string.Format(@"select top {0} * from TblEmployee", PageSize));
            }
            int start = PageSize * (Page - 1);
            return DBHelper.QueryDics(string.Format(@"select top {0} * from TblEmployee where eid not in(select top {1} eid from TblEmployee)",PageSize,start));
        }


    }
}