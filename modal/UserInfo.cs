using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    public class UserInfo
    {
        public int UserId
        {
            get; set;
        }

        public string OpenID
        {
            get; set;
        }

        public DateTime DateCreated
        {
            get; set;
        }

        public DateTime DateActived
        {
            get;set;
        }
    }
}
