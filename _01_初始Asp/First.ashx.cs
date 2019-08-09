using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace _01_初始Asp
{
    /// <summary>
    /// First 的摘要说明
    /// </summary>
    public class First : IHttpHandler
    {
        /// <summary>
        /// 程序员编写的代码，都要放在这个ProcessRequest中
        /// </summary>
        /// <param name="context">封装了请求报文</param>
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";   // 响应数据类型  文本字符串
            //context.Response.Write("Hello World");   // 响应体，输出服务器响应的结果

            StringBuilder sb = new StringBuilder();

            sb.Append("<html><head><title>第一个动态页面</title></head>");
            sb.Append("<body><table border=1>");
            sb.Append("<tr><td>用户名</td><td>张三丰了ffff1</td></tr>");
            sb.Append("<tr><td>密码</td><td>123456</td></tr>");
            sb.Append("</table></body></html>");

            context.Response.Write(sb.ToString());
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