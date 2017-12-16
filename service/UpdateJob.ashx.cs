using System;
using System.Collections.Generic;
using System.Web;
using callcenter.modal;
using callcenter.bll;

namespace callcenter.service
{
    /// <summary>
    /// UpdateJob 的摘要说明
    /// </summary>
    public class UpdateJob : baseHandler.WechatServiceHandler
    {
        public override ResponseInfo OnLoad(HttpContext context)
        {
            if(CurrentSession == null)
            {
                return new ResponseInfo(true, "登录状态已经过期");
            }

            if (CheckRequestParams(context, "jobId", "imageIndex") == false)
            {
                return new ResponseInfo(true, "参数缺失");
            }

            int jobId, imageIndex = 0;

            if(Int32.TryParse(GetParam("jobId"), out jobId) == false)
            {
                return new ResponseInfo(true, "jobid错误");
            }

            if(Int32.TryParse(GetParam("imageIndex"), out imageIndex) == false ||imageIndex < 1 || imageIndex > 5 )
            {
                return new ResponseInfo(true, "imageIndex错误");
            }

            HttpPostedFile imageFile = context.Request.Files["imageFile"];

            if(imageFile == null)
            {
                return new ResponseInfo(true, "uploadimage缺失");
            }

            string imageNewName = Guid.NewGuid().ToString("n") + System.IO.Path.GetExtension(imageFile.FileName);
            imageFile.SaveAs(System.IO.Path.Combine(context.Server.MapPath("/pics"), imageNewName));

            if(Jobs.UpdateJob(jobId, imageIndex, imageNewName) >= 0)
            {
                return new ResponseInfo(false, "操作成功");
            }
            else
            {
                return new ResponseInfo(true, "上传失败");
            }
        }
    }
}