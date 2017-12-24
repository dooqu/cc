using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace callcenter.modal.Core
{
    /// <summary>
    /// PageListEntityQuery 列表条件查询公共继承类
    /// </summary>
    [Serializable]
    [DataContract]
    public class PageListEntityQuery
    {
        /// <summary>
        /// 当前页
        /// </summary>    
        [DataMember]
        public int Page { get; set; }

        /// <summary>
        /// 每页记录数
        /// </summary>
        [DataMember]
        public int Rows { get; set; }

        /// <summary>
        /// 排序列
        /// </summary>
        [DataMember]
        public string SIDX { get; set; }

        /// <summary>
        /// 排序方向
        /// </summary>
        [DataMember]
        public string Sord { get; set; }
    }
}
