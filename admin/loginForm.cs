using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using callcenter.dal;
using callcenter.modal;

namespace admin
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();

            // //添加 结清
            //Job_ClearanceInfo cf = new Job_ClearanceInfo();
            //cf.UserName = "sunjian";
            //cf.MobilePhone = "13693665974";
            //cf.ChannelCustomer = "申请结清ChannelCustomer";
            //cf.Address = "Address";
            //cf.Date = "2017-12-9";
            //cf.Time = "17:03:55";
            //cf.ApplicationDate = DateTime.Now;
            //cf.ExpressDate = DateTime.Now;
            //cf.ExpressNumber = "123456789";
            //cf.DueBillNumber = "0123456789";
            //cf.Status = 0;
            //cf.Operation = 1;
            //cf.OperationDateTime = DateTime.Now;
            //cf.CreateDateTime = DateTime.Now;
            //cf.IsDelete = 0;
            //DataProvider.Add_Job_Clearance(cf);
            /////
            //Job_MobileChangeInfo mf = new Job_MobileChangeInfo();
            //mf.UserName = "sunjian";
            //mf.MobilePhone = "13693665974";
            //mf.MobilePhoneNew = "1369147366";
            //mf.ChannelCustomer = "手机变更ChannelCustomer";
            //mf.ApplicationDate = DateTime.Now;
            //mf.CustomerRemark = "手机变更备注";
            //mf.ExpressDate = DateTime.Now;
            //mf.Status = 0;
            //mf.Operation = 1;
            //mf.OperationDateTime = DateTime.Now;
            //mf.CreateDateTime = DateTime.Now;
            //mf.IsDelete = 0;
            //DataProvider.Add_Job_MobileChange(mf);

            //Jod_BankcardChangeInfo bf = new Jod_BankcardChangeInfo();
            //bf.UserName = "fanyihua";
            //bf.MobilePhone = "138983998987";
            //bf.ChannelCustomer = "变更银行卡渠道";
            //bf.ApplicationDate = DateTime.Now;
            //bf.IdentityCard = "0123456789";
            //bf.OldBankcard = "1234567890";
            //bf.NewBankcard = "019992882828888";
            //bf.CustomerRemark = "变更银行卡备注";
            //bf.Status = 0;
            //bf.Operation = 1;
            //bf.OperationDateTime = DateTime.Now;
            //bf.CreateDateTime = DateTime.Now;
            //bf.IsDelete = 0;
            //DataProvider.Add_Job_BankcardChange(bf);

            //Job_AddMessageInfo af = new Job_AddMessageInfo();
            //af.UserName = "fanyihua";
            //af.MobilePhone = "137898988484893";
            //af.ChannelCustomer = "渠道";
            //af.IdentityCard = "380830830928454";
            //af.CustomerRemark = "增信备注";
            //af.Status = 0;
            //af.Operation = 1;
            //af.OperationDateTime = DateTime.Now;
            //af.CreateDateTime = DateTime.Now;
            //af.IsDelete = 0;
            //DataProvider.Add_Job_AddMessage(af);

            //Job_OtherMessageInfo of = new Job_OtherMessageInfo();
            //of.UserName = "sunjian";
            //of.MobilePhone = "136888989898";
            //of.ChannelCustomer = "渠道";
            //of.CustomerRemark = "备注";
            //of.Status = 0;
            //of.Operation = 1;
            //of.OperationDateTime = DateTime.Now;
            //of.CreateDateTime = DateTime.Now;
            //of.IsDelete = 0;
            //DataProvider.Add_Job_OtherMessage(of);

            //Job_AttachmentInfo atI = new Job_AttachmentInfo();
            //atI.FileName = "filename";
            //atI.FilePath = "filepath";
            //atI.FileType = 1;
            //atI.JobId = 1;
            //atI.JobType = 1;
            //atI.IsDelete = 0;
            //atI.CreateDateTime = DateTime.Now;
            //DataProvider.Add_Job_Attachment(atI);

            ////update
            //cf.ID = 30;
            //cf.Status = 1;
            //DataProvider.Update_Job_Clearance(cf);
            //mf.ID = 29;
            //mf.Status = 1;
            //DataProvider.Update_Job_MobileChange(mf);
            //bf.ID = 29;
            //bf.Status = 1;
            //DataProvider.Update_Job_BankcardChange(bf);
            //af.ID = 33;
            //af.Status = 1;
            //DataProvider.Update_Job_AddMessage(af);
            //of.ID = 29;
            //of.Status = 1;
            //DataProvider.Update_Job_OtherMessage(of);

            
            //List<Job_ClearanceInfo> cInfoList = new List<Job_ClearanceInfo>();
            //cInfoList = DataProvider.GetJob_ClearanceById();

            //List<Job_MobileChangeInfo> mInfoList = new List<Job_MobileChangeInfo>();
            //mInfoList = DataProvider.GetJob_MobileChangeById();

            //List<Jod_BankcardChangeInfo> bInfoList = new List<Jod_BankcardChangeInfo>();
            //bInfoList = DataProvider.GetJod_BankcardChangeById();

            //List<Job_AddMessageInfo> aInfoList = new List<Job_AddMessageInfo>();
            //aInfoList = DataProvider.Get_Job_AddMessageById();

            //List<Job_OtherMessageInfo> oInfoList = new List<Job_OtherMessageInfo>();
            //oInfoList = DataProvider.Get_Job_OtherMessageById();

            //List<Job_AttachmentInfo> jaInfoList = new List<Job_AttachmentInfo>();
            //jaInfoList = DataProvider.Get_Job_AttachmentById(1,1,1);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form mForm = new mainForm();
            this.Hide();
            mForm.ShowDialog();
            this.Close();
            this.Dispose();
            
        }
    }
}
