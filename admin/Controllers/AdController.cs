using callcenter.modal;
using callcenter.bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using callcenter.modal.Core;

namespace admin.Controllers
{
    public class AdController : Controller
    {
        //
        // GET: /Ad/

        public ActionResult Index()
        {
            List<AdInfo> aInfos = new List<AdInfo>();
            aInfos = Ads.GetAds();

            return View(aInfos);
        }

        [HttpPost]
        public ActionResult AdSave(HttpPostedFileBase adImage = null)
        {
            string saveName = "";
            try
            {
                if (adImage != null)
                {
                    // 文件上传后的保存路径
                    var filePath = Server.MapPath(string.Format("~/{0}", "ads"));
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    var fileName = Path.GetFileName(adImage.FileName);
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                    saveName = Guid.NewGuid().ToString("n") + fileExtension; // 保存文件名称

                    adImage.SaveAs(Path.Combine(filePath, saveName));
                }

            }
            catch (Exception ex)
            {
                return Json(BuildAjaxBackResult(new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败，保存文件错误！")));
            }

            ReturnMessage messge = Ads.NewAd(saveName);

            return Json(BuildAjaxBackResult(messge));
        }

        [HttpPost]
        public ActionResult AdDelete(int adid)
        {
            ReturnMessage messge = Ads.DeleteAd(adid);

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
