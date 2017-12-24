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


        public static PagedTable GetJobsByType(SearchCondition pageQuery)
        {
            string strWhere = " and JobType=" + pageQuery.JobType;

            if (pageQuery.Status != -1)
            {
                strWhere += " and Status=" + pageQuery.Status;
            }

            return DataProvider.GetDataByPage(strWhere, pageQuery.Page, pageQuery.Rows);
        }

        public static ReturnMessage UpdateJobStatus(int JobId, int status, string errMsg, string imageName, int UserId, string ExpressNumber, string DueBillNumber)
        {
            int result = DataProvider.UpdateJobStatus(JobId, status, errMsg, imageName, UserId,ExpressNumber,DueBillNumber);

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
