using FileUpload.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileUpload.DAL.DAO
{
    public class TblFilesDAO
    {
        public static int Add(TblFiles file)
        {
            return DBHelper.Update(@"insert into TblFiles(filename,filepath,size,description,contentType) values(@p0,@p1,@p2,@p3,@p4)"
                 ,file.Filename,file.Filepath,file.Size,file.Description,file.ContentType);
        }

        public static int QueryCount()
        {
            return (int)DBHelper.QueryValue(@"select count(*) from TblFiles");
        }

        public static List<TblFiles> QueryPage(Page page)
        {
            return DBHelper.QueryList(new TblFiles(),string.Format(@"select top {0} * from TblFiles where fid not in(select top {1} fid from TblFiles)",page.PageSize,page.Skip));
        }

        public static TblFiles QueryByKey(TblFiles files)
        {
            return DBHelper.QueryOne(files,@"select * from TblFiles where fid=@p0",files.Fid);
        }
    }
}