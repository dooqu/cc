using callcenter.dal;
using callcenter.modal;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace admin
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //创建任务单
            JobInfo ji = new JobInfo();
            ji.UserId = 123;
            ji.UserName = "sunjian";
            ji.IdentityCard = "1223343434545";
            ji.MobilePhone = "13693665974";
            ji.ChannelCustomer = "渠道测试" + DateTime.Now.ToString();
            ji.CustomerRemark = "客服备注" + DateTime.Now.ToString();
            ji.Status = 0;
            ji.ErrorMessage = "";
            ji.Operation = 0;
            ji.OperationDateTime = DateTime.Now;
            ji.CreateDateTime = DateTime.Now;

            //结清
            ji.JobType = 0;
            ji.Area = "地区";
            ji.Address = "燕郊公园";
            ji.ExpressNumber = "1221212";
            ji.DueBillNumber = "4343434";

            int result = DataProvider.AddJobInfo(ji);
            //修改图片1,2,3,4,5
            DataProvider.UpdateJobInfoImage(result, 1, "Image1结清");
            DataProvider.UpdateJobInfoImage(result, 2, "Image1结清");
            DataProvider.UpdateJobInfoImage(result, 2, "Image2结清");
            DataProvider.UpdateJobInfoImage(result, 3, "Image3结清");
            DataProvider.UpdateJobInfoImage(result, 4, "Image4结清");
            DataProvider.UpdateJobInfoImage(result, 5, "Image5结清");


            //手机变更
            ji.Area = null;
            ji.Address = null;
            ji.ExpressNumber = null;
            ji.DueBillNumber = null;
            ji.JobType = 1;
            ji.MobileChangeType = 0;
            ji.MobilePhoneOld = "13800000000";
            ji.MobilePhoneNew = "13700000000";
            result = DataProvider.AddJobInfo(ji);
            //修改图片1,2,3,4,5
            DataProvider.UpdateJobInfoImage(result, 1, "Image1手机号变更");
            DataProvider.UpdateJobInfoImage(result, 2, "Image1手机号变更");
            DataProvider.UpdateJobInfoImage(result, 2, "Image2手机号变更");
            DataProvider.UpdateJobInfoImage(result, 3, "Image3手机号变更");
            DataProvider.UpdateJobInfoImage(result, 4, "Image4手机号变更");
            DataProvider.UpdateJobInfoImage(result, 5, "Image5手机号变更");

            //银行卡变更
            ji.MobileChangeType = 0;
            ji.MobilePhoneOld = null;
            ji.MobilePhoneNew = null;
            ji.JobType = 2;
            ji.OldBankcard = "00000000000000";
            ji.NewBankcard = "11111111111111";
            result = DataProvider.AddJobInfo(ji);
            //修改图片1,2,3,4,5
            DataProvider.UpdateJobInfoImage(result, 1, "Image1银行卡变更");
            DataProvider.UpdateJobInfoImage(result, 2, "Image1银行卡变更");
            DataProvider.UpdateJobInfoImage(result, 2, "Image2银行卡变更");
            DataProvider.UpdateJobInfoImage(result, 3, "Image3银行卡变更");
            DataProvider.UpdateJobInfoImage(result, 4, "Image4银行卡变更");
            DataProvider.UpdateJobInfoImage(result, 5, "Image5银行卡变更");

            //征信
            ji.OldBankcard = null;
            ji.NewBankcard = null;
            ji.JobType = 3;
            result = DataProvider.AddJobInfo(ji);

            //修改图片1,2,3,4,5
            DataProvider.UpdateJobInfoImage(result, 1, "Image1征信");
            DataProvider.UpdateJobInfoImage(result, 2, "Image1征信");
            DataProvider.UpdateJobInfoImage(result, 2, "Image2征信");
            DataProvider.UpdateJobInfoImage(result, 3, "Image3征信");
            DataProvider.UpdateJobInfoImage(result, 4, "Image4征信");
            DataProvider.UpdateJobInfoImage(result, 5, "Image5征信");

            //list
            List<JobInfo> jList = new List<JobInfo>();
            jList = DataProvider.GetJobInfoList(ji);

            Application.Run(new Clearance());
        }
    }
}
