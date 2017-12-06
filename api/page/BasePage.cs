using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using callcenter.bll;

namespace callcenter.api.page
{
    public class BasePage : System.Web.UI.Page
    {
        internal OperatorInfo CurrentUser;
        protected override void OnInitComplete(EventArgs e)
        {
            base.OnInitComplete(e);

            CurrentUser = GetSessionUser();

            if (CurrentUser == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        public static OperatorInfo GetSessionUser()
        {
            return HttpContext.Current.Session["USER"] as OperatorInfo;
        }


        public string GetUsername()
        {
            if (CurrentUser == null)
                return "";

            else
                return CurrentUser.Name;
        }

        public string Username
        {
            get
            {
                return GetUsername();
            }
        }

        protected override void OnError(EventArgs e)
        {
            Response.Clear();
            Response.Write(string.Format("<pre style='font-size:14px;font-familay:arial,tahoma;border:1px solid #c0c0c0;padding:20px;'>{0}</pre> <a href='javascript:history.go(-1)'>返回</a>", Server.GetLastError().Message));
            Response.End();

            base.OnError(e);
        }

        public static bool CanUserDo(OperatorInfo userinfo, RoleBehavior behavior)
        {
            return Roles.CanOperatorDo(userinfo, behavior);
        }

        protected bool CanDo(RoleBehavior behavior)
        {
            return CanUserDo(CurrentUser, behavior);
        }
    }

}