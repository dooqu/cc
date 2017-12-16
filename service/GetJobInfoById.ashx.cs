using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;

namespace callcenter.service
{
    /// <summary>
    /// GetJobInfoById 的摘要说明
    /// </summary>
    public class GetJobInfoById : baseHandler.WechatServiceHandler
    {
        public class JobResponseInfo : ResponseInfo
        {
            public JobInfo Job
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

            if(CheckRequestParams(context, "jobId") == false)
            {
                return new ResponseInfo(true, "jobid参数缺失");
            }

            int jobId;

            if(Int32.TryParse(GetParam("jobId"), out jobId) == false)
            {
                return new ResponseInfo(true, "jobId 错误");
            }

            JobInfo job = callcenter.bll.Jobs.GetJobInfoById(jobId);

            if(job == null || job.UserId != CurrentSession.UserId)
            {
                return new ResponseInfo(true, "工单信息未找到");
            }

            JobResponseInfo res = new JobResponseInfo();
            res.Job = job;

            return res;

        }
    }
}