using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    public class OperatorInfo
    {
        public int OperatorId
        {
            get; set;
        }

        public string Name
        {
            get; set;
        }

        public string Password
        {
            get; set;
        }

        public string Mobile
        {
            get; set;
        }

        public int RoleId
        {
            get; set;
        }

        public string RoleName
        {
            get; set;
        }


        public DateTime LastLoginDate
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public int AuthValue
        {
            get; set;
        }
    }
}
