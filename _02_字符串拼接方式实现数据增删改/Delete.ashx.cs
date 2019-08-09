using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02_字符串拼接方式实现数据增删改
{
    /// <summary>
    /// Delete 的摘要说明
    /// </summary>
    public class Delete : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            string keyId = request.QueryString["keyId"];
            SqlUtilLib.SqlHelper.SetConnStr(@"server=.\SQLEXPRESS;uid=sa;pwd=980421cxz;database=dbTest4");

            SqlUtilLib.SqlHelper.ExecuteNonQuery("delete UserInfo where UserId=@UserId", int.Parse(keyId));

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