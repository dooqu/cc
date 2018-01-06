using callcenter.modal.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace admin.Core
{
    public static class PagedResultExtension
    {
        /// <summary>
        /// 将PagedTable的数据转化为JsonResult.
        /// </summary>
        /// <param name="data">按DataTable的分页数据</param>
        /// <returns>JsonResult对象</returns>
        public static JsonResult ToJsonResult(this PagedTable data)
        {
            JsonResult result = new TextJsonResult();

            StringBuilder sbJson = new StringBuilder();
            StringBuilder sbRows = new StringBuilder();
            sbRows.Append("[");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            foreach (DataRow row in data.Table.Rows)
            {
                sbRows.Append("{");
                foreach (DataColumn column in data.Table.Columns)
                {
                    sbRows.AppendFormat("\"{0}\":{1},", column.ColumnName, serializer.Serialize(row[column]));
                }
                sbRows.TrimEnd(',');
                sbRows.Append("},");
            }
            sbRows.TrimEnd(',');
            sbRows.Append("]");

            sbJson.AppendFormat("{{\"page\":{0},\"total\":{1},\"records\":{2},\"rows\":{3}}}",
                data.CurrentPageIndex,
                data.TotalPageCount,
                data.TotalItemCount,
                sbRows);

            result.Data = sbJson;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return result;
        }

        /// <summary>
        /// 将Table的数据转化为JsonResult.
        /// </summary>
        /// <param name="data">按DataTable的分页数据</param>
        /// <returns>JsonResult对象</returns>
        public static JsonResult ToJsonResultTable(this DataSet data)
        {
            JsonResult result = new TextJsonResult();

            StringBuilder sbJson = new StringBuilder();
            StringBuilder sbRows = new StringBuilder();
            sbRows.Append("[");
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                sbRows.Append("{");
                foreach (DataColumn column in data.Tables[0].Columns)
                {
                    sbRows.AppendFormat("\"{0}\":{1},", column.ColumnName, serializer.Serialize(row[column]));
                }
                sbRows.TrimEnd(',');
                sbRows.Append("},");
            }
            sbRows.TrimEnd(',');
            sbRows.Append("]");

            sbJson.AppendFormat("{{\"rows\":{0}}}",sbRows);

            result.Data = sbJson;
            result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return result;
        }
    }
}