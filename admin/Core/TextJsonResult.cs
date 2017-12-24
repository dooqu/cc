using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Core
{
    /// <summary>
    /// 根据字符串返因JsonResult
    /// </summary>
    public class TextJsonResult : JsonResult
    {
        /// <summary>
        /// 通过从 System.Web.Mvc.ActionResult 类继承的自定义类型，启用对操作方法结果的处理。
        /// </summary>
        /// <param name="context">执行结果时所处的上下文。</param>
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!ContentType.IsNullOrEmpty())
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (Data != null)
            {
                response.Write(Data);
            }
        }
    }
}