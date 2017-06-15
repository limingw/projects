using EmployeeManager.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeManager.DAL.DAO
{
    public class TblDeptDAO
    {
        public static List<TblDept> QueryAll()
        {
            return DBHelper.QueryList(new TblDept(),@"select * from TblDept order by deptId desc");
        }

        public static int Add(TblDept dept)
        {
            return DBHelper.Update(@"insert into TblDept(deptName,deptInfo) values(@p0,@p1)",dept.DeptName,dept.DeptInfo);
        }

        public static int Delete(int deptId)
        {
            return DBHelper.Update(@"delete from TblDept where deptId=@p0",deptId);
        }

        public static TblDept QueryByKey(TblDept dept)
        {
            return DBHelper.QueryOne(dept,@"select * from TblDept where deptId=@p0",dept.DeptId);
        }

        public static int Modify(TblDept dept)
        {
            return DBHelper.Update(@"update TblDept set deptName=@p0,deptInfo=@p1 where deptId=@p2",dept.DeptName,dept.DeptInfo,dept.DeptId);
        }
    }
}