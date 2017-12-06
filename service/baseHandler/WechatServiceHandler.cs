using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using Newtonsoft;
using Newtonsoft.Json;

namespace callcenter.service.baseHandler
{
    public abstract class WechatServiceHandler : IHttpHandler
    {
        /// <summary>
        /// 您将需要在网站的 Web.config 文件中配置此处理程序 
        /// 并向 IIS 注册它，然后才能使用它。有关详细信息，
        /// 请参见下面的链接: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // 如果无法为其他请求重用托管处理程序，则返回 false。
            // 如果按请求保留某些状态信息，则通常这将为 false。
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (string.IsNullOrEmpty(context.Request.Params["sessionid"]) == false)
                {
                    string sessionid = context.Request.Params["sessionid"];
                    SessionInfo si = bll.SessionManager.Current.GetSessionInfoById(sessionid);

                    if (si != null)
                    {
                        this.CurrentSession = si;
                    }
                }
                ResponseInfo ri = this.OnLoad(context);
                ResponseMessage(ri);
            }
            catch (Exception ex)
            {
                this.OnError(ex);
            }
        }

        public abstract ResponseInfo OnLoad(HttpContext context);

        public virtual void OnError(Exception ex)
        {
            ResponseMessage(new ResponseInfo(true, ex.Message));
        }

        internal void ResponseMessage(ResponseInfo ri)
        {
            HttpContext.Current.Response.Clear();
            if (ri != null)
            {
                HttpContext.Current.Response.Write(JsonConvert.SerializeObject(ri));
            }
        }

        protected SessionInfo CurrentSession
        {
            get;
            set;
        }

        protected bool CheckRequestParams(HttpContext context, params string[] ps)
        {
            for (int i = 0; i < ps.Length; i++)
            {
                if (String.IsNullOrEmpty(context.Request.Params[ps[i]]))
                {
                    return false;
                }
            }
            return true;
        }

        public string GetParam(string key)
        {
            return HttpContext.Current.Request.Params[key];
        }

        #endregion
    }
}