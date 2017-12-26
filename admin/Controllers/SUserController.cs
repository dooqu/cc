using callcenter.bll;
using callcenter.modal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using admin.Core;
using callcenter.modal;

namespace admin.Controllers
{
    public class SUserController : BaseController
    {
        //
        // GET: /SUser/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SUserList(SUserSCondition sus)
        {
            PagedTable result = ServiceUser.GetSUserList(sus);
            return result.ToJsonResult();
        }

        public ActionResult SUserDetail(string UserName)
        {
            var entity = ServiceUser.GetSUserByUName(UserName);
            return View(entity);
        }

        [HttpPost]
        public ActionResult SUserEditSave(ServiceUserInfo sui)
        {
            ReturnMessage messge = ServiceUser.UpdateFunction(sui);

            return Json(BuildAjaxBackResult(messge));
        }

        public ActionResult SUserAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SUserAddSave(ServiceUserInfo sui)
        {
            ReturnMessage messge = ServiceUser.AddServiceUser(sui);

            return Json(BuildAjaxBackResult(messge));
        }
        

        #region BuildAjaxBackResult:构造AJAX返回结果
        private AjaxBackResult BuildAjaxBackResult(ReturnMessage message)
        {
            AjaxBackResult result = new AjaxBackResult();
            if (message == null) return result;

            if (message.Key == EnumResultState.Success.ToString())
            {
                result.Code = 200;
            }
            result.Message = message.Message;
            return result;
        }
        #endregion
    }
}
