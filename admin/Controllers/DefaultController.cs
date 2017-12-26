using callcenter.bll;
using callcenter.modal;
using callcenter.modal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using admin.Core;
using System.IO;

namespace admin.Controllers
{
    public class DefaultController : BaseController
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            ServiceUserInfo model = (ServiceUserInfo)Session["User"];
            return View(model);
        }

        public ActionResult JobIndex(JobInfo pageQuery)
        {
            ViewData["JobType"] = pageQuery.JobType;
            ViewData["Status"] = pageQuery.Status;
            return View(pageQuery);
        }

        public ActionResult JobsList(JobInfo pageQuery)
        {
            PagedTable result = Jobs.GetJobsByType(pageQuery);
            return result.ToJsonResult();
        }

        public ActionResult JobsDetail(int Id, int JobType, int Status)
        {
            ViewData["JobType"] = JobType;
            ViewData["Status"] = Status;
            var entity = Jobs.GetJobInfoById(Id);
            return View(entity);
        }

        [HttpPost]
        public ActionResult JobEditSave(int ID, int Status, string errMsg="", string ExpressNumber="", string DueBillNumber="", HttpPostedFileBase file=null)
        {
            string saveName = "";
            try
            {
                if (file != null)
                {
                    // 文件上传后的保存路径
                    var filePath = Server.MapPath(string.Format("~/{0}", "File"));
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }

                    var fileName = Path.GetFileName(file.FileName);
                    string fileExtension = Path.GetExtension(fileName); // 文件扩展名
                    saveName = Guid.NewGuid().ToString() + fileExtension; // 保存文件名称

                    file.SaveAs(Path.Combine(filePath, saveName));
                }

            }
            catch (Exception ex)
            {
                return Json(BuildAjaxBackResult(new ReturnMessage(EnumResultState.Failing.ToString(), "处理失败，保存文件错误！")));
            }

            ReturnMessage messge = Jobs.UpdateJobStatus(ID, Status, errMsg, saveName, 100, ExpressNumber, DueBillNumber);

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
