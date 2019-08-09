using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace _02_字符串拼接方式实现数据增删改
{
    /// <summary>
    /// Add 的摘要说明
    /// </summary>
    public class Add : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/html";
            string filePaht = request.MapPath("Add.html");
            string fileContent = File.ReadAllText(filePaht);
            response.Write(fileContent);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}