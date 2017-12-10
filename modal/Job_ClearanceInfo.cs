using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 申请结清证明 实体类
    /// </summary>
    public class Job_ClearanceInfo
    {
        public int ID { get; set; }
        //姓名
        public string UserName { get; set; }
        //手机号
        public string MobilePhone { get; set; }
        //客户渠道
        public string ChannelCustomer { get; set; }
        //地址
        public string Address { get; set; }
        //日期
        public string Date { get; set; }
        //时间
        public string Time { get; set; }
        //申请日期
        public DateTime ApplicationDate { get; set; }
        //快递日期
        public DateTime ExpressDate { get; set; }
        //快递号
        public string ExpressNumber { get; set; }
        //借据号
        public string DueBillNumber { get; set; }
        //状态(0 待受理，1 受理、2邮寄、 3错误)
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
