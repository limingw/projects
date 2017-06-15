using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;

namespace EmployeeManager.DAL.DAO
{
    public class DBHelper
    {
        //处理sql参数
        public static void ProcessArgs(SqlCommand comm, params object[] args)
        {
            if (args == null)
            {
                return;
            }
            for (int i = 0; i < args.Length; i++)
            {
                comm.Parameters.AddWithValue("@p" + i, args[i]);
            }
        }

        //获取对象的属性信息！！！
        //propertyInfo是对象属性信息，包含属性名称和类型，以及动态设置属性信息的方法
        public static Dictionary<string, PropertyInfo> GetProperties(object o)
        {
            Dictionary<string, PropertyInfo> dic = new Dictionary<string, PropertyInfo>();
            //获取对象的类型信息
            Type t = o.GetType();
            //获取类型的全部属性
            PropertyInfo[] infos = t.GetProperties();
            foreach (PropertyInfo info in infos)
            {
                dic.Add(info.Name.ToLower(), info);
            }

            return dic;
        }

        //获取查询结果的列名称
        public static Dictionary<string, string> GetQueryCols(SqlDataReader reader)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            //查询结果的列的数量
            int cols = reader.FieldCount;
            for (int i = 0; i < cols; i++)
            {
                //获取列名称
                string colName = reader.GetName(i);
                dic.Add(colName.ToLower(), colName);
            }
            return dic;
        }

        //查询数据库记录到Entity集合
        public static List<T> QueryList<T>(T t, string sql, params object[] args)
        {
            List<T> list = new List<T>();
            using (SqlConnection conn = DBConn.GetConn())
            {
                //获取对象属性信息
                Dictionary<string, PropertyInfo> ps = GetProperties(t);
                //数据库查询
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                //获取查询列的信息
                Dictionary<string, string> cols = GetQueryCols(reader);
                //处理查询数据
                while (reader.Read())
                {
                    //动态创建T对象
                    T result = (T)Activator.CreateInstance(t.GetType());
                    //匹配字段数据到实体类属性
                    foreach (string col in cols.Keys)
                    {
                        //获取查询列名称
                        string colName = cols[col];
                        //判断是否存在对应的属性
                        if (ps.ContainsKey(col))
                        {
                            PropertyInfo p = ps[col];
                            //动态设置属性
                            p.SetValue(result, reader[colName]);
                        }
                    }
                    list.Add(result);
                }
                reader.Close();
                conn.Close();
            }

            return list;
        }

        //查询单行数据库记录到Entity集合
        public static T QueryOne<T>(T t, string sql, params object[] args)
        {
            //创建一个默认的T对象（null）
            T result = default(T);
            using (SqlConnection conn = DBConn.GetConn())
            {
                //获取对象属性信息
                Dictionary<string, PropertyInfo> ps = GetProperties(t);
                //数据库查询
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                SqlDataReader reader = comm.ExecuteReader();
                //获取查询列的信息
                Dictionary<string, string> cols = GetQueryCols(reader);
                //处理查询数据
                if (reader.Read())
                {
                    //动态创建T对象
                    result = (T)Activator.CreateInstance(t.GetType());
                    //匹配字段数据到实体类属性
                    foreach (string col in cols.Keys)
                    {
                        //获取查询列名称
                        string colName = cols[col];
                        //判断是否存在对应的属性
                        if (ps.ContainsKey(col))
                        {
                            PropertyInfo p = ps[col];
                            //动态设置属性
                            p.SetValue(result, reader[colName]);
                        }
                    }
                }
                reader.Close();
                conn.Close();
            }

            return result;
        }

        public static int Update(string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                int result = comm.ExecuteNonQuery();
                conn.Close();
                return result;
            }
        }

        public static object QueryValue(string sql, params object[] args)
        {
            using (SqlConnection conn = DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql, conn);
                ProcessArgs(comm, args);
                object result = comm.ExecuteScalar();
                conn.Close();
                return result;
            }
        }

        public static List<Dictionary<string, object>> QueryDics(string sql,params object[] args)
        { 
            //查询成字典的集合可以匹配任意的查询结果
            List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
            using (SqlConnection conn=DBConn.GetConn())
            {
                SqlCommand comm = new SqlCommand(sql,conn);
                ProcessArgs(comm,args);
                SqlDataReader reader = comm.ExecuteReader();
                //获取查询结果的列名称集合(key集合)
                Dictionary<string, string> cols = GetQueryCols(reader);
                while (reader.Read())
                {
                    //用字典代替实体
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    //添加列数据
                    foreach (string col in cols.Keys)
                    {
                        object value = reader[cols[col]];
                        dic.Add(col,value);
                    }
                    list.Add(dic);  //一个dic就是一行数据
                }
                reader.Close();
                conn.Close();
            }
            return list;
        }
    }
}