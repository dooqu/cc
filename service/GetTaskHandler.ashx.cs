using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;

namespace callcenter.service
{
    /// <summary>
    /// GetTaskHandler 的摘要说明
    /// </summary>
    public class GetTaskHandler : baseHandler.WechatServiceHandler
    {
        public class ListStringResponseInfo : ResponseInfo
        {
            List<string> ss;
        }
        
        public override ResponseInfo OnLoad(HttpContext context)
        {
      
        }
    }
}