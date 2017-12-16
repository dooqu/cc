using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 增信 实体类
    /// </summary>
    public class Job_AddMessageInfo : JobInfo
    {
        public List<UserPicInfo> ImageAttchments
        {
            get;set;
        }
    }
}
