using System;
using System.Collections.Generic;
using System.Text;
using callcenter.modal;
using callcenter.dal;

namespace callcenter.bll
{
    public class SessionManager
    {
        public SessionManager()
        {
            sessionLock = new object();
            sessions = new Dictionary<string, SessionInfo>();
        }

        protected static SessionManager current;
        protected Dictionary<string, SessionInfo> sessions;
        protected object sessionLock;

        public static SessionManager Current
        {
            get
            {
                if (current == null)
                {
                    current = new SessionManager();
                }
                return current;
            }
        }

        public SessionInfo CreateSessionInfo(string wechatSessionKey, string wechatOpenId)
        {
            SessionInfo si = new SessionInfo();
            si.WechatSessionKey = wechatSessionKey;
            si.OpenID = wechatOpenId;
            si.SessionKey = Guid.NewGuid().ToString();
            si.CreatedDate = DateTime.Now;
            si.ExpireDate = si.CreatedDate.AddSeconds(7200);

            int userId = DataProvider.NewSession(si); 
            if (userId > 0)
            {
                si.UserId = userId;
                lock (this.sessionLock)
                {
                    this.sessions[si.SessionKey] = si;
                }
                return si;
            }
            return null;
        }

        public SessionInfo GetSessionInfoById(string sessionId)
        {
            lock (this.sessionLock)
            {
                if (this.sessions.ContainsKey(sessionId))
                {
                    return this.sessions[sessionId];
                }

                SessionInfo si = DataProvider.GetSessionInfoById(sessionId);

                if (si != null)
                {
                    this.sessions[sessionId] = si;
                    return si;
                }

                return null;
            }
        }
    }
}
