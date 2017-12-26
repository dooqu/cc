using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Data;
using callcenter.modal;
using callcenter.modal.Core;


namespace callcenter.dal
{
    public class DataProvider
    {
        #region Session
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
        #endregion

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

        /// <summary>
        /// 处理任务单状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status">处理状态</param>
        /// <param name="errMsg">错误信息</param>
        /// <param name="imageName">贷款结清申请电子版</param>
        public static int UpdateJobStatus(int JobId, int status, string errMsg, string imageName, int UserId, string ExpressNumber, string DueBillNumber)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "UpdateJobStatus",
                new SqlParameter("@JobId", JobId),
                new SqlParameter("@UserId", UserId),
                new SqlParameter("@Status", status),
                new SqlParameter("@errMsg", errMsg),
                new SqlParameter("@ExpressNumber", ExpressNumber),
                new SqlParameter("@DueBillNumber", DueBillNumber),
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
        /// <summary>
        /// 获取工单列列根据工单类型
        /// </summary>
        /// <param name="jobType"></param>
        /// <returns></returns>
        public static List<JobInfo> GetJobsByType(int jobType)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJobsByType",
                new SqlParameter("@jobType", jobType));

            List<JobInfo> cInfoList = new List<JobInfo>();
            while (reader.Read())
            {
                JobInfo job = new JobInfo();
                ReadJobInfo(job, reader);
                cInfoList.Add(job);
            }
            return cInfoList;
        }

        /// <summary>
        /// 功能：查询分页数据
        /// 日期：2017-12-19
        /// </summary>
        /// <param name="sqlStr">查询SQL</param>
        /// <param name="pi">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="parList">参数类型</param>
        /// <returns></returns>
        public static PagedTable GetDataByPage(string strWhere, int pi, int pageSize)
        {
            int RowTotal=0;

            SqlParameter[] sp=new SqlParameter[4];
            sp[0] = new SqlParameter("@PageSize", pageSize);
            sp[1] = new SqlParameter("@PageIndex", pi);
            SqlParameter spara = new SqlParameter("@TotalCount", RowTotal);
            spara.Direction = ParameterDirection.Output;
            sp[2] = spara;
            sp[3] = new SqlParameter("@strWhere", strWhere);
            
            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJobsByType", sp);
            RowTotal = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            PagedTable pt = new PagedTable(ds.Tables[0], pi, pageSize, RowTotal);
            return pt;
        }
        #endregion

        #region Ad
        public static int NewAd(string imagePath)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "NewAd", new SqlParameter("@ImagePath", imagePath)))
            {
                if (reader.Read())
                {
                    return Convert.ToInt32(reader["AdId"]);
                }
                return 0;
            }
        }

        public static void DeleteAd(int adid)
        {
            SqlHelper.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "DeleteAd", new SqlParameter("@AdId", adid));
        }

        public static List<AdInfo> GetAds()
        {
            List<AdInfo> ads = new List<AdInfo>();

            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetAds"))
            {
                while (reader.Read())
                {
                    AdInfo ai = new AdInfo();
                    ai.AdId = Convert.ToInt32(reader["AdId"]);
                    ai.ImagePath = Convert.ToString(reader["ImagePath"]);

                    ads.Add(ai);
                }
            }

            return ads;
        }

        public static AdInfo GetAdInfoById(int adid)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetAdInfoById", new SqlParameter("@AdId", adid)))
            {
                if (reader.Read())
                {
                    AdInfo ai = new AdInfo();
                    ai.AdId = Convert.ToInt32(reader["AdId"]);
                    ai.ImagePath = Convert.ToString(reader["ImagePath"]);
                    return ai;
                }
                return null;
            }
        }

        #endregion

        #region ServiceUser
        /// <summary>
        /// 添加客服账号
        /// </summary>
        /// <param name="sui"></param>
        /// <returns></returns>
        public static int AddServiceUser(ServiceUserInfo sui)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "AddServiceUser",
                new SqlParameter("@UserName", sui.UserName),
                new SqlParameter("@PassWord", sui.PassWord),
                new SqlParameter("@Function1", sui.Function1),
                new SqlParameter("@Function2", sui.Function2),
                new SqlParameter("@Function3", sui.Function3),
                new SqlParameter("@Function4", sui.Function4),
                new SqlParameter("@Function5", sui.Function5),
                new SqlParameter("@Function6", sui.Function6)));

        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="NewPassWord"></param>
        /// <returns></returns>
        public static int UpdatePwd(int Id, string NewPassWord)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "UpdatePwd",
                new SqlParameter("@ID", Id),
                new SqlParameter("@PassWord", NewPassWord)));
        }
        /// <summary>
        /// 更新客服权限
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="NewPassWord"></param>
        /// <returns></returns>
        public static int UpdateFunction(ServiceUserInfo sui)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "UpdateFunction",
                new SqlParameter("@ID", sui.ID),
                new SqlParameter("@PassWord", sui.PassWord),
                new SqlParameter("@Function1", sui.Function1),
                new SqlParameter("@Function2", sui.Function2),
                new SqlParameter("@Function3", sui.Function3),
                new SqlParameter("@Function4", sui.Function4),
                new SqlParameter("@Function5", sui.Function5),
                new SqlParameter("@Function6", sui.Function6)
                ));
        }

        public static ServiceUserInfo GetSUserByUName(string UserName)
        {
            using (SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetSUserByName",
    new SqlParameter("@UserName", UserName)))
            {
                if (reader.Read())
                {
                    ServiceUserInfo sui = new ServiceUserInfo();
                    ReadServiceUserInfo(sui, reader);
                    return sui;
                }
            }

            return null;
        }

        public static void ReadServiceUserInfo(ServiceUserInfo sui, SqlDataReader reader)
        {
            sui.ID = Convert.ToInt32(reader["ID"]);
            sui.UserName = Convert.ToString(reader["UserName"]);
            sui.PassWord = Convert.ToString(reader["PassWord"]);
            sui.Function1 = Convert.ToBoolean(reader["Function1"]);
            sui.Function2 = Convert.ToBoolean(reader["Function2"]);
            sui.Function3 = Convert.ToBoolean(reader["Function3"]);
            sui.Function4 = Convert.ToBoolean(reader["Function4"]);
            sui.Function5 = Convert.ToBoolean(reader["Function5"]);
            sui.Function6 = Convert.ToBoolean(reader["Function6"]);
            sui.Status = Convert.ToInt32(reader["Status"]);
            sui.CreateTime = Convert.ToDateTime(reader["CreateTime"]);
            sui.IsDelete = Convert.ToInt32(reader["IsDelete"]);
        }

        /// <summary>
        /// 功能：查询分页数据
        /// 日期：2017-12-19
        /// </summary>
        /// <param name="sqlStr">查询SQL</param>
        /// <param name="pi">页码</param>
        /// <param name="pageSize">每页显示条数</param>
        /// <param name="parList">参数类型</param>
        /// <returns></returns>
        public static PagedTable GetSUserList(string strWhere, int pi, int pageSize)
        {
            int RowTotal = 0;

            SqlParameter[] sp = new SqlParameter[4];
            sp[0] = new SqlParameter("@PageSize", pageSize);
            sp[1] = new SqlParameter("@PageIndex", pi);
            SqlParameter spara = new SqlParameter("@TotalCount", RowTotal);
            spara.Direction = ParameterDirection.Output;
            sp[2] = spara;
            sp[3] = new SqlParameter("@strWhere", strWhere);

            DataSet ds = SqlHelper.ExecuteDataset(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetSUserList", sp);
            RowTotal = Convert.ToInt32(ds.Tables[1].Rows[0][0]);
            PagedTable pt = new PagedTable(ds.Tables[0], pi, pageSize, RowTotal);
            return pt;
        }

        #endregion

    }
}
