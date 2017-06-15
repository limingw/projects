using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.DAL.Entity;

namespace WeiBo.DAL.DAO
{
    public class TblReturnDAO
    {
        public static List<TblReturn> QueryByMid(TblMessage message)
        {
            return DBHelper.QueryList(new TblReturn(), @"select r.rid,r.content,r.created,u.nickname
                     from TblReturn r
                     inner join TblUser u on r.uid=u.uid
                     where r.mid=@p0", message.Mid);
        }

        public static int Add(TblReturn r)
        {
            return DBHelper.Update(@"insert into TblReturn(mid,uid,content) values(@p0,@p1,@p2)",r.Mid,r.Uid,r.Content);
        }
    }
}