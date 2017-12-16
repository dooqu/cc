using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using callcenter.bll;

namespace callcenter.service
{
    /// <summary>
    /// NewJob 的摘要说明
    /// </summary>
    public class NewJob : baseHandler.WechatServiceHandler
    {
        public class NewJobResponseInfo : ResponseInfo
        {
            public int JobId
            {
                get;set;
            }

            public NewJobResponseInfo(int jobId)
            {
                this.JobId = jobId;
            }
        }
        public override ResponseInfo OnLoad(HttpContext context)
        {
            if(CurrentSession == null)
            {
                return new ResponseInfo(true, "登录状态已经过期");
            }

            if(CheckRequestParams(context, "name", "mobile", "idcard", "channel", "comment", "type") == false)
            {
                return new ResponseInfo(true, "参数不完整");
            }

            int type = 0;
            if(Int32.TryParse(GetParam("type"), out type) == false || type < 0 || type > 3)
            {
                return new ResponseInfo(true, "类型错误");
            }

            JobInfo job = new JobInfo();
            job.UserId = CurrentSession.UserId;
            job.JobType = type;

            if(type == 0)
            {
                if(CheckRequestParams(context, "area", "address") == false)
                {
                    return new ResponseInfo(true, "邮寄地址错误");
                }
                else
                {
                    job.Area = GetParam("area");
                    job.Address = GetParam("address");
                }
            }
            else if(type == 1)
            {
                int changeType = 0;
                if(CheckRequestParams(context, "changeType", "oldMobile", "newMobile") == false || Int32.TryParse(GetParam("changeType"), out changeType) == false || changeType <0 || changeType > 1)
                {
                    return new ResponseInfo(true, "手机号相关信息错误");
                }
                else
                {
                    job.MobileChangeType = changeType;
                    job.MobilePhoneOld = GetParam("oldMobile");
                    job.MobilePhoneNew = GetParam("newMobile");
                }
            }
            else if(type == 2)
            {
                if(CheckRequestParams(context, "oldCard", "newCard") == false)
                {
                    return new ResponseInfo(true, "卡号相关信息错误");
                }
                else
                {
                    job.OldBankcard = GetParam("oldCard");
                    job.NewBankcard = GetParam("newCard");
                }
            }
            else if(type == 3)
            {

            }
                        
            job.UserName = GetParam("name");
            job.MobilePhone = GetParam("mobile");
            job.IdentityCard = GetParam("idcard");
            job.ChannelCustomer = GetParam("channel");
            job.CustomerRemark = GetParam("comment");

            int jobId = Jobs.NewJob(job);

            if(jobId > 0)
            {
                return new NewJobResponseInfo(jobId);
            }
            else
            {
                return new ResponseInfo(true, "创建工单失败");
            }
        }
    }
}