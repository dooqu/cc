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

        #region  Job_Clearance 申请结清证明
        public static int Add_Job_Clearance(Job_ClearanceInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Add_Job_Clearance]",
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@Address", ci.Address),
                new SqlParameter("@Date", ci.Date),
                new SqlParameter("@Time", ci.Time),
                new SqlParameter("@ApplicationDate", ci.ApplicationDate),
                new SqlParameter("@ExpressDate", ci.ExpressDate),
                new SqlParameter("@ExpressNumber", ci.ExpressNumber),
                new SqlParameter("@DueBillNumber", ci.DueBillNumber),
                new SqlParameter("@Status", ci.Status),
                new SqlParameter("@Priority", ci.Priority),
                new SqlParameter("@Operation", ci.Operation),
                new SqlParameter("@OperationDateTime", ci.OperationDateTime),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),
                new SqlParameter("@IsDelete", ci.IsDelete)));
        }

        public static int Update_Job_Clearance(Job_ClearanceInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Update_Job_Clearance]",
                new SqlParameter("@ID", ci.ID),
                new SqlParameter("@Status", ci.Status)));
        }

        public static List<Job_ClearanceInfo> GetJob_ClearanceById(int ID=0)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJob_ClearanceById",
                new SqlParameter("@ID", ID));
            List<Job_ClearanceInfo> cInfoList = new List<Job_ClearanceInfo>();
            while (reader.Read())
            {
                Job_ClearanceInfo cf = new Job_ClearanceInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.UserName = Convert.ToString(reader["UserName"]);
                cf.MobilePhone = Convert.ToString(reader["MobilePhone"]);
                cf.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
                cf.Address = Convert.ToString(reader["Address"]);
                cf.Date = Convert.ToString(reader["Date"]);
                cf.Time = Convert.ToString(reader["Time"]);
                cf.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                cf.ExpressDate = Convert.ToDateTime(reader["ExpressDate"]);
                cf.ExpressNumber = Convert.ToString(reader["ExpressNumber"]);
                cf.DueBillNumber = Convert.ToString(reader["DueBillNumber"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.Priority = Convert.ToInt32(reader["Priority"]);
                cf.Operation = Convert.ToInt32(reader["Operation"]);
                cf.OperationDateTime = Convert.ToDateTime(reader["OperationDateTime"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);

                cInfoList.Add(cf);
            }
            return cInfoList;
        }

        #endregion

        #region  Job_MobileChange 手机号换保
        public static int Add_Job_MobileChange(Job_MobileChangeInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Add_Job_MobileChange]",
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@MobilePhoneNew", ci.MobilePhoneNew),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@ApplicationDate", ci.ApplicationDate),
                new SqlParameter("@CustomerRemark", ci.ExpressDate),
                new SqlParameter("@ExpressDate", ci.ExpressDate),
                new SqlParameter("@Status", ci.Status),
                new SqlParameter("@Priority", ci.Priority),
                new SqlParameter("@Operation", ci.Operation),
                new SqlParameter("@OperationDateTime", ci.OperationDateTime),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),
                new SqlParameter("@IsDelete", ci.IsDelete)));
        }

        public static int Update_Job_MobileChange(Job_MobileChangeInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Update_Job_MobileChange]",
                new SqlParameter("@ID", ci.ID),
                new SqlParameter("@Status", ci.Status)));
        }

        public static List<Job_MobileChangeInfo> GetJob_MobileChangeById(int ID = 0)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJob_MobileChangeById",
                new SqlParameter("@ID", ID));
            List<Job_MobileChangeInfo> cInfoList = new List<Job_MobileChangeInfo>();
            while (reader.Read())
            {
                Job_MobileChangeInfo cf = new Job_MobileChangeInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.UserName = Convert.ToString(reader["UserName"]);
                cf.MobilePhone = Convert.ToString(reader["MobilePhone"]);
                cf.MobilePhoneNew = Convert.ToString(reader["MobilePhoneNew"]);
                cf.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
                cf.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                cf.CustomerRemark = Convert.ToString(reader["CustomerRemark"]);
                cf.ExpressDate = Convert.ToDateTime(reader["ExpressDate"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.Priority = Convert.ToInt32(reader["Priority"]);
                cf.Operation = Convert.ToInt32(reader["Operation"]);
                cf.OperationDateTime = Convert.ToDateTime(reader["OperationDateTime"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);

                cInfoList.Add(cf);
            }
            return cInfoList;
        }
        #endregion

        #region  Jod_BankcardChange 变更银行卡
        public static int Add_Job_BankcardChange(Jod_BankcardChangeInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Add_Job_BankcardChange]",
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@ApplicationDate", ci.ApplicationDate),
                new SqlParameter("@IdentityCard", ci.IdentityCard),
                new SqlParameter("@OldBankcard", ci.OldBankcard),
                new SqlParameter("@NewBankcard", ci.NewBankcard),
                new SqlParameter("@CustomerRemark", ci.CustomerRemark),
                new SqlParameter("@Status", ci.Status),
                new SqlParameter("@Priority", ci.Priority),
                new SqlParameter("@Operation", ci.Operation),
                new SqlParameter("@OperationDateTime", ci.OperationDateTime),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),
                new SqlParameter("@IsDelete", ci.IsDelete)));
        }

        public static int Update_Job_BankcardChange(Jod_BankcardChangeInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Update_Job_BankcardChange]",
                new SqlParameter("@ID", ci.ID),
                new SqlParameter("@Status", ci.Status)));
        }

        public static List<Jod_BankcardChangeInfo> GetJod_BankcardChangeById(int ID = 0)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJob_BankcardChangeById",
                new SqlParameter("@ID", ID));
            List<Jod_BankcardChangeInfo> cInfoList = new List<Jod_BankcardChangeInfo>();
            while (reader.Read())
            {
                Jod_BankcardChangeInfo cf = new Jod_BankcardChangeInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.UserName = Convert.ToString(reader["UserName"]);
                cf.MobilePhone = Convert.ToString(reader["MobilePhone"]);
                cf.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
                cf.ApplicationDate = Convert.ToDateTime(reader["ApplicationDate"]);
                cf.IdentityCard = Convert.ToString(reader["IdentityCard"]);
                cf.OldBankcard = Convert.ToString(reader["OldBankcard"]);
                cf.NewBankcard = Convert.ToString(reader["NewBankcard"]);
                cf.CustomerRemark = Convert.ToString(reader["CustomerRemark"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.Priority = Convert.ToInt32(reader["Priority"]);
                cf.Operation = Convert.ToInt32(reader["Operation"]);
                cf.OperationDateTime = Convert.ToDateTime(reader["OperationDateTime"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);

                cInfoList.Add(cf);
            }
            return cInfoList;
        }
        #endregion

        #region  Job_AddMessage 增信
        public static int Add_Job_AddMessage(Job_AddMessageInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Add_Job_AddMessage]",
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@IdentityCard", ci.IdentityCard),
                new SqlParameter("@CustomerRemark", ci.CustomerRemark),
                new SqlParameter("@Status", ci.Status),
                new SqlParameter("@Priority", ci.Priority),
                new SqlParameter("@Operation", ci.Operation),
                new SqlParameter("@OperationDateTime", ci.OperationDateTime),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),
                new SqlParameter("@IsDelete", ci.IsDelete)));
        }

        public static int Update_Job_AddMessage(Job_AddMessageInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Update_Job_AddMessage]",
                new SqlParameter("@ID", ci.ID),
                new SqlParameter("@Status", ci.Status)));
        }

        public static List<Job_AddMessageInfo> Get_Job_AddMessageById(int ID = 0)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJob_AddMessageById",
                new SqlParameter("@ID", ID));
            List<Job_AddMessageInfo> cInfoList = new List<Job_AddMessageInfo>();
            while (reader.Read())
            {
                Job_AddMessageInfo cf = new Job_AddMessageInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.UserName = Convert.ToString(reader["UserName"]);
                cf.MobilePhone = Convert.ToString(reader["MobilePhone"]);
                cf.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
                cf.IdentityCard = Convert.ToString(reader["IdentityCard"]);
                cf.CustomerRemark = Convert.ToString(reader["CustomerRemark"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.Priority = Convert.ToInt32(reader["Priority"]);
                cf.Operation = Convert.ToInt32(reader["Operation"]);
                cf.OperationDateTime = Convert.ToDateTime(reader["OperationDateTime"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);

                cInfoList.Add(cf);
            }
            return cInfoList;
        }
        #endregion

        #region  Job_OtherMessage 其他信息
        public static int Add_Job_OtherMessage(Job_OtherMessageInfo ci)
        {  
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Add_Job_OtherMessage]",
                new SqlParameter("@UserName", ci.UserName),
                new SqlParameter("@MobilePhone", ci.MobilePhone),
                new SqlParameter("@ChannelCustomer", ci.ChannelCustomer),
                new SqlParameter("@CustomerRemark", ci.CustomerRemark),
                new SqlParameter("@Status", ci.Status),
                new SqlParameter("@Priority", ci.Priority),
                new SqlParameter("@Operation", ci.Operation),
                new SqlParameter("@OperationDateTime", ci.OperationDateTime),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),
                new SqlParameter("@IsDelete", ci.IsDelete)));
        }

        public static int Update_Job_OtherMessage(Job_OtherMessageInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "[Update_Job_OtherMessage]",
                new SqlParameter("@ID", ci.ID),
                new SqlParameter("@Status", ci.Status)));
        }

        public static List<Job_OtherMessageInfo> Get_Job_OtherMessageById(int ID = 0)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJob_OtherMessageById",
                new SqlParameter("@ID", ID));
            List<Job_OtherMessageInfo> cInfoList = new List<Job_OtherMessageInfo>();
            while (reader.Read())
            {
                Job_OtherMessageInfo cf = new Job_OtherMessageInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.UserName = Convert.ToString(reader["UserName"]);
                cf.MobilePhone = Convert.ToString(reader["MobilePhone"]);
                cf.ChannelCustomer = Convert.ToString(reader["ChannelCustomer"]);
                cf.CustomerRemark = Convert.ToString(reader["CustomerRemark"]);
                cf.Status = Convert.ToInt32(reader["Status"]);
                cf.Priority = Convert.ToInt32(reader["Priority"]);
                cf.Operation = Convert.ToInt32(reader["Operation"]);
                cf.OperationDateTime = Convert.ToDateTime(reader["OperationDateTime"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);

                cInfoList.Add(cf);
            }
            return cInfoList;
        }
        #endregion

        #region  Job_Attachment 附件
        public static int Add_Job_Attachment(Job_AttachmentInfo ci)
        {
            return Convert.ToInt32(SqlHelper.ExecuteScalar(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "Add_Job_Attachment",
                new SqlParameter("@FileName", ci.FileName),
                new SqlParameter("@FilePath", ci.FilePath),
                new SqlParameter("@FileType", ci.FileType),
                new SqlParameter("@JobType", ci.JobType),
                new SqlParameter("@JobId", ci.JobId),
                new SqlParameter("@CreateDateTime", ci.CreateDateTime),
                new SqlParameter("@IsDelete", ci.IsDelete)));
        }


        public static List<Job_AttachmentInfo> Get_Job_AttachmentById(int JobId,int JobType=0,int FileType=0)
        {
            SqlDataReader reader = SqlHelper.ExecuteReader(ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString, "GetJob_AttachmentById",
                new SqlParameter("@JobId", JobId),
                new SqlParameter("@JobType", JobType),
                new SqlParameter("@FileType", FileType));
            List<Job_AttachmentInfo> cInfoList = new List<Job_AttachmentInfo>();
            while (reader.Read())
            {
                Job_AttachmentInfo cf = new Job_AttachmentInfo();
                cf.ID = Convert.ToInt32(reader["ID"]);
                cf.FileName = Convert.ToString(reader["FileName"]);
                cf.FilePath = Convert.ToString(reader["FilePath"]);
                cf.FileType = Convert.ToInt32(reader["FileType"]);
                cf.JobType = Convert.ToInt32(reader["JobType"]);
                cf.JobId = Convert.ToInt32(reader["JobId"]);
                cf.CreateDateTime = Convert.ToDateTime(reader["CreateDateTime"]);
                cf.IsDelete = Convert.ToInt32(reader["IsDelete"]);

                cInfoList.Add(cf);
            }
            return cInfoList;
        }
        #endregion
    }
}
