using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 申请结清证明 实体类
    /// </summary>
    public class Job_ClearanceInfo : JobInfo
    {
        //用户省市区
        public string UserArea
        {
            get; set;
        }

        //用户邮寄的详细地址
        public string UserAddress
        {
            get; set;
        }

        //0-3张用户上传的附件图片
        public List<UserPicInfo> PicAttachments
        {
            get;set;
        }

        //快递单号
        public string CourierId
        {
            get;set;
        }
    }
}
