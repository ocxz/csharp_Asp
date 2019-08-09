using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace _01_初始Asp
{
    /// <summary>
    /// HanderPost 的摘要说明
    /// </summary>
    public class HanderPost : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/html";

            string par = request.QueryString.Get("par");

            string filePath = request.MapPath("PostDemo.html");

            string fileContent = File.ReadAllText(filePath).Replace("%par",par);

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