using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace _01_初始Asp
{
    /// <summary>
    /// HanderSelfAdd 的摘要说明
    /// </summary>
    public class HanderSelfAdd : IHttpHandler
    { 
        //public static int num = 0;   以类静态变量的方式保存数据
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/html";

            int num = Convert.ToInt32(request.Form["hiddenNum"]);    // 没有参数时，即为null时默认值为0
            //int num = Convert.ToInt32(request.Form["hiddenNum"]);    // 接收隐藏域的值，

            string filePath = request.MapPath("SelfAdd.html");

            num++;

            string fileContent = File.ReadAllText(filePath).Replace("%num", num.ToString());
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