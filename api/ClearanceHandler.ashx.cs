using callcenter.dal;
using callcenter.modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web;

namespace callcenter.api
{
    /// <summary>
    /// CHandler 的摘要说明
    /// </summary>
    public class CHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");

            List<Job_ClearanceInfo> cInfoList = new List<Job_ClearanceInfo>();
            cInfoList = DataProvider.GetJob_ClearanceById();

            string s = JsonConvert.SerializeObject(cInfoList);
            context.Response.Write(s);
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