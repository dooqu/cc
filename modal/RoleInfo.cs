using System;
using System.Collections.Generic;
using System.Text;

namespace callcenter.modal
{
    [Flags]
    public enum RoleBehavior
    {
        None = 0
    }

    public class AuthorityInfo
    {
        public int AuthorityId
        {
            get; set;
        }

        public string AuthorityName
        {
            get; set;
        }
    }


    public class RoleInfo
    {
        public string RoleName
        {
            get; set;
        }

        public int RoleId
        {
            get; set;
        }

        public int AuthValue
        {
            get; set;
        }
    }
}
