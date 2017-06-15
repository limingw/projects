using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeiBo.DAL.Entity;

namespace WeiBo.DAL.DAO
{
    public class TblMessageDAO
    {
        public static List<TblMessage> QueryPage(Page page)
        {
            if (page.PageNumber>1)
            {
                return DBHelper.QueryList(new TblMessage(), string.Format(@"select top {0} m.mid,m.title,m.created,u.nickname from TblMessage m
                           inner join TblUser u on m.uid=u.uid
                           where m.deleted='n' and m.mid not in
                           (select top {1} mid from TblMessage where deleted='n' order by mid desc)
                           order by m.mid desc", page.PageSize, page.Skip));
            }
            return DBHelper.QueryList(new TblMessage(), string.Format(@"select top {0} m.mid,m.title,m.created,u.nickname from TblMessage m
                           inner join TblUser u on m.uid=u.uid
                           where m.deleted='n' order by m.mid desc", page.PageSize));
        }

        public static List<TblMessage> QueryPageUser(Page page,TblUser user)
        {
            if (page.PageNumber > 1)
            {
                return DBHelper.QueryList(new TblMessage(), string.Format(@"select top {0} m.mid,m.title,m.content,m.created,u.nickname from TblMessage m
                           inner join TblUser u on m.uid=u.uid
                           where m.uid=@p0 and m.deleted='n' and m.mid not in
                           (select top {1} mid from TblMessage where deleted='n' order by mid desc)
                           order by m.mid desc", page.PageSize, page.Skip), user.Uid);
            }
            return DBHelper.QueryList(new TblMessage(), string.Format(@"select top {0} m.mid,m.title,m.content,m.created,u.nickname from TblMessage m
                           inner join TblUser u on m.uid=u.uid
                           where m.uid=@p0 and m.deleted='n' order by m.mid desc", page.PageSize), user.Uid);
        }

        public static int Count()
        {
            return (int)DBHelper.QueryValue(@"select count(*) from TblMessage where deleted='n'");
        }

        public static int CountUser(TblUser user)
        {
            return (int)DBHelper.QueryValue(@"select count(*) from TblMessage where uid=@p0 and deleted='n'",user.Uid);
        }

        public static TblMessage QueryByKey(TblMessage message)
        {
            return DBHelper.QueryOne(message, @"select m.mid,m.title,m.content,m.created,u.nickname
                            from TblMessage m
                            inner join TblUser u on m.uid=u.uid
                            where m.mid=@p0", message.Mid);
        }

        public static int Add(TblMessage message)
        {
            return DBHelper.Update(@"insert into TblMessage(uid,title,content) values(@p0,@p1,@p2)",message.Uid,message.Title,message.Content);
        }

        public static int Delete(TblMessage message)
        {
            return DBHelper.Update(@"update TblMessage set deleted='y' where mid=@p0",message.Mid);
        }
    }
}