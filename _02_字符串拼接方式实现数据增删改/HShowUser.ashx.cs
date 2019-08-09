using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SqlUtilLib;
using System.IO;
using System.Text;
using System.Data;

namespace _02_字符串拼接方式实现数据增删改
{
    /// <summary>
    /// HShowUser 的摘要说明
    /// </summary>
    public class HShowUser : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;
            response.ContentType = "text/html";
            string filePath = request.MapPath("ShowUser.html");

            StringBuilder thead = new StringBuilder();    // 用来存放表头
            StringBuilder tbody = new StringBuilder();     // 用来存放表体

            SqlHelper.SetConnStr(@"server=.\SQLEXPRESS;uid=sa;pwd=980421cxz;database=dbTest4");
            DataTable data = SqlHelper.GetDataTable("select * from UserInfo");

            // thead格式  <td>1</td>
            foreach (DataColumn dc in data.Columns)
            {
                thead.AppendFormat("<td>{0}</td>", dc.ColumnName);
            }

            // 格式 <tr><td>1</td></tr>
            int rowindex = 1;
            foreach (DataRow dr in data.Rows)
            {
                tbody.AppendFormat("<tr>");
                tbody.AppendFormat("<td>{0}</td>",rowindex++);

                for (int i = 1; i < data.Columns.Count; i++)
                {
                    tbody.AppendFormat("<td>{0}</td>", dr[i].ToString());
                }

                tbody.AppendFormat("<td><a href='Add.ashx'>增加</a>&nbsp;<a href='Delete.ashx?keyId={0}'>删除</a>&nbsp;<a href='Updata.ashx?keyId={0}'>修改</a>&nbsp;</td>",dr[0].ToString());

                tbody.Append("</tr>");
            }

            SqlHelper.CloseAll();

            string fileContent = File.ReadAllText(filePath).Replace("$thead", thead.ToString()).Replace("$tbody", tbody.ToString());

            context.Response.Write(fileContent); ;
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