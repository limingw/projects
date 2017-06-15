using FileUpload.DAL.DAO;
using FileUpload.DAL.Entity;
using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileUpload.Controllers
{
    public class DefaultController : Controller
    {
        //创建用户上传文件管理数据库
        //包含用户信息表和用户上传文件信息表
        //创建用户上传文件管理项目
        //完成项目初始化
        //完成实体类
        //完成上传文件目录自动初始化功能

        public ActionResult Index(DefaultModel model)
        {
            model.PageInfo.Count = TblFilesDAO.QueryCount();
            model.Files = TblFilesDAO.QueryPage(model.PageInfo);
            return View(model);
        }

        public ActionResult Upload(DefaultModel model, HttpPostedFileBase uploadfile)
        {
            //处理上传文件保存在服务器中的名称，不能有相同的名称（使用Guid完成）
            string filepath = Guid.NewGuid().ToString();
            //获取真实保存文件的位置
            string savepath = Server.MapPath(FileUpload.MvcApplication.UploadDir + filepath);
            //保存上传文件到指定位置
            uploadfile.SaveAs(savepath);
            model.UpFile.Filepath = filepath;
            //获取上传的文件名称
            string filename = uploadfile.FileName;
            //处理ie上传文件名是完整路径的问题
            if (filename.IndexOf("\\") > -1)
            {
                filename.Substring(filename.LastIndexOf("\\") + 1);
            }
            model.UpFile.Filename = filename;
            //获取上传文件的mime类型
            model.UpFile.ContentType = uploadfile.ContentType;
            //获取上传文件的大小
            model.UpFile.Size = uploadfile.ContentLength;
            //保存到数据库
            TblFilesDAO.Add(model.UpFile);
            return RedirectToAction("Index", "Default");
        }

        public FileResult DownLoad(DefaultModel model)
        {
            //查询
            model.UpFile = TblFilesDAO.QueryByKey(model.UpFile);
            //获取文件保存在服务器的地址
            string savepath = FileUpload.MvcApplication.UploadDir + model.UpFile.Filepath;
            savepath = Server.MapPath(savepath);
            //应答结果
            return File(savepath, model.UpFile.ContentType, model.UpFile.Filename);
        }

        public ActionResult ShowImage(DefaultModel model)
        {
            return View(model);
        }

        public ActionResult ToAddFiles(DefaultModel model)
        {
            return View(model);
        }

        public ActionResult UploadFiles(DefaultModel model, HttpPostedFileBase[] uploadfile)
        {
            try
            {
                if (uploadfile != null)
                {
                    foreach (HttpPostedFileBase f in uploadfile)
                    {
                        TblFiles file = new TblFiles();
                        file.Description = model.UpFile.Description;
                        //处理ie上传文件名是完整路径的问题
                        if (f.FileName.IndexOf("\\") > -1)
                        {
                            f.FileName.Substring(f.FileName.LastIndexOf("\\") + 1);
                        }
                        file.Filename = f.FileName;
                        file.ContentType = f.ContentType;
                        file.Size = f.ContentLength;
                        file.Filepath = Guid.NewGuid().ToString();
                        string savepath = Server.MapPath(FileUpload.MvcApplication.UploadDir + file.Filepath);
                        f.SaveAs(savepath);
                        TblFilesDAO.Add(file);
                    }
                    model.ActionCode = 200;
                }
            }
            catch (Exception ex)
            {
                model.ActionCode = 500;
                model.ActionMessage = ex.Message;
            }
            return View("ToAddFiles", model);
        }
    }
}
