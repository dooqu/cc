using admin.HttpWebRequest;
using callcenter.dal;
using callcenter.modal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace admin
{
    public partial class Clearance : Form
    {
        public Clearance()
        {
            InitializeComponent();

            //List<Job_ClearanceInfo> cInfoList = new List<Job_ClearanceInfo>();
            //cInfoList = DataProvider.GetJob_ClearanceById();

            //dataGridView1.AutoGenerateColumns = false;
            //dataGridView1.DataSource = cInfoList;

            //dataGridView1.DataSource = HttpClearance.GetClearanceInfoList();

            //List<Job_MobileChangeInfo> mInfoList = new List<Job_MobileChangeInfo>();
            //mInfoList = DataProvider.GetJob_MobileChangeById();
            //dataGridView2.DataSource = mInfoList;

            //List<Jod_BankcardChangeInfo> bInfoList = new List<Jod_BankcardChangeInfo>();
            //bInfoList = DataProvider.GetJod_BankcardChangeById();
            //dataGridView3.DataSource = bInfoList;

            //List<Job_AddMessageInfo> aInfoList = new List<Job_AddMessageInfo>();
            //aInfoList = DataProvider.Get_Job_AddMessageById();
            //dataGridView4.DataSource = aInfoList;

            //List<Job_OtherMessageInfo> oInfoList = new List<Job_OtherMessageInfo>();
            //oInfoList = DataProvider.Get_Job_OtherMessageById();
            //dataGridView5.DataSource = oInfoList;
        }
    }
}
