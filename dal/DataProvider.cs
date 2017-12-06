using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using callcenter.modal;



namespace callcenter.dal
{
    public class DataProvider
    {

        public static int NewSession(SessionInfo si)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "NewSession",
                new SqlParameter("@SessionId", new Guid(si.SessionKey)),
                new SqlParameter("@WechatSessionKey", si.WechatSessionKey),
                new SqlParameter("@WechatOpenId", si.OpenID),
                new SqlParameter("@DateCreated", si.CreatedDate),
                new SqlParameter("@DateExpired", si.ExpireDate)));
        }

        public static SessionInfo GetSessionInfoById(string sessionId)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetSessionInfoById",
                new SqlParameter("@SessionId", new Guid(sessionId)));

            if (reader.Read())
            {
                SessionInfo si = new SessionInfo();
                si.UserId = Convert.ToInt32(reader["UserId"]);
                si.SessionKey = Convert.ToString(reader["SessionId"]);
                si.WechatSessionKey = Convert.ToString(reader["WechatSessionKey"]);
                si.OpenID = Convert.ToString(reader["WechatOpenId"]);
                si.CreatedDate = Convert.ToDateTime(reader["DateCreated"]);
                si.ExpireDate = Convert.ToDateTime(reader["DateExpired"]);

                return si;
            }
            return null;
        }
    }
}
