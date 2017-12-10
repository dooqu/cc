using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 附件 实体类
    /// </summary>
    public class Job_AttachmentInfo
    {
        public int ID { get; set; }
        //文件名称
        public string FileName { get; set; }
        //文件路径
        public string FilePath { get; set; }
        //文件类型(0 默认 1 身份证正面 2身份证反面)
        public int FileType { get; set; }
        //任务单类型(0 申请结清证明、1 手机号换保 2 变更银行卡 3 增信 4 其它信息)
        public int JobType { get; set; }
        //任务单ID
        public int JobId { get; set; }
        //添加时间
        public DateTime CreateDateTime { get; set; }
        public int IsDelete { get; set; }
    }
}
