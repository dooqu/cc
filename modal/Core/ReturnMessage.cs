using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace callcenter.modal.Core
{
    /// <summary>
    /// 返回结果信息通用类
    /// </summary>
    [Serializable]
    [DataContract]
    public class ReturnMessage
    {
        public ReturnMessage()
        { }
        public ReturnMessage(string key, string message)
        {
            this.Key = key;
            this.Message = message;
        }

        /// <summary>
        /// 0：失败，1:成功
        /// </summary>
        [DataMember]
        public string Key { get; set; }

        /// <summary>
        /// 处理结果信息
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// 处理结果信息
        /// </summary>
        [DataMember]
        public string OtherInfo { get; set; }
    }
}
