using System;
using System.Collections.Generic;
using System.Text;
using callcenter.modal;
using callcenter.dal;

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
    }
}
