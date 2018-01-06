using System;
using System.Collections.Generic;
using System.Text;
using callcenter.modal;
using callcenter.dal;
using callcenter.modal.Core;

namespace callcenter.bll
{
    public class Jobs
    {
        public static int NewJob(JobInfo job)
        {
            return DataProvider.AddJobInfo(job);
        }

        public static int UpdateJob(int jobId, int imageType, string imgUrl)
        {
            return DataProvider.UpdateJobInfoImage(jobId, imageType, imgUrl);
        }

        public static List<JobInfo> GetJobsByUserId(int userId)
        {
            return DataProvider.GetJobsByUserId(userId);
        }

        public static JobInfo GetJobInfoById(int jobId)
        {
            return DataProvider.GetJobInfoById(jobId);
        }


        public static PagedTable GetJobsByType(JobInfo pageQuery)
        {
            string strWhere = " and IsDelete=0 and JobType=" + pageQuery.JobType;

            if (pageQuery.Status != -1)
            {
                strWhere += " and Status=" + pageQuery.Status;
            }

            if (!string.IsNullOrEmpty(pageQuery.UserName))
            {
                strWhere += " and UserName like '%" + pageQuery.UserName + "%'";
            }

            if (!string.IsNullOrEmpty(pageQuery.IdentityCard))
            {
                strWhere += " and IdentityCard like '%" + pageQuery.IdentityCard + "%'";
            }

            if (!string.IsNullOrEmpty(pageQuery.MobilePhone))
            {
                strWhere += " and MobilePhone like '%" + pageQuery.MobilePhone + "%'";
            }

            return DataProvider.GetDataByPage(strWhere, pageQuery.Page, pageQuery.Rows);
        }

        public static ReturnMessage UpdateJobStatus(int JobId, int status, string errMsg, string imageName, int UserId, string ExpressNumber, string DueBillNumber, string HandleMessage)
        {
            int result = DataProvider.UpdateJobStatus(JobId, status, errMsg, imageName, UserId, ExpressNumber, DueBillNumber, HandleMessage);

            if (result > 0)
            {
                return new ReturnMessage(EnumResultState.Success.ToString(), "处理成功");
            }
            else
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败");
            }
        }
    }
}
