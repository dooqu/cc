using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace callcenter.modal.Core
{
    public class SUserSCondition : PageListEntityQuery
    {
        /// <summary>
        /// 登录账号
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
    }
}
