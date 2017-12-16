using callcenter.dal;
using callcenter.modal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace admin.HttpWebRequest
{
    public class HttpClearance
    {
        public static List<Job_ClearanceInfo> GetClearanceInfoList()
        {
            string strURL = System.Configuration.ConfigurationManager.AppSettings["StrUrl"] + "ClearanceHandler.ashx";
            string returnStr = HttpWebRequestHelp.HttpWebRequestByPost(strURL, "");

            List<Job_ClearanceInfo> ClearanceInfoList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Job_ClearanceInfo>>(returnStr);
            return ClearanceInfoList;
        }
    }
}
