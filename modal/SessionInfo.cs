using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    public class SessionInfo : UserInfo
    {
        public string SessionId
        {
            get; set;
        }

        public string WechatSessionKey
        {
            get; set;
        }

        public string SessionKey
        {
            get; set;
        }

        public DateTime CreatedDate
        {
            get; set;
        }

        public DateTime ExpireDate
        {
            get; set;
        }
    }
}
