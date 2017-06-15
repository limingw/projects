using MyMvc1.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MyMvc1.Models
{
    public class TestModel
    {
        public TblDept Dept { get; set; }

        public string DataBase { get; set; }

        public List<TblDept> DeptList { get; set; }

        public Dictionary<string, PropertyInfo> Properties { get; set; }

        public int Count { get; set; }
    }
}