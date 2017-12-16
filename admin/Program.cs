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
            ji.Image1 = "Image1";

            int result = DataProvider.AddJobInfo(ji);
            //修改图片1,2,3,4,5
            DataProvider.UpdateJobInfoImage(result, 2, "Image2");
            DataProvider.UpdateJobInfoImage(result, 3, "Image3");
            DataProvider.UpdateJobInfoImage(result, 4, "Image4");
            DataProvider.UpdateJobInfoImage(result, 5, "Image5");

            
            ji.ID = result;
            ji.UserId = 123;
            ji.JobType = 0;
            ji.UserName = "sunjian";
            ji.IdentityCard = "1223343434545";
            ji.MobilePhone = "13693665974";
            ji.ChannelCustomer = "渠道测试" + DateTime.Now.ToString() ;
            ji.CustomerRemark = "客服备注" + DateTime.Now.ToString();
            ji.CreateDateTime = DateTime.Now;

            //结清
            ji.Area = "地区";
            ji.Address = "燕郊公园";
            ji.ExpressNumber = "1221212";
            ji.DueBillNumber = "4343434";

            DataProvider.UpdateJobInfo(ji);

            //手机变更
            ji.JobType = 1;
            ji.MobileChangeType = 0;
            ji.MobilePhoneOld = "13800000000";
            ji.MobilePhoneNew = "13700000000";
            DataProvider.UpdateJobInfo(ji);

            //银行卡变更
            ji.JobType = 2;
            ji.OldBankcard = "00000000000000";
            ji.NewBankcard = "11111111111111";
            DataProvider.UpdateJobInfo(ji);

            //征信
            ji.JobType = 3;
            DataProvider.UpdateJobInfo(ji);

            Application.Run(new Clearance());
        }
    }
}
