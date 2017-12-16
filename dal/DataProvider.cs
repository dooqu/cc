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
                new SqlParameter("@JobType", ci.JobType),
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@IdentityCard", ci.IdentityCard),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@CustomerRemark", ci.CustomerRemark),


                new SqlParameter("@Area", ci.Area),
                new SqlParameter("@Address", ci.Address),


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

        public static void ReadJobInfo(JobInfo job, SqlDataReader reader)
        {
            job.ID = Convert.ToInt32(reader["ID"]);
            job.UserId = Convert.ToInt32(reader["UserId"]);
            job.JobType = Convert.ToInt32(reader["JobType"]);
            job.UserName = Convert.ToString(reader["UserName"]);
            job.IdentityCard = Convert.ToString(reader["IdentityCard"]);
            job.MobilePhone = Convert.ToString(reader["MobilePhone"]);
            job.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
            job.CustomerRemark = Convert.ToString(reader["CustomerRemark"]);
            job.Status = Convert.ToInt32(reader["Status"]);
            job.ErrorMessage = Convert.ToString(reader["ErrorMessage"]);
            job.Status = Convert.ToInt32(reader["Status"]);
            
            job.OperationDateTime = (reader["OperationDateTime"] == DBNull.Value) ? DateTime.Now : Convert.ToDateTime(reader["OperationDateTime"]);
            job.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
            job.IsDelete = Convert.ToInt32(reader["IsDelete"]);

            job.Operation = (reader["Operation"] == DBNull.Value) ? 0 : Convert.ToInt32(reader["Operation"]);
            job.Area = reader["Area"] == DBNull.Value ? "" : Convert.ToString(reader["Area"]);
            job.Address = reader["Address"] == DBNull.Value ? "" : Convert.ToString(reader["Address"]);
            job.ExpressNumber = reader["ExpressNumber"] == DBNull.Value ? "" : Convert.ToString(reader["ExpressNumber"]);
            job.DueBillNumber = reader["DueBillNumber"] == DBNull.Value ? "" : Convert.ToString(reader["DueBillNumber"]);
            //job.ClearanceImage = reader["ClearanceImage"] == DBNull.Value ? "" : Convert.ToString(reader["ClearanceImage"]);

            job.MobileChangeType = Convert.ToInt32(reader["MobileChangeType"]);
            job.MobilePhoneOld = reader["MobilePhoneOld"] == DBNull.Value ? "" : Convert.ToString(reader["MobilePhoneOld"]);
            job.MobilePhoneNew = reader["MobilePhoneNew"] == DBNull.Value ? "" : Convert.ToString(reader["MobilePhoneNew"]);

            job.OldBankcard = reader["OldBankcard"] == DBNull.Value ? "" : Convert.ToString(reader["OldBankcard"]);
            job.NewBankcard = reader["NewBankcard"] == DBNull.Value ? "" : Convert.ToString(reader["NewBankcard"]);

            job.Image1 = reader["Image1"] == DBNull.Value ? null : Convert.ToString(reader["Image1"]);
            job.Image2 = reader["Image2"] == DBNull.Value ? null : Convert.ToString(reader["Image2"]);
            job.Image3 = reader["Image3"] == DBNull.Value ? null : Convert.ToString(reader["Image3"]);
            job.Image4 = reader["Image4"] == DBNull.Value ? null : Convert.ToString(reader["Image4"]);
            job.Image5 = reader["Image5"] == DBNull.Value ? null : Convert.ToString(reader["Image5"]);

        }

        public static List<JobInfo> GetJobsByUserId(int userId)
        {
            List<JobInfo> jobs = new List<JobInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJobsByUserId",
                new SqlParameter("@UserId", userId)))
            {
                while(reader.Read())
                {
                    JobInfo job = new JobInfo();
                    ReadJobInfo(job, reader);
                    jobs.Add(job);
                }
            }

            return jobs;
        }

        public static JobInfo GetJobInfoById(int jobId)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJobInfoById",
    new SqlParameter("@JobId", jobId)))
            {
                if (reader.Read())
                {
                    JobInfo job = new JobInfo();
                    ReadJobInfo(job, reader);
                    return job;
                }
            }

            return null;
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

                ci.Area = reader["Area"] == null ? "" : Convert.ToString(reader["Area"]);
                ci.Address = reader["Address"] == null ? "" : Convert.ToString(reader["Address"]);
                ci.ExpressNumber = reader["ExpressNumber"] == null ? "" : Convert.ToString(reader["ExpressNumber"]);
                ci.DueBillNumber = reader["DueBillNumber"] == null ? "" : Convert.ToString(reader["DueBillNumber"]);
                ci.ClearanceImage = reader["ClearanceImage"] == null ? "" : Convert.ToString(reader["ClearanceImage"]);

                ci.MobileChangeType = Convert.ToInt32(reader["MobileChangeType"]);
                ci.MobilePhoneOld = reader["MobilePhoneOld"] == null ? "" : Convert.ToString(reader["MobilePhoneOld"]);
                ci.MobilePhoneNew = reader["MobilePhoneNew"] == null ? "" : Convert.ToString(reader["MobilePhoneNew"]);

                ci.OldBankcard = reader["OldBankcard"] == null ? "" : Convert.ToString(reader["OldBankcard"]);
                ci.NewBankcard = reader["NewBankcard"] == null ? "" : Convert.ToString(reader["NewBankcard"]);


                cInfoList.Add(cf);
            }
            return cInfoList;
        }

        #endregion
    }
}
