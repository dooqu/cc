using callcenter.dal;
using callcenter.modal;
using callcenter.modal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace callcenter.bll
{
    public class ServiceUser
    {
        public static ReturnMessage AddServiceUser(ServiceUserInfo sui)
        {
            if(string.IsNullOrEmpty(sui.UserName.Trim())||string.IsNullOrEmpty(sui.PassWord.Trim()))
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "账号、密码不能为空！");
            }

            int result = DataProvider.AddServiceUser(sui);

            if (result > 0)
            {
                return new ReturnMessage(EnumResultState.Success.ToString(), "添加成功");
            }
            else
            {
                if (result == -2)
                {
                    return new ReturnMessage(EnumResultState.Failing.ToString(), "账号已经存在");
                }

                return new ReturnMessage(EnumResultState.Failing.ToString(), "添加失败");
            }
        }

        public static ReturnMessage UpdatePwd(int Id, string NewPassWord)
        {
            int result = DataProvider.UpdatePwd(Id, NewPassWord);

            if (result > 0)
            {
                return new ReturnMessage(EnumResultState.Success.ToString(), "处理成功");
            }
            else
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败");
            }
        }

        public static ReturnMessage UpdateFunction(ServiceUserInfo sui)
        {
            if (string.IsNullOrEmpty(sui.PassWord.Trim()))
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "密码不能为空！");
            }
            int result =  DataProvider.UpdateFunction(sui);

            if (result > 0)
            {
                return new ReturnMessage(EnumResultState.Success.ToString(), "处理成功");
            }
            else
            {
                return new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败");
            }
        }

        public static ServiceUserInfo GetSUserByUName(string UserName)
        {
            return DataProvider.GetSUserByUName(UserName);
        }

        public static PagedTable GetSUserList(SUserSCondition pageQuery)
        {
            string strWhere = "";
            return DataProvider.GetSUserList(strWhere, pageQuery.Page, pageQuery.Rows);
        }
    }
}
