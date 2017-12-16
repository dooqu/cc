using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using callcenter.bll;

namespace callcenter.service
{
    /// <summary>
    /// GetMyJobs 的摘要说明
    /// </summary>
    public class GetMyJobs : baseHandler.WechatServiceHandler
    {
        public class MyJobsResponseInfo : ResponseInfo
        {
            public List<JobInfo> MyJobs
            {
                get;set;
            }
        }
        public override ResponseInfo OnLoad(HttpContext context)
        {
            if(CurrentSession == null)
            {
                return new ResponseInfo(true, "登录状态已经过期");
            }
            MyJobsResponseInfo res = new MyJobsResponseInfo();

            res.MyJobs = Jobs.GetJobsByUserId(CurrentSession.UserId);

            return res;

        }
    }
}