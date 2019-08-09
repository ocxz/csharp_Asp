using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02_字符串拼接方式实现数据增删改
{
    /// <summary>
    /// HanderAdd 的摘要说明
    /// </summary>
    public class HanderAdd : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            SqlUtilLib.SqlHelper.SetConnStr(@"server=.\SQLEXPRESS;uid=sa;pwd=980421cxz;database=dbTest4");

            string uname = request.Form["uname"];
            string upwd = request.Form["upwd"];

            string sql = string.Format("insert UserInfo values('{0}','{1}')", uname, upwd);
            SqlUtilLib.SqlHelper.ExecuteNonQuery(sql);

            response.Redirect("HShowUser.ashx");
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