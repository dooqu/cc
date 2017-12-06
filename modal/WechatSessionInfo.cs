using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    /// <summary>
    /// 跟踪微信小程序登录后的会话数据
    /// </summary>
    public class WechatSessionInfo
    {
        public string session_key
        {
            get; set;
        }

        public string openid
        {
            get; set;
        }

        public int expires_in
        {
            get; set;
        }

        public int errcode
        {
            get; set;
        }

        public string errmsg
        {
            get; set;
        }

        public DateTime date_created
        {
            get; set;
        }

        public DateTime date_expired
        {
            get
            {
                return date_created.AddSeconds(expires_in);
            }
        }
    }
}
