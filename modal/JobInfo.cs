using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    public class JobInfo
    {
        #region 公共属性
        public int ID { get; set; }
        //UserId
        public int  UserId { get; set; }
        //任务单类型(0 贷款结清证明申请表、1 手机号变更申请表 2 银行卡变更申请表 3 征信信息核实申请表 4 其它信息)
        public int JobType { get; set; }
        //姓名
        public string UserName { get; set; }
        //身份证号
        public string IdentityCard { get; set; }
        //手机号
        public string MobilePhone { get; set; }
        //客户渠道
        public string ChannelCustomer { get; set; }
        //客户备注
        public string CustomerRemark { get; set; }
        //状态(0 受理中，1 处理完毕、2 错误)
        public int Status { get; set; }
        //错误信息
        public string ErrorMessage { get; set; }
        //处理人
        public int Operation { get; set; }
        //处理时间
        public DateTime OperationDateTime { get; set; }
        //创建时间
        public DateTime CreateDateTime { get; set; }
        //是否删除 0 否 1 是
        public int IsDelete { get; set; }
        #endregion

        #region 贷款结清证明申请表
        //地区信息
        public string Area { get; set; }
        //详细地址
        public string Address { get; set; }
        //快递号
        public string ExpressNumber { get; set; }
        //借据号 
        public string DueBillNumber { get; set; }
        //结清证明电子版 图片
        public string ClearanceImage { get; set; }
        #endregion

        #region 手机号变更申请表
        //变更类型 0 有氧金融注册手机号 1 银行卡预留手机号
        public int MobileChangeType { get; set; }
        //原手机号
        public string MobilePhoneOld { get; set; }
        //新手机号
        public string MobilePhoneNew { get; set; }
        #endregion

        #region 银行卡变更申请表
        //原银行卡
        public string OldBankcard { get; set; }
        //新银行卡
        public string NewBankcard { get; set; }
        #endregion

        #region 征信核实申请表
        #endregion

        #region 附件图片
        //图片1
        public string Image1 { get; set; }
        //图片2
        public string Image2 { get; set; }
        //图片3
        public string Image3 { get; set; }
        //图片4
        public string Image4 { get; set; }
        //图片5
        public string Image5 { get; set; }
        #endregion
    }
}
