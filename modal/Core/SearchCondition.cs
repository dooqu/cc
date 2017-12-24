using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace callcenter.modal.Core
{
    public class SearchCondition : PageListEntityQuery
    {
        [DataMember]
        public int Id { get; set; }
        //任务单类型(0 贷款结清证明申请表、1 手机号变更申请表 2 银行卡变更申请表 3 征信信息核实申请表 4 其它信息)
        [DataMember]
        public int JobType { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        //身份证号
        [DataMember]
        public string IdentityCard { get; set; }
        //手机号
        [DataMember]
        public string MobilePhone { get; set; }
        //状态(0 受理中，1 处理完毕、3 错误)
        [DataMember]
        public int Status { get; set; }
    }
}
