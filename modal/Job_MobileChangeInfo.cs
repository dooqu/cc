using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 手机号换保
    /// </summary>
    public class Job_MobileChangeInfo
    {
        public int ID { get; set; }
        //姓名
        public string UserName { get; set; }
        //注册手机号
        public string MobilePhone { get; set; }
        //新手机号
        public string MobilePhoneNew { get; set; }
        //客户渠道
        public string ChannelCustomer { get; set; }
        //申请日期
        public DateTime ApplicationDate { get; set; }
        //客户备注
        public string CustomerRemark { get; set; }
        //快递日期
        public DateTime ExpressDate { get; set; }
        //状态(0待受理， 1受理，2 完成，3错误)
        public int Status { get; set; }
        //优先级(0一般、1 加急、2 紧急)
        public int Priority { get; set; }
        //处理人
        public int Operation { get; set; }
        //处理时间
        public DateTime OperationDateTime { get; set; }
        //创建时间
        public DateTime CreateDateTime { get; set; }
        //是否删除 0 否 1 是
        public int IsDelete { get; set; }
    }
}
