using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 变更银行卡 实体类
    /// </summary>
    public class Jod_BankcardChangeInfo
    {
        public int ID { get; set; }
        //姓名
        public string UserName { get; set; }
        //手机号
        public string MobilePhone { get; set; }
        //客户渠道
        public string ChannelCustomer { get; set; }
        //申请日期
        public DateTime ApplicationDate { get; set; }
        //身份证号
        public string IdentityCard { get; set; }
        //旧银行卡
        public string OldBankcard { get; set; }
        //新银行卡
        public string NewBankcard { get; set; }
        //客户备注
        public string CustomerRemark { get; set; }
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
