using admin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace admin.Controllers
{
    public class VerificationController : Controller
    {
        /// <summary>
        /// 系统登录页面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            this.Session.Clear();
            FormsAuthentication.SignOut();
            return View();
        }

        [HttpPost]
        public string Index(LoginModel model)
        {

            if (model.LoginName!="fanyihua")
            {
                return "用户名错误";
            }
            else if (model.Password!="123")
            {
                return "密码错误";
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.LoginName, true);

                this.Session["User"] = model;
                this.Session["UserName"] = model.LoginName;

                string ReturnUrl = this.HttpContext.Request.UrlReferrer == null ? string.Empty : Server.UrlDecode(System.Text.RegularExpressions.Regex.Match(this.HttpContext.Request.UrlReferrer.Query, @"ReturnUrl=([^&]*)?").Groups[1].ToString()) == "/" ? string.Empty : Server.UrlDecode(System.Text.RegularExpressions.Regex.Match(this.HttpContext.Request.UrlReferrer.Query, @"ReturnUrl=([^&]*)?").Groups[1].ToString());

                //this.HttpContext.Request.
                return "登陆成功" + "|" + (string.IsNullOrEmpty(ReturnUrl) ? ReturnUrl : "http://" + this.HttpContext.Request.Url.Host + ":" + this.HttpContext.Request.Url.Port + ReturnUrl);
            }
        }

    }
}
