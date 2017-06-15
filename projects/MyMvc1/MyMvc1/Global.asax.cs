using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMvc1
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        //当服务器任何页面被请求的时候要先进入的方法
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //获取请求的路径信息
            string path = Context.Request.FilePath;
            //如果请求是/（网站首页）
            if ("/".Equals(path))
            {
                //改写请求页面到指定页面
                Context.RewritePath("/index.html");
                //可以是真实的页面，也可以是MVC页面
                //Context.RewritePath("/One/Index");
            }
        }

        //当网页发生错误的时候会先进入该方法
        protected void Application_Error(object sender, EventArgs e)
        {
            //获取服务器最后发生的错误
            Exception ex = Server.GetLastError();
            if (!(ex is HttpException))
            {
                //如果不是Http的错误就不处理
                return;
            }
            //获取http的错误代码
            HttpException he = (HttpException)ex;
            int code = he.GetHttpCode();
            if (code == 404)
            {
                //如果是404错误转到页面找不到
                Response.Redirect("/Error/Error404");
            }
        }
    }
}