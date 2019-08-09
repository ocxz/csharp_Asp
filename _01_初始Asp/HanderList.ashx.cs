using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace _01_初始Asp
{
    /// <summary>
    /// HanderList 的摘要说明
    /// </summary>
    public class HanderList : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;   // 获取请求对象
            HttpResponse response = context.Response;   // 获取响应对象

            // 获得post请求参数
            string name = request.Form.Get("uname");
            string pwd = request.Form.Get("upwd");

            // 获取文件路径
            string filePath = request.MapPath("List.html");

            // 读取文件内容，且替换占位符
            string fileContent = File.ReadAllText(filePath).Replace("%uname", name).Replace("%upwd", pwd);

            // 设置响应数据类型
            response.ContentType = "text/html";

            // 将文件内容写入到响应体中，响应
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