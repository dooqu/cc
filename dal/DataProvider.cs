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

        #region  JobInfo
        public static int AddJobInfo(JobInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[AddJobInfo]",
                new SqlParameter("@UserId", ci.UserId),

                new SqlParameter("@Image1", ci.Image1),
                new SqlParameter("@Image2", ci.Image2),
                new SqlParameter("@Image3", ci.Image3),
                new SqlParameter("@Image4", ci.Image4),
                new SqlParameter("@Image5", ci.Image5)));
               
        }


        public static int UpdateJobInfo(JobInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[UpdateJobInfo]",
                new SqlParameter("@ID", ci.ID),
                new SqlParameter("@UserId", ci.UserId),
                new SqlParameter("@JobType", ci.JobType),
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@IdentityCard", ci.IdentityCard),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@CustomerRemark", ci.CustomerRemark),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),

                new SqlParameter("@Area", ci.Area),
                new SqlParameter("@Address", ci.Address),
                new SqlParameter("@ExpressNumber", ci.ExpressNumber),
                new SqlParameter("@DueBillNumber", ci.DueBillNumber),
                new SqlParameter("@ClearanceImage", ci.ClearanceImage),

                new SqlParameter("@MobileChangeType", ci.MobileChangeType),
                new SqlParameter("@MobilePhoneOld", ci.MobilePhoneOld),
                new SqlParameter("@MobilePhoneNew", ci.MobilePhoneNew),

                new SqlParameter("@OldBankcard", ci.OldBankcard),
                new SqlParameter("@NewBankcard", ci.NewBankcard)));
        }

        /// <summary>
        /// 更新图片附件 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="imageType">0 结算电子图片(ClearanceImage) 1 image1,2 image,3 image3,4 image4,5 image5</param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        public static int UpdateJobInfoImage(int JobId,int imageType,string imageName)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[UpdateJobInfoImage]",
                new SqlParameter("@JobId", JobId),
                new SqlParameter("@imageType", imageType),
                new SqlParameter("@imageName", imageName)));
        }

        public static List<JobInfo> GetJobInfoList(JobInfo ci)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJobInfo",
                new SqlParameter("@ID", ci.ID));

            List<JobInfo> cInfoList = new List<JobInfo>();
            while (reader.Read())
            {
                JobInfo cf = new JobInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.UserId = Convert.ToInt32(reader["UserId"]);
                cf.JobType = Convert.ToInt32(reader["JobType"]);
                cf.UserName = Convert.ToString(reader["UserName"]);
                cf.IdentityCard = Convert.ToString(reader["IdentityCard"]);
                cf.MobilePhone = Convert.ToString(reader["MobilePhone"]);
                cf.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
                cf.CustomerRemark = Convert.ToString(reader["CustomerRemark"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.ErrorMessage = Convert.ToString(reader["ErrorMessage"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.Operation = Convert.ToInt32(reader["Operation"]);
                cf.OperationDateTime = Convert.ToDateTime(reader["OperationDateTime"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);
                ci.Area=Convert.ToString(reader["Area"]);
                ci.Address = Convert.ToString(reader["Address"]);
                ci.ExpressNumber = Convert.ToString(reader["ExpressNumber"]);
                ci.DueBillNumber = Convert.ToString(reader["DueBillNumber"]);
                ci.ClearanceImage = Convert.ToString(reader["ClearanceImage"]);

                ci.MobileChangeType = Convert.ToInt32(reader["MobileChangeType"]);
                ci.MobilePhoneOld = Convert.ToString(reader["MobilePhoneOld"]);
                ci.MobilePhoneNew = Convert.ToString(reader["MobilePhoneNew"]);

                ci.OldBankcard = Convert.ToString(reader["OldBankcard"]);
                ci.NewBankcard = Convert.ToString(reader["NewBankcard"]);
                

                cInfoList.Add(cf);
            }
            return cInfoList;
        }

        #endregion
    }
}
