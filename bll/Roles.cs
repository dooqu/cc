using System;
using System.Collections.Generic;
using System.Text;
using callcenter.modal;
using System.Configuration;

namespace callcenter.bll
{
    public class Roles
    {
        public static bool CanOperatorDo(OperatorInfo oi, RoleBehavior behavior)
        {
            if (oi == null)
                return false;

            if (String.IsNullOrEmpty(ConfigurationManager.AppSettings.Get("rootUser")) == false && oi.Name.Trim().ToString() == System.Configuration.ConfigurationManager.AppSettings.Get("rootUser"))
            {
                return true;
            }

            return ((oi.AuthValue & (int)behavior) > 0);
        }
    }
}
